using DigiLean.Api.Model.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DigiLean.Api.Model.Clients
{
    public abstract class ApiEndpointBase
    {
        protected readonly HttpClient Client;
        protected readonly ILogger? Logger;
        protected readonly string BasePath;

        public ApiEndpointBase(HttpClient client,
            ILogger? logger, string basePath)
        {
            Client = client;
            Logger = logger;
            BasePath = basePath;
        }

        protected async Task<TResult> GetResponseAndHandleError<TResult>(string url)
        {
            var response = await Client.GetAsync(url);
            TResult? result = default;
            if (response.IsSuccessStatusCode)
                result = await SerializePayload<TResult?>(response);
            else
                await HandleError(response);

            if (result == null)
                throw new ApplicationException("Result was null");
            return result;
        }

        protected async Task HandleError(HttpResponseMessage response, bool throwExp = true)
        {
            string url = GetUrlFromResponse(response);
            var generalErrorMsg = $"Error when calling {url}, StatusCode: {response.StatusCode}, msg: {response.ReasonPhrase}";
            var details = await response.Content.ParseProblemDetails();
            var detailsMessage = string.Empty;

            if (details is not null)
            {
                detailsMessage = $"Problem details from API {url}. Title: {details.Title}, Details: {details.Detail}. {details.Type}";
                if (details.Errors is not null && details.Errors.Count > 0)
                {
                    foreach (var error in details.Errors)
                    {
                        detailsMessage = $"{detailsMessage}. {error.Key}: ";
                        foreach (var msg in error.Value)
                            detailsMessage = $"{detailsMessage} {msg}, ";
                    }
                }
            }
                

            if (Logger != null)
            {
                Logger.LogError(generalErrorMsg);
                if (details != null)
                    Logger.LogError(detailsMessage);
            }

            if (throwExp)
            {
                var msg = details != null ? detailsMessage : generalErrorMsg;
                throw new DigiLeanApiException(msg, response.StatusCode);
            }
        }

        protected async Task<TResult?> SerializePayload<TResult>(HttpResponseMessage response)
        {
            var dataString = await response.Content.ReadAsStringAsync();
            TResult? data = JsonConvert.DeserializeObject<TResult>(dataString);
            return data;
        }

        protected string GetUrlFromResponse(HttpResponseMessage res)
        {
            //var url = response.RequestMessage?.RequestUri?.AbsoluteUri;
            if (res.RequestMessage == null || res.RequestMessage.RequestUri == null)
                return "";

            var verb = res.RequestMessage.Method.Method;
            var url = res.RequestMessage.RequestUri.AbsoluteUri;
            return $"{verb}: {url}";
        }
    }
}
