using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Services;

namespace Api.Controllers
{
    [ApiController]
    public class StProgramController : ControllerBase
    {
        private readonly IStProgramService _stProgramService;

        public StProgramController(IStProgramService stProgramService)
        {
            _stProgramService = stProgramService;
        }
    }
}
