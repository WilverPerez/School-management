using Core.Contracts;

namespace Core.Assignature
{
    /// <summary>
    /// Represent the assignature entity logic manager
    /// </summary>
    public sealed class Assignature
    {
        private Assignature(Builder builder)
        {
            Id = builder.IdOption;
            Name = builder.NameOption;
            Students = builder.StudentsOption;
            Courses = builder.CoursesOption;
        }

        #region props

        /// <summary>
        /// Represent the identification code
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Represent the assignature's name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Represent the assignature's students
        /// </summary>
        public IEnumerable<Student.Student> Students { get; }

        /// <summary>
        /// Represent the assignature's courses
        /// </summary>
        public IEnumerable<Course.Course> Courses { get; }

        public async Task Persist(IAssignatureRepository assignatureRepository)
        {
            await assignatureRepository.Persist(this);
        }

        #endregion

        /// <summary>
        /// Get all assignatures
        /// </summary>
        /// <param name="assignatureRepository">An instance of <see cref="IAssignatureRepository"/></param>
        /// <returns>An instance of <see cref="Assignature"/></returns>
        public static IEnumerable<Assignature> GetAll(IAssignatureRepository assignatureRepository)
        {
            return assignatureRepository.GetAll();
        }

        /// <summary>
        /// Class to build an <see cref="Assignature"/> instance
        /// </summary>
        public class Builder {
            internal Guid IdOption { get; set; }
            internal string NameOption { get; set; } = string.Empty;
            internal DateTime DateOfBornOption { get; set; }
            internal IEnumerable<Student.Student> StudentsOption { get; set; }
            internal IEnumerable<Course.Course> CoursesOption { get; set; }

            /// <summary>
            /// Implement an instance of <see cref="Builder"/>
            /// </summary>
            public Assignature Build()
            {
                return new Assignature(this);
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
            /// Set the <see cref="CoursesOption"/> property
            /// </summary>
            /// <param name="courses"><see cref="IEnumerable{Course.Course}"/></param>
            public Builder WithCourses(IEnumerable<Course.Course> courses) => SetProperty(() => CoursesOption = courses);

            #endregion

            private Builder SetProperty<T>(Func<T> argument)
            {
                argument();
                return this;
            }

        }
    }
}