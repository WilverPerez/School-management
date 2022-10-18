using Microsoft.AspNetCore.Mvc;

namespace School_management.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            Core.Student.Student student = new Core.Student.Student.Builder()
                                                                   .WithId(Guid.NewGuid())
                                                                   .WithName("Wilvel")
                                                                   .WithLastName("Perez")
                                                                   .WithDateOfBorn(DateTime.Now)
                                                                   .Build();

            return Ok(student);
        }
    }
}