using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiLean.Api.Model.V1.Incident
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? SortOrder { get; set; }
        public int? ParentId { get; set; }
        public List<Category> Children { get; set; } = new List<Category>();
    }
}