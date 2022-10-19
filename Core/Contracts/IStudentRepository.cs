namespace Core.Contracts
{
    /// <summary>
    /// Represent the interface for <see cref="Student.Student"/> implementation into db
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// retrieve a student into db
        /// </summary>
        /// <param name="student"></param>
        public Task Persist(Student.Student student);

        /// <summary>
        /// Get all students
        /// </summary>
        public IEnumerable<Student.Student> GetAll();
    }
}
