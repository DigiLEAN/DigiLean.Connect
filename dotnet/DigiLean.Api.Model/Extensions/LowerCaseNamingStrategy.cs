using Newtonsoft.Json.Serialization;

namespace DigiLean.Api.Model.Extensions
{
    public class LowerCaseNamingStrategy : NamingStrategy
    {
        protected override string ResolvePropertyName(string name)
        {
            return name.ToLower();
        }
    }
}
