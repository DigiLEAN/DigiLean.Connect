using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentResponsible
    {
        public IncidentResponsible()
        {

        }
        public IncidentResponsible(int followUpGroupId, string responsibleUserId)
        {
            FollowUpGroupId = followUpGroupId;
            ResponsibleUserId = responsibleUserId;
        }
        [Required]
        public int FollowUpGroupId { get; set; }
        [Required]
        public string ResponsibleUserId { get; set; }
    }
}
