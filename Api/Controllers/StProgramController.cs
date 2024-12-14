using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Entity;
using SharedLibrary.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/st-program")]
    public class StProgramController : ControllerBase
    {
        private readonly IStProgramService _stProgramService;

        public StProgramController(IStProgramService stProgramService)
        {
            _stProgramService = stProgramService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StProgram>>> GetAllStPrograms()
        {
            return Ok(await _stProgramService.GetAllStPrograms());
        }
    }
}
