using System.Collections.Generic;

namespace DigiLean.Api.Model.V1
{
    public class DataSource
    {
        public DataSource()
        {
            Elements = new List<DataSourceElement>();
            PrimaryInputSource = "manual";
        }
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ObjectSource { get; set; }
        public string UnitOfTime { get; set; }
        public string PrimaryInputSource { get; set; }

        public List<DataSourceElement> Elements { get; set; }
    }
}
