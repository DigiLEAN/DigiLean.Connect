
namespace DigiLean.Api.Model.V1.Data
{
    public class TableValues : TableValues<DataValue>
    {
    }

    public class TableValues<T>
    {
        public int Total { get; set; }
        public IList<T>? Values { get; set; }
    }
}