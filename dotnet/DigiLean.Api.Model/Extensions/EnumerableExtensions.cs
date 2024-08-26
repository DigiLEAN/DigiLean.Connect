namespace DigiLean.Api.Model.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool NotNullOrEmpty<T>(this IEnumerable<T> list)
        {
            if (list is null)
            {
                return false;
            }

            if (list.Any())
            {
                return true;
            }

            return false;
        }
    }
}
