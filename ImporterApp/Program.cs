using ImporterApp.DTO;
using ImporterApp.Enities;
using ImporterApp.Helpers;
using ImporterApp.Importers;
using ImporterApp.Mapping;
using ImporterApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Data;
using SharedLibrary.Services;

namespace ImporterApp {
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var importerService = serviceProvider.GetRequiredService<IImporterService>();

            await importerService.ResetAndImport();

            var fileContent = await FileHelper.ReadFile("C:\\Users\\Ultra\\Desktop\\pot_uloha\\phd_temy.csv");

            var transformerObject = new CSVTransformer<General>();
            var generalObjects = transformerObject.GenerateDefaultObjects(fileContent);

            var dtoConverter = serviceProvider.GetRequiredService<DtoConverter>();

            var themeDto = dtoConverter.ConvertFromGeneralToDto<ThemeDTO>(generalObjects);
            var supervisorDto = dtoConverter.ConvertFromGeneralToDto<SupervisorDTO>(generalObjects);
            var stProgramDto = dtoConverter.ConvertFromGeneralToDto<StProgramDTO>(generalObjects);

            //var themes = importer.Import(fileContent);
            Console.WriteLine(themeDto);
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