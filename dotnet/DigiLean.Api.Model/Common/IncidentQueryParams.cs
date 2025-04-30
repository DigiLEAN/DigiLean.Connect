namespace DigiLean.Api.Model.Common
{
    /// <summary>
    /// Incident Query params
    /// </summary>
    public class IncidentQueryParams
    {
        /// <summary>Incident Type. Lookup ID from sub endpoint</summary>
        /// <example>1</example>
        public int TypeId { get; set; } = 0;

        /// <summary>Filter Incident Date. Greater than</summary>
        /// <example>2024-12-01T00:00:00Z</example>
        public DateTime? IncidentDateFrom { get; set; }

        /// <summary>Filter Incident Date. Less than</summary>
        /// <example>2024-12-31T00:00:00Z</example>
        public DateTime? IncidentDateTo { get; set; }

        /// <summary>Filter LastModified Date. Greater than</summary>
        /// <example>2024-12-01T00:00:00Z</example>
        public DateTime? LastModifiedFrom { get; set; }

        /// <summary>Filter LastModified Date. Less than</summary>
        /// <example>2024-12-01T00:00:00Z</example>
        public DateTime? LastModifiedTo { get; set; }

        public string GetParamsAsUrl()
        {
            var url = "?";
            if (TypeId > 0) url += "typeId=" + TypeId;
            if (IncidentDateFrom.HasValue) url += "&incidentDateFrom=" + IncidentDateFrom.Value.ToString("MM-dd-yyyy");
            if (IncidentDateTo.HasValue) url += "&incidentDateTo=" + IncidentDateTo.Value.ToString("MM-dd-yyyy");
            if (LastModifiedFrom.HasValue) url += "&lastModifiedFrom=" + LastModifiedFrom.Value.ToString("MM-dd-yyyy");
            if (LastModifiedTo.HasValue) url += "&lastModifiedTo=" + LastModifiedTo.Value.ToString("MM-dd-yyyy");

            return url;
        }
    }
}