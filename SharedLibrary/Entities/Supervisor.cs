using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SharedLibrary.Entity
{
    public class Supervisor : BaseEntity
    {
        [MaxLength(100)]
        public string FullName {  get; set; } = string.Empty;

        public List<Theme> Themes { get; set; } = new List<Theme>();
    }
}
