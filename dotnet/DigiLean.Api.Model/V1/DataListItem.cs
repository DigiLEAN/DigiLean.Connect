using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.V1
{
    public class DataListItemCreate
    {
        [MaxLength(255)]
        public string? Identifier { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }
    }

    public class DataListItem : DataListItemCreate
    {
        public int Id { get; set; }
        public int SortOrder { get; set; }
    }
}
