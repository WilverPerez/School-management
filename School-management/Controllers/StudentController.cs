using Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace School_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return Ok();
        }
    }
}