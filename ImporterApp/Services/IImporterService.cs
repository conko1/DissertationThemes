using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImporterApp.Services
{
    internal interface IImporterService
    {
        Task ResetAndImport();
        Task ImportSupervisors(string filePath);
        Task ImportThemes(string filePath);
        Task ImportStPrograms(string filePath);
    }
}
