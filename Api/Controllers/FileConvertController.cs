using Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Services;
using SharedLibrary.Types;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/file")]
    public class FileConvertController : ControllerBase
    {
        private readonly IThemeService _themeService;

        public FileConvertController(IThemeService themeService)
        {
            _themeService = themeService;

        }

        [HttpGet("theme-to-word/{id}")]
        public async Task<IActionResult> GenerateDocxDocumentFromSchema(int id)
        {
            var theme = await _themeService.GetThemeById(id);

            if (theme == null)
            {
                return NotFound();
            }

            var replacements = new Dictionary<string, string>
                {
                    { "Theme", theme.Name },
                    { "Supervisor", theme.Supervisor.FullName },
                    { "StProgram", theme.StProgram.Name },
                    { "FieldStudy", theme.StProgram.FieldOfStudy },
                    { "ResearchType", TypeExtension.FromEnum((ResearchType) theme.ResearchType) },
                    { "Description", theme.Description }
                };

            var fileName = $"theme_{theme.Id}.docx";
            var generatedThemeFilePath = $"Schemas/{fileName}";

            FileHelper.ReplacePlaceholdersInDocx(replacements, generatedThemeFilePath);

            byte[] documentBytes = await System.IO.File.ReadAllBytesAsync(generatedThemeFilePath);

            System.IO.File.Delete(generatedThemeFilePath);

            return File(
                documentBytes,
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                fileName
            );     
        }

        [HttpGet("themes-to-csv")]
        public async Task<IActionResult> GenerateCsvDocumentFromSchema([FromQuery] ThemeFilterParams filterParams)
        {
            var themes = await _themeService.GetAllThemes(filterParams);

            var documentBytes = FileHelper.ConvertThemesToCsv(themes);

            var fileName = $"themes_{DateTime.Now:yyyyMMddHHmmss}.csv";

            return File(
                documentBytes,
                "text/csv",
                fileName
            );
        }
    }
}
