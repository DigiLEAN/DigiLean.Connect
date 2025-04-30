using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1
{
    public class DataValuesPaged
    {
        public int PageSize { get; init; }
        public int PageNo { get; init; }
        public int Count { get; init; }
        public List<DataValue> Values { get; init; } = new List<DataValue>();

        public DataValuesPaged(List<DataValue> values, int pageSize, int page = 1)
        {
            PageSize = pageSize;
            PageNo = page;
            Values = values;
            Count = values.Count;
        }
    }

    /// <summary>
    /// Base class for DataValue for API
    /// </summary>
    public class DataValueCreate
    {
        public int? AreaId { get; set; }
        public int? AssetId { get; set; }
        public int? ProjectId { get; set; }
        [Required]
        public double Value { get; set; }
        
        [MaxLength(255)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string? Dimension { get; set; }

        [MaxLength(100)]
        public string? Dimension2 { get; set; }

        [MaxLength(100)]
        public string? Dimension3 { get; set; }

        [MaxLength(100)]
        public string? Dimension4 { get; set; }

        [Required]
        public DateTime ValueDate { get; set; }

        [MaxLength(255)]
        public string? ExternalId { get; set; }
    }

    public class DataValue : DataValueCreate
    {
        public int Id { get; set; }
        [Required]
        public int DataSourceId { get; set; }
        
        public DateTime RegistrationDate { get; set; }

        public override string ToString()
        {
            return $"Data Source id: {DataSourceId}, Value: {Value}, Time: {ValueDate.ToLocalTime()}";
        }
    }
}
