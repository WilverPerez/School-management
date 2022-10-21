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
        /// <param name="student">An instance of <see cref="Student.Student"/></param>
        public Task Persist(Student.Student student);

        /// <summary>
        /// Get all students
        /// </summary>
        public IEnumerable<Student.Student> GetAll();


        /// <summary>
        /// Get all students by list view
        /// </summary>
        public IEnumerable<Student.Student> GetList();

        /// <summary>
        /// Get all student by assignature
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="assignatureId"></param>
        /// <returns></returns>
        IEnumerable<Student.Student> GetByAssignature(Guid courseId, Guid assignatureId);
    }
}
