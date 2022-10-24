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
        IEnumerable<Student.Student> GetByAssignature(Guid courseId, Guid assignatureId);

        /// <summary>
        /// Get all students wo=ithout course
        /// </summary>
        IEnumerable<Student.Student> GetAllWithoutCourse();

        /// <summary>
        /// Get an student with score by assiganture
        /// </summary>
        /// <param name="student">An instance of <see cref="Student.Student"/></param>
        /// <returns>An instance of <see cref="Student.Student"/></returns>
        Task<Student.Student> GetWithScore(Student.Student student);
    }
}
