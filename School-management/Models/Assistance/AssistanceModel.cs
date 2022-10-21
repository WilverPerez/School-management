using Core.Enums;

namespace School_management.Models.Assistance
{
    /// <summary>
    /// Represent the assistance view model
    /// </summary>
    public sealed class AssistanceModel
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the assistance's student
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// Represent the assistance's assignature
        /// </summary>
        public Guid AssignatureId { get; set; }

        /// <summary>
        /// Represent the assistance's course
        /// </summary>
        public Guid CourseId { get; set; }

        /// <summary>
        /// Represent the assistance's value
        /// </summary>
        public AssistanceValue Value { get; set; }

        /// <summary>
        /// Represent the date issue.
        /// </summary>
        public DateTime DateIssue { get; set; }

        /// <summary>
        /// Map the entity db to entity core
        /// </summary>
        /// <returns>An instance of <see cref="Core.Assistance.Assistance"/></returns>
        internal Core.Assistance.Assistance ToEntity()
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

            Core.Assistance.Assistance assistance = new Core.Assistance.Assistance.Builder()
                                                                                  .WithId(Id)
                                                                                  .WithValue(Value)
                                                                                  .WithStudent(studentModel.ToEntity())
                                                                                  .WithCourse(courseModel.ToEntity())
                                                                                  .WithAssignature(assignatureModel.ToEntity())
                                                                                  .WithDateIssue(DateIssue)
                                                                                  .Build();
            return assistance;
        }
    }
}
