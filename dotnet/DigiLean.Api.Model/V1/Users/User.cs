namespace DigiLean.Api.Model.V1.Users
{
    public class User : UserBase
    {
        public string Id { get; init; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();
        public string FullName => FirstName + " " + LastName;
    }
}