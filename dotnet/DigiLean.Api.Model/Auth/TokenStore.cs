namespace DigiLean.Api.Model.Auth
{
    public sealed class InMemoryToken : ITokenStore
    {
        private static readonly Dictionary<string, DigiLeanToken> Tokens = [];
        private static InMemoryToken? singleton;
        private static readonly object singletonLock = new();

        /// <summary>
        /// Use singleton object to share token between public and internal API
        /// </summary>
        private InMemoryToken() {}
        public static InMemoryToken Store
        {
            get
            {
                lock (singletonLock)
                {
                    singleton ??= new InMemoryToken();
                    return singleton;
                }
            }
        }

        public DigiLeanToken? GetToken(string clientKey)
        {
            DigiLeanToken? token;
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
        DigiLeanToken? GetToken(string clientKey);
        void SaveToken(string clientKey, DigiLeanToken token);
    }
}
