namespace School_management.Models.Student
{
    /// <summary>
    /// Represent the course view model
    /// </summary>
    public sealed class StudentScoreModel
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Represent the student's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Represent the student's last name
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Represent the student's full name
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Represent the student's assignatures
        /// </summary>
        public IEnumerable<Assignature.AssignatureScoreModel> Assignatures { get; set; } = Enumerable.Empty<Assignature.AssignatureScoreModel>();

        /// <summary>
        /// Map the entity core to entity db
        /// </summary>
        /// <param name="student">An instance of <see cref="Core.Student.Student"/></param>
        /// <returns>An instance of <see cref="StudentModel"/></returns>
        internal static StudentScoreModel FromEntity(Core.Student.Student student)
        {
            StudentScoreModel studentEntity = new StudentScoreModel
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Assignatures = student.Assignatures.Select(assignature => Assignature.AssignatureScoreModel.FromEntity(assignature, student)),
                FullName = $"{student.Name} {student.LastName}"
            };

            return studentEntity;
        }
    }
}
