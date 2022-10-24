using Core.Contracts;
using Core.Course;
using Microsoft.EntityFrameworkCore;

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
            IEnumerable<Models.Course> courses = _context.Course.AsNoTracking()
                                                                .Include(course => course.Students)
                                                                .Include(course => course.Assignatures)
                                                                .Include(course => course.Schedules);

            IEnumerable<Course> courseEntities = courses.Select(course => course.ToEntity());

            return courseEntities;
        }

        /// <inheritdoc/>
        async Task ICourseRepository.Persist(Course course)
        {
            Models.Course courseEntity = Models.Course.FromEntity(course);

            courseEntity.Assignatures = _context.Assignature.Where(asignature => courseEntity.Assignatures.Select(assignature => assignature.Id).Contains(asignature.Id)).ToList();
            courseEntity.Schedules = _context.Schedule.Where(course => courseEntity.Schedules.Select(course => course.Id).Contains(course.Id)).ToList();
            courseEntity.Students = _context.Student.Where(course => courseEntity.Students.Select(course => course.Id).Contains(course.Id)).ToList();

            foreach (var assignature in courseEntity.Assignatures)
            {
                assignature.Students.AddRange(courseEntity.Students);
            }

            await _context.Course.AddAsync(courseEntity);

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        Course ICourseRepository.GetById(Guid id)
        {
            Models.Course course = _context.Course
                                           .AsNoTracking()
                                           .Include(course => course.Assignatures)
                                           .Include(course => course.Students)
                                           .ThenInclude(course => course.Parent)
                                           .FirstOrDefault(course => course.Id == id);

            return course.ToEntity();
        }

        /// <inheritdoc/>
        async Task ICourseRepository.Update(Course course)
        {
            Models.Course courseEntity = Models.Course.FromEntity(course);

            Models.Course courseUpdate = await _context.Course.FirstOrDefaultAsync(course => course.Id == courseEntity.Id);

            courseUpdate.Map(courseEntity);

            _context.Course.Update(courseUpdate);

            await _context.SaveChangesAsync();
        }
    }
}
