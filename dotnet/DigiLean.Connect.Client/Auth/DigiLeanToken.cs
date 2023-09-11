using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DigiLean.Connect.Client.Auth
{
    public class DigiLeanToken
    {
        public DigiLeanToken(string accessToken, string refreshToken, int expiresIn)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            AccessTokenExpirationUtc = DateTime.UtcNow.AddSeconds(expiresIn);
        }

        public bool IsExpired
        {
            get
            {
                return DateTime.UtcNow > AccessTokenExpirationUtc;
            }
        }
        public string AccessToken { get; }
        public string RefreshToken { get; }
        public DateTime AccessTokenExpirationUtc { get; }


        internal static async Task<DigiLeanToken> GetNew(string authUrl, DigiLeanConnectSettings _settings)
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(authUrl);
            if (disco.IsError)
            {
                var message = $"Problems with Auth server {authUrl} discovery document ";
                message += disco.Error;
                throw new ApplicationException(message);
            }

            var tokenOptions = new TokenClientOptions
            {
                ClientCredentialStyle = ClientCredentialStyle.AuthorizationHeader,
                Address = disco.TokenEndpoint,
                ClientId = _settings.ClientId,
                ClientSecret = _settings.ClientSecret
            };

            var tokenClient = new TokenClient(client, tokenOptions);
            var res = await tokenClient.RequestClientCredentialsTokenAsync();

            if (res.IsError)
            {
                var message = $"ConnectionError : DigiLEAN Authority server {authUrl} reports error: {res.Error}";
                message += res.ErrorDescription;
                throw new ApplicationException(message);
            }

            var token = new DigiLeanToken(res.AccessToken, res.RefreshToken, res.ExpiresIn);
            return token;
        }
    }
}
