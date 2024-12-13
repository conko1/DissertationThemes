using System.IO.IsolatedStorage;
using ImporterApp.DTO;
using ImporterApp.Enities;
using SharedLibrary.Entity;
using SharedLibrary.Services;

namespace ImporterApp.Services
{
    internal class ImporterService : IImporterService
    {
        private readonly ISupervisorService _supervisorService;
        private readonly IThemeService _themeService;
        private readonly IStProgramService _stProgramService;

        public ImporterService(ISupervisorService supervisorService, IThemeService themeService, IStProgramService stProgramService)
        {
            _stProgramService = stProgramService;
            _supervisorService = supervisorService;
            _themeService = themeService;
        }

        public async Task ResetDatabaseState()
        {
            await _supervisorService.DeleteAllSupervisors();
            await _themeService.DeleteAllThemes();
            await _stProgramService.DeleteAllStPrograms();
        }

        public async Task ImportSupervisors(List<SupervisorDTO> supervisors)
        {
            List<Supervisor> supervisorsEntities = new List<Supervisor>();

            for (int i = 0; i < supervisors.Count; i++)
            {
                var supervisor = supervisors[i];
                var used = false;
                for (int j = 0; j < supervisorsEntities.Count; j++)
                {
                    if (supervisorsEntities[j].FullName == supervisors[i].FullName)
                    {
                        used = true;
                        break;
                    }
                }

                if (used)
                {
                    continue;
                }

                supervisorsEntities.Add(supervisor.TransformToEntity());
            }

            await _supervisorService.BulkAddSupervisors(supervisorsEntities);
        }

        public async Task ImportThemes(List<ThemeDTO> themes)
        {
            List<Theme> themesEntities = new List<Theme>();

            for (int i = 0; i < themes.Count; i++)
            {
                var themeDto = themes[i];

                var stProgram = await _stProgramService.GetStProgramByFieldOfStudy(themeDto.FieldOfStudy);
                var supervisor = await _supervisorService.GetSupervisorFullName(themeDto.Supervisor);

                themeDto.StProgramId = stProgram.Id;
                themeDto.SupervisorId = supervisor.Id;

                var theme = themeDto.TransformToEntity();
                themesEntities.Add(theme);
            }

            await _themeService.BulkAddThemes(themesEntities);
        }

        public async Task ImportStPrograms(List<StProgramDTO> stPrograms)
        {
            List<StProgram> stProgramsEntities = new List<StProgram>();

            for (int i = 0; i < stPrograms.Count; i++)
            {
                var stProgram = stPrograms[i];
                var used = false;
                for (int j = 0; j < stProgramsEntities.Count; j++)
                {
                    if (stProgramsEntities[j].FieldOfStudy == stPrograms[i].FieldOfStudy)
                    {
                        used = true;
                        break;
                    }
                }

                if (used)
                {
                    continue;
                }

                stProgramsEntities.Add(stProgram.TransformToEntity());
            }

            await _stProgramService.BulkAddStPrograms(stProgramsEntities);
        }
    }
}
