using System;

namespace DigiLean.Api.Model.Common
{
    public class TimePeriod
    {
        public TimePeriod()
        {

        }
        public TimePeriod(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}