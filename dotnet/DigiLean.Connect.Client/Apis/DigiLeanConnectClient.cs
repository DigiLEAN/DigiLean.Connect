using DigiLean.Connect.Client.Auth;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DigiLean.Connect.Client.Apis
{
    public class DigiLeanConnectClient
    {
        private readonly HttpClient httpClient;
        private readonly DigiLeanHttpApiHandler _handler;

        public string Url { get; }

        public DigiLeanApiVersion1 Version1 { get; }

        public DigiLeanConnectClient(DigiLeanConnectSettings settings, string apiUrl, string authUrl)
        {
            Url = apiUrl;
            _handler = new DigiLeanHttpApiHandler(settings, authUrl);
            httpClient = new HttpClient(_handler) { BaseAddress = new Uri(apiUrl) };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ILogger logger = null;

            Version1 = new DigiLeanApiVersion1(httpClient, logger);
        }

        public async Task<DigiLeanToken> GetToken()
        {
            return await _handler.GetToken();
        }
    }
}
