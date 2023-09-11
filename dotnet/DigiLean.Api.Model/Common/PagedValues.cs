using System.Collections.Generic;

namespace DigiLean.Api.Model.Common
{
    public class PagedValues<T>
    {
        public int Total { get; set; }
        public int Page { get; set; } = 1;
        public IList<T> Values { get; set; } = new List<T>();
    }
}
