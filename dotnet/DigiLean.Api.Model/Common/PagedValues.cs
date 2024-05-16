using DigiLean.Api.Model.V1;
namespace DigiLean.Api.Model.Common
{
    public class PagedValues<T>
    {
        public int Total { get; set; }
        public int Page { get; set; } = 1;
        public List<T> Values { get; set; } = new List<T>();
    }

    public class PeriodFilteredDataValues
    {
        public List<DataValue> Values { get; init; } = new List<DataValue>();
        public int Count => Values.Count;
        public DateTime From { get; init; }
        public DateTime To { get; init; }
        public PeriodFilteredDataValues(DateTime from, DateTime to, List<DataValue> values)
        {
            From = from;
            To = to;
            Values = values;
        }
    }

    public class PagedCursorDataValues
    {
        public int PageCount { get; set; }
        public long Cursor { get; set; }
        public long NextCursor { get; set; }
        public bool HasNext => NextCursor > 0;
        public List<DataValue> Values { get; set; } = new List<DataValue>();

        public PagedCursorDataValues(int count, long cursor, List<DataValue> values)
        {
            PageCount = count;
            Cursor = cursor;
            Values = values;

            if (values.Count == PageCount)
            {
                var lastValue = Values.Last();
                NextCursor = lastValue.Id;
            }
        }
    }
}
