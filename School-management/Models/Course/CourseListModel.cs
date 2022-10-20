namespace School_management.Models.Course
{
    /// <summary>
    /// Represent the course view model
    /// </summary>
    public sealed class CourseListModel
    {
        /// <summary>
        /// Represent the course's name
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the course's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Represent the course's student count
        /// </summary>
        public int StudentCount { get; set; }

        /// <summary>
        /// Represent the course's assignature count
        /// </summary>
        public int AssignatureCount { get; set; }

        /// <summary>
        /// Represent the course's schedule name
        /// </summary>
        public string Schedule { get; set; } = string.Empty;

        /// <summary>
        /// Map to <see cref="CourseListModel"/>
        /// </summary>
        /// <param name="course">Represent an <see cref="Core.Course.Course"/></param>
        /// <returns><see cref="CourseListModel"/></returns>
        internal static CourseListModel FromEntity(Core.Course.Course course)
        {
            CourseListModel courseListModel = new CourseListModel
            {
                Id = course.Id,
                Name = course.Name,
                StudentCount = course.Students.Count(),
                AssignatureCount = course.Assignatures.Count(),
                Schedule = BuildScheduleString(course)
            };
            
            return courseListModel;
        }

        /// <summary>
        /// Map to <see cref="Core.Course.Course"/>
        /// </summary>
        /// <returns><see cref="Core.Course.Course"/></returns>
        internal Core.Course.Course ToEntity()
        {
            Core.Course.Course course = new Core.Course.Course.Builder()
                                                              .WithId(Id)
                                                              .WithName(Name)
                                                              .Build();
            return course;
        }

        private static string BuildScheduleString(Core.Course.Course course)
        {
            List<string> schedules = course.Schedules.Select(schedule => schedule.Name.Substring(0, 3)).ToList();

            return String.Join(", ", schedules);
        }
    }
}
