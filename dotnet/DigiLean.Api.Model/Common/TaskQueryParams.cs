using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DigiLean.Api.Model.Common
{
    /// <summary>
    /// Task query parameters
    /// </summary>
    public class TaskQueryParams
    {
        /// <summary>Page Size default is 100 and max 10000</summary>
        /// <example>200</example>
        [Range(0, 10000)]
        public int Count { get; set; } = 100;

        /// <summary>Page default and start value is 1</summary>
        /// <example>2</example>
        public int Page { get; set; } = 1;

        /// <summary>Filter BoardDate. Greater than</summary>
        /// <example>2023-12-01T00:00:00Z</example>
        public DateTime? From { get; set; }

        /// <summary>Filter BoardDate. Lesser than</summary>
        /// <example>2023-12-24T00:00:00Z</example>
        public DateTime? To { get; set; }

        /// <summary>Get as query string</summary>
        public Dictionary<string, string> GetQueryDictionary()
        {
            var activeItems = new Dictionary<string, string>
            {
                { "Count", Count.ToString() },
                { "Page", Page.ToString() }
            };

            if (From.HasValue) activeItems.Add("From", GetFormattedDate(From.Value));
            if (To.HasValue) activeItems.Add("To", GetFormattedDate(To.Value));
            return activeItems;
        }

        private string GetFormattedDate(DateTime date)
        {
            string utcDateOut = date.ToString("s", CultureInfo.InvariantCulture);
            return utcDateOut;
        }
    }
}
