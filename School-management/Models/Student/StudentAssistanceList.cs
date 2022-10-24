namespace School_management.Models.Student
{
    /// <summary>
    /// Represent the student with assignature list view model
    /// </summary>
    public sealed class StudentAssistanceList
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the student's full name
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Represent the student's assistance value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Map the <see cref="Assistance"/> to <see cref="StudentAssistanceList"/>
        /// </summary>
        /// <param name="assignature">An instance of <see cref="Assistance"/></param>
        /// <returns>An instance of <see cref="StudentAssistanceList"/></returns>
        internal static StudentAssistanceList FromEntity(Core.Assistance.Assistance assignature)
        {
            StudentAssistanceList studentAssistanceList = new StudentAssistanceList
            {
                Id = assignature.Id,
                FullName = $"{assignature.Student.Name} {assignature.Student.LastName}",
                Value = (int)assignature.Value
            };

            return studentAssistanceList;
        }

        /// <summary>
        /// Map the <see cref="Assistance"/> to <see cref="StudentAssistanceList"/>
        /// </summary>
        /// <param name="student">An instance of <see cref="Assistance"/></param>
        /// <returns>An instance of <see cref="StudentAssistanceList"/></returns>
        internal static StudentAssistanceList FromEntity(Core.Student.Student student)
        {
            StudentAssistanceList studentAssistanceList = new StudentAssistanceList
            {
                Id = student.Id,
                FullName = $"{student.Name} {student.LastName}"
            };

            return studentAssistanceList;
        }

        /// <summary>
        /// Map the <see cref="Core.Score.Score"/> to <see cref="StudentAssistanceList"/>
        /// </summary>
        /// <param name="score">An instance of <see cref="Core.Score.Score"/></param>
        /// <returns>An instance of <see cref="StudentAssistanceList"/></returns>
        internal static StudentAssistanceList FromEntity(Core.Score.Score score)
        {
            StudentAssistanceList studentAssistanceList = new StudentAssistanceList
            {
                Id = score.Id,
                FullName = $"{score.Student.Name} {score.Student.LastName}",
                Value = (int)score.Value
            };

            return studentAssistanceList;
        }
    }
}
