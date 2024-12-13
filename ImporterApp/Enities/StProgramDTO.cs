using ImporterApp.Entities;
using SharedLibrary.Entity;

namespace ImporterApp.Enities
{
    internal class StProgramDTO : BaseDTO<StProgram>
    {
        internal string FieldOfStudy { get; set; } = string.Empty;

        internal string Name { get; set; } = string.Empty;

        public override StProgram TransformToEntity()
        {
            return new StProgram
            {
                FieldOfStudy = FieldOfStudy,
                Name = Name
            };
        }
    }
}
