using DigiLean.Connect.Client.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DigiLean.Connect.Client.Apis
{
    public abstract class ApiEndpointBase
    {
        protected readonly HttpClient Client;
        protected readonly ILogger Logger;
        protected readonly string BasePath;

        public ApiEndpointBase(HttpClient client,
            ILogger logger, string basePath)
        {
            Client = client;
            Logger = logger;
            BasePath = basePath;
        }

        protected async Task HandleError(HttpResponseMessage response, bool throwExp = true)
        {
            var url = response.RequestMessage.RequestUri;
            var generalErrorMsg = $"Error when calling {url}, StatusCode: {response.StatusCode}, msg: {response.ReasonPhrase}";
            var details = await response.Content.ParseProblemDetails();
            var detailsMessage = string.Empty;

            if (details != null)
                detailsMessage = $"Problem details from API. StatusCode: {response.StatusCode}, Title: {details.Title}, Details: {details.Detail}. {details.Type}";

            if (Logger != null)
            {
                Logger.LogError(generalErrorMsg);
                if (details != null)
                    Logger.LogError(detailsMessage);
            }
            
            if (throwExp)
            {
                var msg = details != null ? detailsMessage : generalErrorMsg;
                throw new ApplicationException(msg);
            }
                
            return;
        }

        protected async Task<TResult> SerializePayload<TResult>(HttpResponseMessage response)
        {
            var dataString = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<TResult>(dataString);
            return data;
        }
    }
}
