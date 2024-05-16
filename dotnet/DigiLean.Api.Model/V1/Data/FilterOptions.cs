namespace DigiLean.Api.Model.V1.Data
{
    public class FilterOptions
    {
        public FilterOptions(int customerId)
        {
            CustomerId = customerId;
            FilterElements = new List<FilterElement>();
        }

        public int CustomerId { get; set; }
        public IList<FilterElement> FilterElements { get; set; }
    }
}
