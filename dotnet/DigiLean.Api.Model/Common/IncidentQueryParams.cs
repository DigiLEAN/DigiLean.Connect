namespace DigiLean.Api.Model.Common
{
    public class IncidentQueryParams
    {
        public int TypeId { get; set; } = 0;
        public DateTime? IncidentDateFrom { get; set; }
        public DateTime? IncidentDateTo { get; set; }
        public DateTime? LastModifiedFrom { get; set; }
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