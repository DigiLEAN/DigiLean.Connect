namespace DigiLean.Api.Model.Common
{
    public class PagedValues<T>
    {
        public int Total { get; set; }
        public int Page { get; set; } = 1;
        public List<T> Values { get; set; } = new List<T>();
    }
}
