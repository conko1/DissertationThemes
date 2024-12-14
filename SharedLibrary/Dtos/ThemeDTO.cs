using SharedLibrary.Entity;
using SharedLibrary.Types;

namespace SharedLibrary.Dtos
{
    public class ThemeDTO : BaseEntityDTO
    {
        public string Name { get; set; } = string.Empty;

        public SupervisorDTO? Supervisor { get; set; }

        public StProgramDTO? StProgram { get; set; }

        public bool IsFullTimeStudy { get; set; }

        public bool IsExternalStudy { get; set; }

        public ResearchType ResearchType { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

    }
}
