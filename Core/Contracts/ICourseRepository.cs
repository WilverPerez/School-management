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
    }
}
