using DigiLean.Api.Model.Common;

namespace DigiLean.Api.Model.V1.Data
{
    public class SortExpression
    {
        private string property = "";
        public string Property
        {
            get
            {
                return property;
            }
            set
            {
                if (SqlInjection.CheckForSQLInjection(value)) return;
                property = value;
            }
        }


        private string? direction;
        public string Direction
        {
            get
            {
                return direction;
            }
            set
            {
                if (SqlInjection.CheckForSQLInjection(value)) return;
                direction = value;
            }
        }
    }
}