using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    /// <summary>
    /// Represent the assistance table into db
    /// </summary>
    public sealed class Assistance
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the assistance's student
        /// </summary>
        public Student Student { get; set; } = new Student();

        /// <summary>
        /// Represent the assistance's assignature
        /// </summary>
        public Assignature Assignature { get; set; } = new Assignature();

        /// <summary>
        /// Represent the assistance's course
        /// </summary>
        public Course Course { get; set; } = new Course();

        /// <summary>
        /// Represent the assistance's value
        /// </summary>
        public AssistanceValue Value { get; set; }

        /// <summary>
        /// Represent the date issue.
        /// </summary>
        public DateTime DateIssue { get; set; }

        /// <summary>
        /// Represent the creatiion date.
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Map the entity db to entity core
        /// </summary>
        /// <returns>An instance of <see cref="Core.Assistance.Assistance"/></returns>
        internal Core.Assistance.Assistance ToEntity()
        {
            Core.Assistance.Assistance assistance = new Core.Assistance.Assistance.Builder()
                                                                                  .WithId(Id)
                                                                                  .WithValue(Value)
                                                                                  .WithStudent(Student.ToEntity())
                                                                                  .WithCourse(Course.ToEntity())
                                                                                  .WithAssignature(Assignature.ToEntity())
                                                                                  .Build();
            return assistance;
        }

        /// <summary>
        /// Map the entity core to entity db
        /// </summary>
        /// <returns>An instance of <see cref="Assistance"/></returns>
        internal static Assistance FromEntity(Core.Assistance.Assistance assistance)
        {
            Assistance assignatureEntity = new Assistance
            {
                Id = assistance.Id,
                Student = Models.Student.FromEntity(assistance.Student),
                Assignature = Models.Assignature.FromEntity(assistance.Assignature),
                Course = Models.Course.FromEntity(assistance.Course),
                Value = assistance.Value,
                DateIssue = assistance.DateIssue
            };

            return assignatureEntity;
        }
    }
}
