
using ImporterApp.DTO;
using ImporterApp.Entities;
using SharedLibrary.Entity;

namespace ImporterApp.Enities
{
    internal class SupervisorDTO : BaseDTO<Supervisor>
    {
        internal string FullName { get; set; } = string.Empty;

        internal override Supervisor TransformToEntity() 
        { 
            return new Supervisor { 
                FullName = FullName
            };
        }
    }
}
