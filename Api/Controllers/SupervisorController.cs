using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Entity;
using SharedLibrary.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/supervisor")]
    public class SupervisorController : ControllerBase
    {
        private readonly ISupervisorService _supervisorService;

        public SupervisorController(ISupervisorService supervisorService)
        {
            _supervisorService = supervisorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StProgram>>> GetAllSupervisors()
        {
            return Ok(await _supervisorService.GetAllSupervisors());
        }
    }
}
