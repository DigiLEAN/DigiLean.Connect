namespace DigiLean.Api.Model.Clients
{
    public class ApiSettings
    {
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string Scopes { get; set; } = string.Empty;

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
                authUrl = "https://authdev.digilean.tools";
            }
            return (apiUrl, authUrl);
        }
    }
}
