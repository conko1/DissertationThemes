using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary.Types;

namespace SharedLibrary.Entity
{
    public class Theme : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public required Supervisor Supervisor {  get; set; }

        [Required]
        public required StProgram StProgram { get; set; }

        public bool IsFullTimeStudy {  get; set; }

        public bool IsExternalStudy { get; set; }

        public ResearchType ResearchType { get; set; }

        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
