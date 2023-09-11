using System;
using System.Collections.Generic;
using System.Globalization;

namespace DigiLean.Api.Model.Common
{
    public class TaskQueryParams
    {
        public int? BoardId { get; set; }
        public int Count { get; set; } = 100;
        public int Page { get; set; } = 1;
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public Dictionary<string, string> GetQueryDictionary()
        {
            var activeItems = new Dictionary<string, string>();
            activeItems.Add("Count", Count.ToString());
            activeItems.Add("Page", Page.ToString());

            if (BoardId.HasValue) activeItems.Add("BoardId", BoardId.ToString());
            if (From.HasValue) activeItems.Add("From", GetFormattedDate(From));
            if (To.HasValue) activeItems.Add("To", GetFormattedDate(To));
            return activeItems;
        }

        private string GetFormattedDate(DateTime? date)
        {
            string utcDateOut = DateTime.UtcNow.ToString("s", CultureInfo.InvariantCulture);
            DateTime utcDateIn = DateTime.ParseExact(utcDateOut, "s",
                              CultureInfo.InvariantCulture,
                              DateTimeStyles.AdjustToUniversal);
            return utcDateOut;
        }
    }
}
