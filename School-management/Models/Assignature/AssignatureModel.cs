namespace School_management.Models.Assignature
{
    /// <summary>
    /// Represent the assignature view model
    /// </summary>
    public sealed class AssignatureModel
    {
        /// <summary>
        /// Represent the assignature's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Represent the assignature's courses
        /// </summary>
        public IEnumerable<Models.Course.CourseListModel> Courses { get; set; } = Enumerable.Empty<Models.Course.CourseListModel>();

        /// <summary>
        /// Map to <see cref="Core.Assignature.Assignature"/>
        /// </summary>
        /// <returns><see cref="Core.Assignature.Assignature"/></returns>
        internal Core.Assignature.Assignature ToEntity()
        {
            Core.Assignature.Assignature assignature = new Core.Assignature.Assignature.Builder()
                                                                                       .WithId(Guid.NewGuid())
                                                                                       .WithName(Name)
                                                                                       .WithCourses(Courses.Select(course => course.ToEntity()))
                                                                                       .Build();
            return assignature;
        }
    }
}
