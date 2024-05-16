using DigiLean.Api.Model.Clients;
using Microsoft.Extensions.Logging;

namespace DigiLean.Api.Client
{
    public static class DigiLeanApi
    {
        public static DigiLeanApiClient Create(string clientId, string secret, ApiMode mode, ILoggerFactory? factory = null)
        {
            var settings = new ApiSettings
            {
                ClientId = clientId,
                ClientSecret = secret,
                //Scopes = $"{DigiLeanScopes.PublicApiRead} {DigiLeanScopes.PublicApiWrite}"
            };

            var (apiUrl, authUrl) = ApiSettings.Resolve(mode);
            var client = new DigiLeanApiClient(factory, settings, apiUrl, authUrl);
            return client;
        }
    }
}
