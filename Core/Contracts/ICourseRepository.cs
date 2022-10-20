namespace Core.Contracts
{
    /// <summary>
    /// Represent the interface for <see cref="Course.Course"/> implementation into db
    /// </summary>
    public interface ICourseRepository
    {
        /// <summary>
        /// Get all courses
        /// </summary>
        public IEnumerable<Course.Course> GetAll();

        /// <summary>
        /// Retrieve a course into db.
        /// </summary>
        /// <param name="course">An instance of <see cref="Course.Course"/></param>
        Task Persist(Course.Course course);
    }
}
