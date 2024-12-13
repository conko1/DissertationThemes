using ImporterApp.Entities;
using SharedLibrary.Entity;
using SharedLibrary.Types;

namespace ImporterApp.DTO
{
    public class ThemeDTO : BaseDTO<Theme>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SupervisorId { get; set; }

        public string Supervisor { get; set; }

        public int StProgramId { get; set; }

        public string StProgram { get; set; }

        public bool IsFullTimeStudy { get; set; }

        public bool IsExternalStudy { get; set; }

        public ResearchType ResearchType { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public override Theme TransformToEntity()
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
