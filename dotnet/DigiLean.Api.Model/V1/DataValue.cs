using DigiLean.Api.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1
{
    public class DataValuesPaged : PagedValues<DataValue>
    {
    }

    public class DataValue
    {
        public int Id { get; set; }
        [Required]
        public int DataSourceId { get; set; }
        public int? AreaId { get; set; }
        public int? AssetId { get; set; }
        public int? ProjectId { get; set; }
        [Required]
        public double Value { get; set; }
        public string? Description { get; set; }
        public string? Dimension { get; set; }
        public string? Dimension2 { get; set; }
        public string? Dimension3 { get; set; }
        public string? Dimension4 { get; set; }
        [Required]
        public DateTime ValueDate { get; set; }
        public DateTime RegistrationDate { get; set; }

        public string? ExternalId { get; set; }

        public override string ToString()
        {
            return $"Data Source id: {DataSourceId}, Value: {Value}, Time: {ValueDate.ToLocalTime()}";
        }
    }
}
