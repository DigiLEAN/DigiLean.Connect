using DigiLean.Api.Model.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Formats.Asn1;
using System.Net.Http.Json;

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

        protected Task<TResult> PostGetResponseAndHandleError<TResult>(string url, object data)
        {
            return SendRequestGetResponseAndHandleError<TResult>(url, HttpMethod.Post, data);
        }

        protected Task<TResult> PutGetResponseAndHandleError<TResult>(string url, object? data = null)
        {
            return SendRequestGetResponseAndHandleError<TResult>(url, HttpMethod.Put, data);
        }

        protected async Task<TResult> DeleteGetResponseAndHandleError<TResult>(string url)
        {
            var response = await Client.DeleteAsync(url);
            TResult? result = default;
            if (response.IsSuccessStatusCode)
                result = await SerializePayload<TResult?>(response);
            else
                await HandleError(response);

            if (result == null)
                throw new ApplicationException("Result was null");
            return result;
        }

        protected async Task<TResult> SendRequestGetResponseAndHandleError<TResult>(string url, HttpMethod method, object? data = null)
        {
            HttpRequestMessage request = new()
            {
                Method = method,
                RequestUri = new Uri(url, UriKind.Relative)
            };

            if (data is not null)
                request.Content = data.AsJson();

            var response = await Client.SendAsync(request);

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
