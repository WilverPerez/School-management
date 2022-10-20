using Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using School_management.Models.Course;

namespace School_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        /// <summary>
        /// Create a course
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAssignature([FromBody] CourseModel course)
        {
            Core.Course.Course courseEntity = course.ToEntity();

            await courseEntity.Persist(_courseRepository);

            return Ok();
        }

        /// <summary>
        /// Get a list of courses
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Core.Course.Course> courseEntities = Core.Course.Course.GetAll(_courseRepository);

            IEnumerable<CourseListModel> courses = courseEntities.Select(course => CourseListModel.FromEntity(course));

            return Ok(courses);
        }
    }
}