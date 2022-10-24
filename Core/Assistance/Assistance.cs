using Core.Contracts;
using Core.Enums;

namespace Core.Assistance
{
    /// <summary>
    /// Represent the assistance entity logic manager
    /// </summary>
    public sealed class Assistance
    {
        private Assistance(Builder builder)
        {
            Id = builder.IdOption;
            Value = builder.ValueOption;
            Student = builder.StudentOption;
            Course = builder.CourseOption;
            Assignature = builder.AssignatureOption;
            DateIssue = builder.DateIssueOption;
        }

        #region props

        /// <summary>
        /// Represent the identification code
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Represent the assistance's value
        /// </summary>
        public AssistanceValue Value { get; }

        /// <summary>
        /// Represent the assistance's student
        /// </summary>
        public Student.Student Student { get; }

        /// <summary>
        /// Represent the assistance's assignature
        /// </summary>
        public Assignature.Assignature Assignature { get; }

        /// <summary>
        /// Represent the assistance's course
        /// </summary>
        public Course.Course Course { get; }

        /// <summary>
        /// Represent the assistance's date issue.
        /// </summary>
        public DateTime DateIssue { get; }

        #endregion

        /// <summary>
        /// Persist assistance data.
        /// </summary>
        /// <param name="assistanceRepository">Implement an instance of <see cref="IAssistanceRepository"/></param>
        public static async Task Persist(IAssistanceRepository assistanceRepository, IEnumerable<Assistance> assistances)
        {
            await assistanceRepository.PersistRange(assistances);
        }

        /// <summary>
        /// update assistance data.
        /// </summary>
        /// <param name="assignatureRepository">Implement an instance of <see cref="IAssistanceRepository"/></param>
        public async Task Update(IAssistanceRepository assistanceRepository)
        {
            await assistanceRepository.Update(this);
        }

        /// <summary>
        /// Get all assistances by date
        /// </summary>
        /// <param name="assignatureRepository">An instance of <see cref="IAssistanceRepository"/></param>
        /// <param name="courseId">Represent the course identification</param>
        /// <param name="assignatureId">Represent the assignature identification</param>
        /// <returns>An instance of <see cref="IEnumerable{Assistance}"/></returns>
        public IEnumerable<Assistance> GetByDate(IAssistanceRepository assignatureRepository, Guid courseId, Guid assignatureId)
        {
            return assignatureRepository.GetByDate(DateIssue, assignatureId, courseId);
        }

        /// <summary>
        /// Class to build an <see cref="Assistance"/> instance
        /// </summary>
        public class Builder {
            internal Guid IdOption { get; set; }
            internal DateTime DateIssueOption { get; set; }
            internal Student.Student StudentOption { get; set; }
            internal Course.Course CourseOption { get; set; }
            internal Assignature.Assignature AssignatureOption { get; set; }
            internal AssistanceValue ValueOption { get; set; }

            /// <summary>
            /// Implement an instance of <see cref="Builder"/>
            /// </summary>
            public Assistance Build()
            {
                return new Assistance(this);
            }

            #region With methods

            /// <summary>
            /// Set the <see cref="Id"/> property
            /// </summary>
            /// <param name="id"><see cref="Guid"/></param>
            public Builder WithId(Guid id) => SetProperty(() => IdOption = id);

            /// <summary>
            /// Set the <see cref="Value"/> property
            /// </summary>
            /// <param name="value"><see cref="AssistanceValue"/></param>
            public Builder WithValue(AssistanceValue value) => SetProperty(() => ValueOption = value);

            /// <summary>
            /// Set the <see cref="Student"/> property
            /// </summary>
            /// <param name="student"><see cref="Student.Student"/></param>
            public Builder WithStudent(Student.Student student) => SetProperty(() => StudentOption = student);

            /// <summary>
            /// Set the <see cref="Course"/> property
            /// </summary>
            /// <param name="course"><see cref="Course.Course"/></param>
            public Builder WithCourse(Course.Course course) => SetProperty(() => CourseOption = course);

            /// <summary>
            /// Set the <see cref="Assignature"/> property
            /// </summary>
            /// <param name="assignature"><see cref="Assignature.Assignature"/></param>
            public Builder WithAssignature(Assignature.Assignature assignature) => SetProperty(() => AssignatureOption = assignature);

            /// <summary>
            /// Set the <see cref="DateIssue"/> property
            /// </summary>
            /// <param name="dateIssue"><see cref="DateTime"/></param>
            public Builder WithDateIssue(DateTime dateIssue) => SetProperty(() => DateIssueOption = dateIssue);

            #endregion

            private Builder SetProperty<T>(Func<T> argument)
            {
                argument();
                return this;
            }

        }
    }
}