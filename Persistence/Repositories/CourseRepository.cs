using Core.Contracts;
using Core.Course;
using Core.Schedule;

namespace Persistence.Repositories
{
    /// <summary>
    /// Implement all logic for manage course entity into db
    /// </summary>
    public sealed class CourseRepository : ICourseRepository
    {
        private readonly SqlContext _context;

        /// <summary>
        /// Implement an instance of <see cref="CourseRepository"/>
        /// </summary>
        public CourseRepository(SqlContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        IEnumerable<Course> ICourseRepository.GetAll()
        {
            IEnumerable<Models.Course> courses = _context.Course;

            IEnumerable<Course> courseEntities = courses.Select(course => course.ToEntity());

            return courseEntities;
        }
    }
}
