using Microsoft.AspNetCore.Mvc;

namespace School_management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CreateStudent()
        {
            Core.Student.Student student = new Core.Student.Student.Builder()
                                                                   .WithId(Guid.NewGuid())
                                                                   .WithName("Wilvel")
                                                                   .WithLastName("Perez")
                                                                   .WithDateOfBorn(DateTime.Now)
                                                                   .Build();

            student.Persist();

            return Ok(student);
        }
    }
}