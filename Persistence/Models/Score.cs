using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    /// <summary>
    /// Represent the score table into db
    /// </summary>
    public sealed class Score
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the score's student
        /// </summary>
        public Student Student { get; set; } = new Student();

        /// <summary>
        /// Represent the score's assignature
        /// </summary>
        public Assignature Assignature { get; set; } = new Assignature();

        /// <summary>
        /// Represent the score's course
        /// </summary>
        public Course Course { get; set; } = new Course();

        /// <summary>
        /// Represent the score's value
        /// </summary>
        public int Value { get; set; }

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
        /// <returns>An instance of <see cref="Core.Score.Score"/></returns>
        internal Core.Score.Score ToEntity()
        {
            Core.Score.Score score = new Core.Score.Score.Builder()
                                                                                  .WithId(Id)
                                                                                  .WithValue(Value)
                                                                                  .WithStudent(Student.ToEntity())
                                                                                  .WithCourse(Course.ToEntity())
                                                                                  .WithAssignature(Assignature.ToEntity())
                                                                                  .Build();
            return score;
        }

        /// <summary>
        /// Map the entity core to entity db
        /// </summary>
        /// <returns>An instance of <see cref="Score"/></returns>
        internal static Score FromEntity(Core.Score.Score score)
        {
            Score assignatureEntity = new Score
            {
                Id = score.Id,
                Student = Models.Student.FromEntity(score.Student),
                Assignature = Models.Assignature.FromEntity(score.Assignature),
                Course = Models.Course.FromEntity(score.Course),
                Value = score.Value,
                DateIssue = score.DateIssue
            };

            return assignatureEntity;
        }
    }
}
