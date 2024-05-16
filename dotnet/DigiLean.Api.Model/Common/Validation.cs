using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DigiLean.Api.Model.Common
{
    public class Validation
    {
        public bool IsValid
        {
            get
            {
                return !(Errors != null && Errors.Count > 0); // Valid if no errors are found
            }
        }
        public ICollection<ValidationResult> Errors { get; set; } = new List<ValidationResult>();
        
        public void AddResults(IEnumerable<ValidationResult> results)
        {
            foreach (var item in results)
            {
                Errors.Add(item);
            }
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
