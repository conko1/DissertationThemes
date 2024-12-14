using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Services;

namespace Api.Controllers
{
    [ApiController]
    public class SupervisorController : ControllerBase
    {
        private readonly ISupervisorService _supervisorService;

        public SupervisorController(ISupervisorService supervisorService)
        {
            _supervisorService = supervisorService;
        }
    }
}
