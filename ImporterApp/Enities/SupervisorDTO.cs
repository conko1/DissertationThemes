
using ImporterApp.DTO;
using ImporterApp.Entities;
using SharedLibrary.Entity;

namespace ImporterApp.Enities
{
    internal class SupervisorDTO : BaseDTO<Supervisor>
    {
        internal string Fullname { get; set; } = string.Empty;

        public override Supervisor TransformToEntity() 
        { 
            return new Supervisor { 
                FullName = Fullname
            };
        }
    }
}
