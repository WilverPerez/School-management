using Microsoft.AspNetCore.Mvc;

namespace School_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignatureController : ControllerBase
    {
        private readonly ILogger<AssignatureController> _logger;

        public AssignatureController(ILogger<AssignatureController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateAssignature()
        {
            return Ok();
        }
    }
}