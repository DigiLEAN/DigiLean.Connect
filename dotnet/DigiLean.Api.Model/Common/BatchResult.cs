namespace DigiLean.Api.Model.Common
{
    public class BatchResult
    {
        public BatchResult(int total)
        {
            Total = total;
        }
        public BatchResult()
        {
        }
        public int Total { get; set; }
    }
}
