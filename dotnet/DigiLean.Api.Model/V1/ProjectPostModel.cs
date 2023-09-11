using System;
using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1
{
    public class ProjectPostModel
    {
        [Required]
        public string ProjectNumber { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string PurchaseOrder { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public string CustomerNumber { get; set; }

        public string OwnerEmail { get; set; }
        public string[] MembersEmail { get; set; }
        public string ExternalId { get; set; }
    }
}
