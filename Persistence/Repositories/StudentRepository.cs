using Core.Contracts;
using Core.Student;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    /// <summary>
    /// Implement all logic for manage student entity into db
    /// </summary>
    public sealed class StudentRepository : IStudentRepository
    {
        private readonly SqlContext _context;

        /// <summary>
        /// Implement an instance of <see cref="StudentRepository"/>
        /// </summary>
        public StudentRepository(SqlContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        async Task IStudentRepository.Persist(Student student)
        {
            Models.Student studentModel = Models.Student.FromEntity(student);

            studentModel.Assignatures = _context.Assignature.Where(asignature => studentModel.Assignatures.Select(assignature => assignature.Id).Contains(asignature.Id)).ToList();
            studentModel.Courses = _context.Course.Where(course => studentModel.Courses.Select(course => course.Id).Contains(course.Id)).ToList();
            Models.Parent parent = _context.Parent.FirstOrDefault(parent => parent.Email == studentModel.Parent.Email);

            if (parent != null)
            {
                studentModel.Parent = parent;
            }

            await _context.Student.AddAsync(studentModel);

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        IEnumerable<Student> IStudentRepository.GetAll()
        {
            IEnumerable<Models.Student> students = _context.Student;

            return students.Select(student => student.ToEntity());
        }

        /// <inheritdoc/>
        IEnumerable<Student> IStudentRepository.GetAllWithoutCourse()
        {
            IEnumerable<Models.Student> students = _context.Student
                                                            .AsNoTracking()
                                                            .Include(student => student.Courses)
                                                            .Where(student => !student.Courses.Any());

            return students.Select(student => student.ToEntity());
        }

        /// <inheritdoc/>
        IEnumerable<Student> IStudentRepository.GetList()
        {
            IEnumerable<Models.Student> students = _context.Student
                                                           .AsNoTracking()
                                                           .Include(student => student.Parent);

            return students.Select(student => student.ToEntity());
        }

        /// <inheritdoc/>
        IEnumerable<Student> IStudentRepository.GetByAssignature(Guid courseId, Guid assignatureId)
        {
            IEnumerable<Models.Student> students =  _context.Student
                                                            .AsNoTracking()
                                                            .Include(student => student.Assignatures)
                                                            .ThenInclude(student => student.Courses)
                                                            .Where(student => student.Assignatures.Any(assignature => assignature.Id == assignatureId && 
                                                                                                       assignature.Courses.Any(course => course.Id == courseId)));
            return students.Select(student => student.ToEntity());
        }

        /// <inheritdoc/>
        async Task<Student> IStudentRepository.GetWithScore(Student studentEntity)
        {
            Models.Student student = await _context.Student
                                                   .AsNoTracking()
                                                   .Include(student => student.Assignatures)
                                                   .Include(student => student.Scores)
                                                   .FirstOrDefaultAsync(student => student.Id == studentEntity.Id);

            return student.ToEntity();
        }
    }
}
