namespace School_management.Models.Assignature
{
    /// <summary>
    /// Represent the assignature with score view model
    /// </summary>
    public sealed class AssignatureScoreModel
    {
        /// <summary>
        /// Represent the assignature's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Represent the assignature's courses
        /// </summary>
        public Models.Score.ScoreModel Score { get; set; } = new Models.Score.ScoreModel();

        /// <summary>
        /// Map to <see cref="Models.Score.ScoreModel"/>
        /// </summary>
        /// <param name="assignatureCore">Represent the user identification</param>
        /// <param name="student">An instance of <see cref="Core.Student.Student"/></param>
        /// <returns>An instance of <see cref="AssignatureListModel"/></returns>
        internal static AssignatureScoreModel FromEntity(Core.Assignature.Assignature assignatureCore, Core.Student.Student student)
        {
            AssignatureScoreModel assignature = new AssignatureScoreModel
            {
                Name = assignatureCore.Name,
                Score = Models.Score.ScoreModel.FromEntity(student.Scores.First())
            };

            return assignature;
        }
    }
}
