using Core.Contracts;

namespace Core.Course
{
    /// <summary>
    /// Represent the course entity logic manager
    /// </summary>
    public sealed class Course
    {
        private Course(Builder builder)
        {
            Id = builder.IdOption;
            Name = builder.NameOption;
            Students = builder.StudentsOption;
            Assignatures = builder.AssignaturesOption;
            Schedules = builder.SchedulesOption;
        }

        #region props

        /// <summary>
        /// Represent the identification code
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Represent the course's name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Represent the course's students
        /// </summary>
        public IEnumerable<Student.Student> Students { get; }

        /// <summary>
        /// Represent the course's assignatures
        /// </summary>
        public IEnumerable<Assignature.Assignature> Assignatures { get; }

        /// <summary>
        /// Represent the course's schedules
        /// </summary>
        public IEnumerable<Schedule.Schedule> Schedules { get; }

        #endregion

        /// <summary>
        /// Get all courses
        /// </summary>
        /// <param name="courseRepository">An instance of <see cref="ICourseRepository"/></param>
        /// <returns>An instance of <see cref="Course"/></returns>
        public static IEnumerable<Course> GetAll(ICourseRepository courseRepository)
        {
            return courseRepository.GetAll();
        }

        /// <summary>
        /// Retrieve a course into db.
        /// </summary>
        /// <param name="courseRepository">An instance of <see cref="ICourseRepository"/></param>
        public async Task Persist(ICourseRepository courseRepository)
        {
            await courseRepository.Persist(this);
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="courseRepository">An instance of <see cref="ICourseRepository"/></param>
        /// <returns>An instance of <see cref="Course"/></returns>
        public Course Get(ICourseRepository courseRepository)
        {
            return courseRepository.GetById(Id);
        }

        /// <summary>
        /// Update a course
        /// </summary>
        /// <param name="courseRepository">An instance of <see cref="ICourseRepository"/></param>
        public async Task Update(ICourseRepository courseRepository)
        {
            await courseRepository.Update(this);
        }

        /// <summary>
        /// Class to build an <see cref="Course"/> instance
        /// </summary>
        public class Builder {
            internal Guid IdOption { get; set; }
            internal string NameOption { get; set; } = string.Empty;
            internal DateTime DateOfBornOption { get; set; }
            internal IEnumerable<Student.Student> StudentsOption { get; set; }
            internal IEnumerable<Schedule.Schedule> SchedulesOption { get; set; }
            internal IEnumerable<Assignature.Assignature> AssignaturesOption { get; set; }

            /// <summary>
            /// Implement an instance of <see cref="Builder"/>
            /// </summary>
            public Course Build()
            {
                return new Course(this);
            }

            #region With methods

            /// <summary>
            /// Set the <see cref="Id"/> property
            /// </summary>
            /// <param name="id"><see cref="Guid"/></param>
            public Builder WithId(Guid id) => SetProperty(() => IdOption = id);

            /// <summary>
            /// Set the <see cref="Name"/> property
            /// </summary>
            /// <param name="name"><see cref="string"/></param>
            public Builder WithName(string name) => SetProperty(() => NameOption = name);

            /// <summary>
            /// Set the <see cref="StudentsOption"/> property
            /// </summary>
            /// <param name="students"><see cref="IEnumerable{Student.Student}"/></param>
            public Builder WithStudents(IEnumerable<Student.Student> students) => SetProperty(() => StudentsOption = students);

            /// <summary>
            /// Set the <see cref="SchedulesOption"/> property
            /// </summary>
            /// <param name="schedules"><see cref="IEnumerable{Student.Student}"/></param>
            public Builder WithSchedules(IEnumerable<Schedule.Schedule> schedules) => SetProperty(() => SchedulesOption = schedules);

            /// <summary>
            /// Set the <see cref="AssignaturesOption"/> property
            /// </summary>
            /// <param name="assignatures"><see cref="IEnumerable{Assignature.Assignature}"/></param>
            public Builder WithAssignatures(IEnumerable<Assignature.Assignature> assignatures) => SetProperty(() => AssignaturesOption = assignatures);

            #endregion

            private Builder SetProperty<T>(Func<T> argument)
            {
                argument();
                return this;
            }

        }
    }
}