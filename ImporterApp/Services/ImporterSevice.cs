using ImporterApp.Importers;
using ImporterApp.Services;
using SharedLibrary.Data;
using SharedLibrary.Services;

namespace ImporterApp.Services
{
    public class ImporterService : IImporterService
    {
        private readonly ISupervisorService _superVisorService;
        private readonly IThemeService _themeVisorService;
        private readonly IStProgramService _stProgramService;

        public ImporterService(ISupervisorService superVisorService, IThemeService themeVisorService, IStProgramService stProgramService)
        {
            _stProgramService = stProgramService;
            _superVisorService = superVisorService;
            _themeVisorService = themeVisorService;
        }

        public async Task ResetAndImport()
        {

            await _superVisorService.DeleteAllSupervisors();
            await _themeVisorService.DeleteAllThemes();
            await _stProgramService.DeleteAllStPrograms();
        }

        public Task ImportSupervisors(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task ImportThemes(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task ImportStPrograms(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
