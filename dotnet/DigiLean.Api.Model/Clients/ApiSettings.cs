namespace DigiLean.Api.Model.Clients
{
    /// <summary>ApiSettings</summary>
    public class ApiSettings
    {
        /// <summary>ClientId</summary>
        public string ClientId { get; set; } = string.Empty;

        /// <summary>ClientSecret</summary>
        public string ClientSecret { get; set; } = string.Empty;

        /// <summary>Scopes</summary>
        public string Scopes { get; set; } = string.Empty;

        /// <summary>Resolve</summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static (string apiUrl, string authUrl) Resolve(ApiMode mode)
        {
            // Default production
            var apiUrl = "https://connect.digilean.tools";
            var authUrl = "https://auth.digilean.tools";
            if (mode == ApiMode.Test)
            {
                apiUrl = "https://apidev.digilean.tools";
                authUrl = "https://auth-test.digilean.tools";
            }
            else if (mode == ApiMode.Localhost)
            {
                apiUrl = "https://localhost:4001";
                authUrl = "https://auth-test.digilean.tools";
            }
            return (apiUrl, authUrl);
        }
    }
}