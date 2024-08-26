using System;
using System.Collections.Generic;
using System.Text;

namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentComment
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CommentDate { get; set; }
        public string CommentedBy { get; set; } = string.Empty;
        public string CommentedByUserId { get; set; } = string.Empty;

        public int? ParentId { get; set; }
        public int Level { get; set; }
    }
}
