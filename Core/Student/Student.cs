using Core.Contracts;

namespace Core.Student
{
    /// <summary>
    /// Represent the student entity logic manager
    /// </summary>
    public sealed class Student
    {
        private Student(Builder builder)
        {
            Id = builder.IdOption;
            Name = builder.NameOption;
            LastName = builder.LastNameOption;
            DateOfBorn = builder.DateOfBornOption;
            Parent = builder.ParentOption;
            Courses = builder.CoursesOption;
            Assignatures = builder.AssignaturesOption;
        }

        #region props

        /// <summary>
        /// Represent the identification code
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Represent the student's name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Represent the student's lastname
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Represent the date of born
        /// </summary>
        public DateTime DateOfBorn { get; }

        /// <summary>
        /// Represent the parent associate to student
        /// </summary>
        public Parent Parent { get; }

        /// <summary>
        /// Represent a list of courses
        /// </summary>
        public IEnumerable<string> Courses { get; }

        /// <summary>
        /// Represent a list of assignatures
        /// </summary>
        public IEnumerable<string> Assignatures { get; }


        #endregion

        public void Persist(IStudentRepository studentRepository)
        {
            studentRepository.Persist(this);
        }

        /// <summary>
        /// Class to build an <see cref="Student"/> instance
        /// </summary>
        public class Builder {
            internal Guid IdOption { get; set; }
            internal string NameOption { get; set; } = string.Empty;
            internal string LastNameOption { get; set; } = string.Empty;
            internal DateTime DateOfBornOption { get; set; }
            internal Parent ParentOption { get; set; } = new Parent();
            internal IEnumerable<string> CoursesOption { get; set; } = new List<string>();
            internal IEnumerable<string> AssignaturesOption { get; set; } = new List<string>();

            /// <summary>
            /// Implement an instance of <see cref="Builder"/>
            /// </summary>
            public Student Build()
            {
                return new Student(this);
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
            /// Set the <see cref="LastName"/> property
            /// </summary>
            /// <param name="lastName"><see cref="string"/></param>
            public Builder WithLastName(string lastName) => SetProperty(() => LastNameOption = lastName);

            /// <summary>
            /// Set the <see cref="DateOfBorn"/> property
            /// </summary>
            /// <param name="date"><see cref="DateTime"/></param>
            public Builder WithDateOfBorn(DateTime date) => SetProperty(() => DateOfBornOption = date);

            /// <summary>
            /// Set the <see cref="Parent"/> property
            /// </summary>
            /// <param name="parent"><see cref="Parent"/></param>
            public Builder WithParent(Parent parent) => SetProperty(() => ParentOption = parent);

            /// <summary>
            /// Set the <see cref="Courses"/> property
            /// </summary>
            /// <param name="courses"><see cref="IEnumerable{string}"/></param>
            public Builder WithCourses(IEnumerable<string> courses) => SetProperty(() => CoursesOption = courses);

            /// <summary>
            /// Set the <see cref="Assignatures"/> property
            /// </summary>
            /// <param name="assignatures"><see cref="IEnumerable{string}"/></param>
            public Builder WithAssignatures(IEnumerable<string> assignatures) => SetProperty(() => AssignaturesOption = assignatures);

            #endregion

            private Builder SetProperty<T>(Func<T> argument)
            {
                argument();
                return this;
            }

        }
    }
}