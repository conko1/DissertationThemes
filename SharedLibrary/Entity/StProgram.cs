using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Entity
{
    public class StProgram : BaseEntity
    {
        public string FieldOfStudy { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public required List<Theme> Themes { get; set; }
    }
}
