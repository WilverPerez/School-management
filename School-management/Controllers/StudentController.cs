using Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace School_management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentRepository _studentRepository;

        public StudentController(ILogger<StudentController> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
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

            student.Persist(_studentRepository);

            return Ok(student);
        }
    }
}