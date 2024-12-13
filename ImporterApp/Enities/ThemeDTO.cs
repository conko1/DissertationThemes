using ImporterApp.Entities;
using SharedLibrary.Entity;
using SharedLibrary.Types;

namespace ImporterApp.DTO
{
    internal class ThemeDTO : BaseDTO<Theme>
    {
        internal int Id { get; set; }

        internal string Name { get; set; } = string.Empty;

        internal int SupervisorId { get; set; }

        internal string Supervisor { get; set; } = string.Empty;

        internal int StProgramId { get; set; }

        internal string StProgram { get; set; } = string.Empty;

        internal string FieldOfStudy { get; set; } = string.Empty;

        internal bool IsFullTimeStudy { get; set; }

        internal bool IsExternalStudy { get; set; }

        internal ResearchType ResearchType { get; set; }

        internal string Description { get; set; } = string.Empty;

        internal DateTime CreatedAt { get; set; }

        internal override Theme TransformToEntity()
        {
            return new Theme
            {
                Id = Id,
                Name = Name,
                CreatedAt = CreatedAt,
                Description = Description,
                IsExternalStudy = IsExternalStudy,
                IsFullTimeStudy = IsFullTimeStudy,
                ResearchType = ResearchType,
                StProgramId = StProgramId,
                SupervisorId = SupervisorId,
            };
        }
    }
}
