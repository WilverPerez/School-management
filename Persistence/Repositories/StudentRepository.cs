using Core.Contracts;
using Core.Student;

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
            await _context.SaveChangesAsync();
        }
    }
}
