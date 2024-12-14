using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<Theme>>> GetThemes([FromQuery] ThemeFilterParams filterParams)
        {
            return Ok(await _themeService.GetAllThemes(filterParams));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Theme>> GetThemeById(int id)
        {
            var theme = await _themeService.GetThemeById(id);

            if (theme == null)
            {
                return NotFound();
            }

            return Ok(theme);
        }
    }
}
