using DigiLean.Connect.Client.Apis;
using System;

namespace DigiLean.Connect.Client
{
    public static class DigiLeanConnectApi
    {
        public static DigiLeanConnectClient Create(string clientId, string secret, bool testMode = false)
        {
            var settings = new DigiLeanConnectSettings
            {
                ClientId = clientId,
                ClientSecret = secret,
            };

            var (apiUrl, authUrl) = Resolve(testMode);
            var client = new DigiLeanConnectClient(settings, apiUrl, authUrl);
            return client;
        }

        public static (string apiUrl, string authUrl) Resolve(bool testMode)
        {
            var apiUrl = "https://connect.digilean.tools";
            var authUrl = "https://auth.digilean.tools";
            
            if (testMode)
            {
                apiUrl = "https://apidev.digilean.tools";
                authUrl = "https://authdev.digilean.tools";
            }

            return (apiUrl, authUrl);
        }
    }
}
