namespace School_management.Models.Course
{
    /// <summary>
    /// Represent the course view model
    /// </summary>
    public sealed class CourseModel
    {
        /// <summary>
        /// Represent the course's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Represent the course's assignatures
        /// </summary>
        public IEnumerable<Models.Assignature.AssignatureListModel> Assignatures { get; set; } = new List<Models.Assignature.AssignatureListModel>();

        /// <summary>
        /// Represent the course's students
        /// </summary>
        public IEnumerable<Models.Student.StudentModel> Students { get; set; } = new List<Models.Student.StudentModel>();

        /// <summary>
        /// Represent the course's schedule
        /// </summary>
        public IEnumerable<Models.ScheduleModel> Schedules { get; set; } = new List<Models.ScheduleModel>();

        /// <summary>
        /// Map to <see cref="Core.Course.Course"/>
        /// </summary>
        /// <returns><see cref="Core.Course.Cours"/></returns>
        internal Core.Course.Course ToEntity()
        {
            Core.Course.Course course = new Core.Course.Course.Builder()
                                                              .WithId(Guid.NewGuid())
                                                              .WithName(Name)
                                                              .WithAssignatures(Assignatures.Select(assignature => assignature.ToEntity()))
                                                              .WithSchedules(Schedules.Select(schedule => schedule.ToEntity()))
                                                              .WithStudents(Students.Select(student => student.ToEntity()))
                                                              .Build();
            return course;
        }

        /// <summary>
        /// Map to <see cref="CourseModel"/>
        /// </summary>
        /// <returns><see cref="CourseModel"/></returns>
        internal static CourseModel FromEntity(Core.Course.Course courseEntity)
        {
            CourseModel courseModel = new CourseModel
            {
                Name = courseEntity.Name,
                Assignatures = courseEntity.Assignatures.Select(assignature => Models.Assignature.AssignatureListModel.FromEntity(assignature)),
                Students = courseEntity.Students.Select(student => Models.Student.StudentModel.FromEntity(student)),
            };

            return courseModel;
        }
    }
}
