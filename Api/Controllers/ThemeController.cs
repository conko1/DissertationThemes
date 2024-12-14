using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;
using SharedLibrary.Entity;
using SharedLibrary.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/theme")]
    public class ThemeController : ControllerBase
    {
        private readonly IThemeService _themeService;

        public ThemeController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ThemeDTO>>> GetThemes([FromQuery] ThemeFilterParams filterParams)
        {
            return Ok(await _themeService.GetAllThemes(filterParams));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ThemeDTO>> GetThemeById(int id)
        {
            var theme = await _themeService.GetThemeById(id);

            if (theme == null)
            {
                return NotFound();
            }

            return Ok(theme);
        }

        [HttpGet("years")]
        public async Task<ActionResult<Int32>> GetThemesYears()
        {
            return Ok(await _themeService.GetThemesYears());
        }
    }
}
