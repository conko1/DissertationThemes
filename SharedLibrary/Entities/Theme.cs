using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedLibrary.Types;

namespace SharedLibrary.Entity
{
    public class Theme : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int SupervisorId { get; set; }

        [Required]
        [ForeignKey("SupervisorId")]
        public Supervisor Supervisor { get; set; }

        [Required]
        public int StProgramId { get; set; }

        [Required]
        [ForeignKey("StProgramId")]
        public StProgram StProgram { get; set; }

        public bool IsFullTimeStudy { get; set; }

        public bool IsExternalStudy { get; set; }

        public ResearchType ResearchType { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

    }
}
