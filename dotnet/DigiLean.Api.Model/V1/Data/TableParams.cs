using DigiLean.Api.Model.Common;
using System.Collections.Generic;

namespace DigiLean.Api.Model.V1.Data
{
    public class TableParams
    {
        public TableParams()
        {
            Page = 1;
            Count = 10;
        }
        public int Page { get; set; }
        public int Count { get; set; }
        public int Offset => (Page - 1) * Count;

        public List<SortExpression> Sorting { get; set; } = new List<SortExpression>();
        public List<FilterElement> Filters { get; set; } = new List<FilterElement>();
        public TimePeriod TimePeriod { get; set; }
        public List<Column> Columns { get; set; } = new List<Column>();
        public string GetOrderByExpression()
        {
            if (Sorting == null || Sorting.Count == 0) return "";
            var expression = "ORDER BY ";
            foreach (var sortExpression in Sorting)
            {
                expression += sortExpression.Property + " " + sortExpression.Direction.ToUpper() + ",";
            }
            // Remove trailing comma
            expression = expression.Substring(0, expression.Length - 1);
            return expression;
        }
    }
}