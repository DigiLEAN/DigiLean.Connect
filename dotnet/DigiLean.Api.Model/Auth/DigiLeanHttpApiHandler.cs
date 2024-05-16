using DigiLean.Api.Model.Clients;
using IdentityModel.Client;

namespace DigiLean.Api.Model.Auth
{
    public class DigiLeanHttpApiHandler : DelegatingHandler
    {
        private readonly string AuthUrl;
        private readonly ApiSettings _settings;
        private ITokenStore TokenStore;

        public DigiLeanHttpApiHandler(ApiSettings settings, string authUrl)
        {
            _settings = settings;
            AuthUrl = authUrl;
            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var token = await GetToken();
            request.SetBearerToken(token.AccessToken);
            var res = await base.SendAsync(request, cancellationToken);
            if (res.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                // force new and try again
                token = await GetSetNewToken();
                request.SetBearerToken(token.AccessToken);
                res = await base.SendAsync(request, cancellationToken);
            }
            return res;
        }

        public async Task<DigiLeanToken> GetToken()
        {
            if (TokenStore != null)
            {
                var currentToken = TokenStore.GetToken(_settings.ClientId);
                if (currentToken != null && !currentToken.IsExpired)
                    return currentToken;
            }
            return await GetSetNewToken();
        }
        private async Task<DigiLeanToken> GetSetNewToken()
        {
            if (TokenStore == null)
                TokenStore = new InMemoryTokenStore();

            var newToken = await DigiLeanToken.GetNew(AuthUrl, _settings);
            TokenStore.SaveToken(_settings.ClientId, newToken);
            return newToken;
        }
    }
}
