using ImporterApp.DTO;
using ImporterApp.Enities;
using ImporterApp.Helpers;
using ImporterApp.Importers;
using ImporterApp.Mapping;
using ImporterApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Data;
using SharedLibrary.Entity;
using SharedLibrary.Services;

namespace ImporterApp {
    class Program
    {
        public async static Task<int> Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("Zadajte príklaz vo formáte ImporterApp.exe '<path_toFile>'");
                return -1;
            }

            var serviceProvider = ConfigureServices();
            var importerService = serviceProvider.GetRequiredService<IImporterService>();

            if (args.Length > 1 && (args[1] == "-r" || args[1] == "--remove-previous-data"))
            {
                await importerService.ResetDatabaseState();
            }

            List<String> fileContent = [];
            try
            {
                fileContent = await FileHelper.ReadFile(args[0]);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return -1;
            }

            var transformerObject = new CSVTransformer<General>();
            var generalObjects = transformerObject.GenerateDefaultObjects(fileContent);

            var dtoConverter = serviceProvider.GetRequiredService<DtoConverter>();

            var themeDto = dtoConverter.ConvertFromGeneralToDto<ThemeDTO>(generalObjects);
            var supervisorDto = dtoConverter.ConvertFromGeneralToDto<SupervisorDTO>(generalObjects);
            var stProgramDto = dtoConverter.ConvertFromGeneralToDto<StProgramDTO>(generalObjects);

            for (int i = 0; i < themeDto.Count; i++)
            {
                var theme = themeDto[i];
                if (theme.Description.Contains("<br>"))
                {
                    theme.Description = theme.Description.Replace("<br>", "\n");
                }
            }

            importerService.ImportSupervisors(supervisorDto);
            importerService.ImportStPrograms(stProgramDto);
            importerService.ImportThemes(themeDto);

            return 0;
        }

        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IImporterService, ImporterService>();

            services.AddAutoMapper(typeof(ImporterAppMapper));
            services.AddSingleton<DtoConverter>();

            services.AddSingleton<ISupervisorService, SupervisorService>();
            services.AddSingleton<IThemeService, ThemeService>();
            services.AddSingleton<IStProgramService, StProgramService>();

            services.AddSingleton<IStProgramService, StProgramService>();

            var projectRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            var dbFilePath = Path.Combine(projectRootPath, "SharedLibrary", "DissertionThemes.db");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite($"Data Source={dbFilePath}"));

            return services.BuildServiceProvider();
        }
    }
}