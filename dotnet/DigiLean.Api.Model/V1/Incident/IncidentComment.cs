using System;
using System.Collections.Generic;
using System.Text;

namespace DigiLean.Api.Model.V1.Incident
{
    public class IncidentComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentedBy { get; set; }
        public string CommentedByUserId { get; set; }
        
        public int? ParentId { get; set; }
        public int Level { get; set; }
    }
}
