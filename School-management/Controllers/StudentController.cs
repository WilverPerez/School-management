using Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using School_management.Models.Student;

namespace School_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        /// <summary>
        /// Implement an instance of <see cref="StudentController"/>
        /// </summary>
        /// <param name="studentRepository">Implement an instance of <see cref="IStudentRepository"/></param>
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Persist a student
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentModel student)
        {
            Core.Student.Student studentEntity = student.ToEntity();

            await studentEntity.Persist(_studentRepository);

            return Ok();
        }

        /// <summary>
        /// get all students
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Core.Student.Student> students = Core.Student.Student.GetAll(_studentRepository);

            IEnumerable<Models.Student.StudentModel> studentsModel = students.Select(student => Models.Student.StudentModel.FromEntity(student));

            return Ok(studentsModel);
        }

        /// <summary>
        /// get all students without course
        /// </summary>
        [HttpGet("without-course")]
        public async Task<IActionResult> GetAllWithoutCourse()
        {
            IEnumerable<Core.Student.Student> students = Core.Student.Student.GetAllWithoutCourse(_studentRepository);

            IEnumerable<Models.Student.StudentModel> studentsModel = students.Select(student => Models.Student.StudentModel.FromEntity(student));

            return Ok(studentsModel);
        }

        /// <summary>
        /// get all students
        /// </summary>
        [HttpGet("by-assignature")]
        public async Task<IActionResult> GetByAssignature([FromQuery] Guid courseId, [FromQuery] Guid assignatureId)
        {
            IEnumerable<Core.Student.Student> students = Core.Student.Student.GetByAssignature(_studentRepository, courseId, assignatureId);

            IEnumerable<Models.Student.StudentAssistanceList> studentsModel = students.Select(student => Models.Student.StudentAssistanceList.FromEntity(student));

            return Ok(studentsModel);
        }

        /// <summary>
        /// Get student by score
        /// </summary>
        [HttpGet("by-score")]
        public async Task<IActionResult> GetByScore([FromQuery] Guid studentId)
        {
            Core.Student.Student student = new Core.Student.Student.Builder()
                                                                   .WithId(studentId)
                                                                   .Build();

            student = await student.GetWithScore(_studentRepository);

            Models.Student.StudentScoreModel studentModel = Models.Student.StudentScoreModel.FromEntity(student);

            return Ok(studentModel);
        }
    }
}