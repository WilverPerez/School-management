using Core.Enums;

namespace School_management.Models.Score
{
    /// <summary>
    /// Represent the score view model
    /// </summary>
    public sealed class ScoreModel
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the score's student
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// Represent the score's assignature
        /// </summary>
        public Guid AssignatureId { get; set; }

        /// <summary>
        /// Represent the score's course
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Represent the score's value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Represent the date issue.
        /// </summary>
        public DateTime DateIssue { get; set; }

        /// <summary>
        /// Map the entity db to entity core
        /// </summary>
        /// <returns>An instance of <see cref="Core.Assistance.Assistance"/></returns>
        internal Core.Score.Score ToEntity()
        {
            Models.Student.StudentModel studentModel = new Models.Student.StudentModel
            {
                Id = StudentId
            };

            Models.Course.CourseListModel courseModel = new Models.Course.CourseListModel
            {
                Id = CourseId
            };

            Models.Assignature.AssignatureListModel assignatureModel = new Models.Assignature.AssignatureListModel
            {
                Id = AssignatureId
            };

            Core.Score.Score score = new Core.Score.Score.Builder()
                                                         .WithId(Id)
                                                         .WithValue(Value)
                                                         .WithStudent(studentModel.ToEntity())
                                                         .WithCourse(courseModel.ToEntity())
                                                         .WithAssignature(assignatureModel.ToEntity())
                                                         .WithDateIssue(DateIssue)
                                                         .Build();
            return score;
        }

        /// <summary>
        /// Map to <see cref="Models.Score.ScoreModel"/>
        /// </summary>
        /// <param name="score"></param>
        /// <returns>An instance of <see cref="ScoreModel"/></returns>
        internal static ScoreModel FromEntity(Core.Score.Score score)
        {
            ScoreModel scoreModel = new ScoreModel
            {
                Id = score.Id,
                Value = score.Value,
            };

            return scoreModel;
        }
    }
}
