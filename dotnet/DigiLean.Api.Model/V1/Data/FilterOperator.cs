namespace DigiLean.Model.KPI.Filter
{
    public static class FilterOperators
    {
        public static FilterOperator InList => new FilterOperator("InList");
        new public static FilterOperator Equals => new FilterOperator("Equals");
        public static FilterOperator NotEquals => new FilterOperator("NotEquals");
        public static FilterOperator GreaterThan => new FilterOperator("GreaterThan");
        public static FilterOperator GreaterThanOrEquals => new FilterOperator("GreaterThanOrEquals");
        public static FilterOperator LessThan => new FilterOperator("LessThan");
        public static FilterOperator LessThanDate => new FilterOperator("LessThanDate");
        public static FilterOperator LessThanOrEquals => new FilterOperator("LessThanOrEquals");
        public static FilterOperator Contains => new FilterOperator("Contains");
        public static FilterOperator NotContain => new FilterOperator("NotContain");
        public static FilterOperator IsNull => new FilterOperator("IsNull");
        public static FilterOperator IsNotNull => new FilterOperator("IsNotNull");
    }

    public class FilterOperator
    {
        public FilterOperator(string name)
        {
            Name = name;
        }

        public string? Name { get; set; }
    }
}
