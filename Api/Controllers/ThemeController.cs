using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Entity;
using SharedLibrary.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/themes")]
    public class ThemeController : ControllerBase
    {
        private readonly IThemeService _themeService;

        public ThemeController(IThemeService themeService)
        {
            _themeService = themeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Theme>>> GetThemes()
        {
            return Ok(await _themeService.GetAllThemes());
        }
    }
}
