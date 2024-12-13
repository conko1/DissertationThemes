using ImporterApp.DTO;
using ImporterApp.Enities;

namespace ImporterApp.Services
{
    internal interface IImporterService
    {
        Task ResetDatabaseState();
        Task ImportSupervisors(List<SupervisorDTO> supervisors);
        Task ImportThemes(List<ThemeDTO> themes);
        Task ImportStPrograms(List<StProgramDTO> stPrograms);
    }
}
