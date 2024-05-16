namespace DigiLean.Api.Model.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToUtcIsoString(this DateTime date)
        {
            return date.ToUniversalTime()
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
        }
    }
}
