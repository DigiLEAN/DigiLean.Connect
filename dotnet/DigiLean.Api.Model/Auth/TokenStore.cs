namespace DigiLean.Api.Model.Auth
{
    public class InMemoryTokenStore : ITokenStore
    {
        protected Dictionary<string, DigiLeanToken> Tokens = new Dictionary<string, DigiLeanToken>();

        public DigiLeanToken GetToken(string clientKey)
        {
            DigiLeanToken token;
            lock (Tokens)
                Tokens.TryGetValue(clientKey, out token);

            return token;
        }

        public void SaveToken(string clientKey, DigiLeanToken token)
        {
            lock (Tokens)
            {
                Tokens.Remove(clientKey);
                Tokens.Add(clientKey, token);
            }
        }
    }

    public interface ITokenStore
    {
        DigiLeanToken GetToken(string clientKey);
        void SaveToken(string clientKey, DigiLeanToken token);
    }
}
