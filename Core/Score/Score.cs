using Core.Contracts;
using Core.Enums;

namespace Core.Score
{
    /// <summary>
    /// Represent the score entity logic manager
    /// </summary>
    public sealed class Score
    {
        private Score(Builder builder)
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
        /// Represent the score's value
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Represent the score's student
        /// </summary>
        public Student.Student Student { get; }

        /// <summary>
        /// Represent the score's assignature
        /// </summary>
        public Assignature.Assignature Assignature { get; }

        /// <summary>
        /// Represent the score's course
        /// </summary>
        public Course.Course Course { get; }

        /// <summary>
        /// Represent the score's date issue.
        /// </summary>
        public DateTime DateIssue { get; }

        #endregion

        /// <summary>
        /// Persist score data.
        /// </summary>
        /// <param name="scoreRepository">Implement an instance of <see cref="IScoreRepository"/></param>
        public static async Task Persist(IScoreRepository scoreRepository, IEnumerable<Score> assistances)
        {
            await scoreRepository.PersistRange(assistances);
        }

        /// <summary>
        /// update score data.
        /// </summary>
        /// <param name="assignatureRepository">Implement an instance of <see cref="IScoreRepository"/></param>
        public async Task Update(IScoreRepository scoreRepository)
        {
            await scoreRepository.Update(this);
        }

        /// <summary>
        /// Get all assistances by date
        /// </summary>
        /// <param name="assignatureRepository">An instance of <see cref="IScoreRepository"/></param>
        /// <param name="courseId">Represent the course identification</param>
        /// <param name="assignatureId">Represent the assignature identification</param>
        /// <returns>An instance of <see cref="IEnumerable{Score}"/></returns>
        public static IEnumerable<Score> GetByDate(IScoreRepository assignatureRepository, Guid courseId, Guid assignatureId)
        {
            return assignatureRepository.GetByAssignature(assignatureId, courseId);
        }

        /// <summary>
        /// Class to build an <see cref="Score"/> instance
        /// </summary>
        public class Builder {
            internal Guid IdOption { get; set; }
            internal DateTime DateIssueOption { get; set; }
            internal Student.Student StudentOption { get; set; }
            internal Course.Course CourseOption { get; set; }
            internal Assignature.Assignature AssignatureOption { get; set; }
            internal int ValueOption { get; set; }

            /// <summary>
            /// Implement an instance of <see cref="Builder"/>
            /// </summary>
            public Score Build()
            {
                return new Score(this);
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
            /// <param name="value"><see cref="int"/></param>
            public Builder WithValue(int value) => SetProperty(() => ValueOption = value);

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