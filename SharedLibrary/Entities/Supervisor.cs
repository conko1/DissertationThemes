using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Entity
{
    public class Supervisor : BaseEntity
    {
        [MaxLength(100)]
        public string FullName {  get; set; } = string.Empty;
        public List<Theme> Themes { get; set; } = new List<Theme>();
    }
}
