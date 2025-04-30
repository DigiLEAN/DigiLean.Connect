using DigiLean.Api.Model.Auth;
using DigiLean.Api.Model.Clients;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace DigiLean.Api.Client
{
    public class DigiLeanApiClient
    {
        private readonly HttpClient httpClient;
        private readonly DigiLeanHttpApiHandler _handler;

        public string Url { get; }

        public PublicApiVersion1 Version1 { get; }

        public DigiLeanApiClient(ApiSettings settings, string apiUrl, string authUrl) : this(null, settings, apiUrl, authUrl)
        {

        }
        public DigiLeanApiClient(ILoggerFactory? factory, ApiSettings settings, string apiUrl, string authUrl)
        {
            Url = apiUrl;
            _handler = new DigiLeanHttpApiHandler(settings, authUrl);
            httpClient = new HttpClient(_handler)
            {
                BaseAddress = new Uri(apiUrl),
                Timeout = TimeSpan.FromMinutes(2)
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ILogger? logger = null;
            if (factory != null)
            {
                logger = factory.CreateLogger("publicAPI");
            }

            Version1 = new PublicApiVersion1(httpClient, logger);
        }

        public async Task<DigiLeanToken> GetToken()
        {
            return await _handler.GetToken();
        }
    }
}
