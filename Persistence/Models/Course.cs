using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    /// <summary>
    /// Represent the course table into db
    /// </summary>
    public sealed class Course
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the course's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Represent the course's creation date
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Represent the course's assignatures
        /// </summary>
        public IEnumerable<Assignature> Assignatures { get; set; } = new List<Assignature>();

        /// <summary>
        /// Represent the course's students
        /// </summary>
        public IEnumerable<Student> Students { get; set; } = new List<Student>();

        /// <summary>
        /// Represent the course's students
        /// </summary>
        public IEnumerable<Schedule> Schedules { get; set; } = new List<Schedule>();

        /// <summary>
        /// Map the entity db to entity core
        /// </summary>
        /// <returns>An instance of <see cref="Core.Course.Course"/></returns>
        internal Core.Course.Course ToEntity()
        {
            Core.Course.Course course = new Core.Course.Course.Builder()
                                                              .WithId(Id)
                                                              .WithName(Name)
                                                              .WithSchedules(Schedules.Select(schedule => schedule.ToEntity()))
                                                              .WithStudents(Students.Select(student => student.ToEntity()))
                                                              .WithAssignatures(Assignatures.Select(assignature => assignature.ToEntity()))
                                                              .Build();
            return course;
        }

        /// <summary>
        /// Map the entity core to entity db
        /// </summary>
        /// <returns>An instance of <see cref="Course"/></returns>
        internal static Course FromEntity(Core.Course.Course course)
        {
            Course assignatureEntity = new Course
            {
                Id = course.Id,
                Name = course.Name
            };

            if (course.Assignatures != null)
            {
                assignatureEntity.Assignatures = course.Assignatures.Select(asignature => Assignature.FromEntity(asignature));
            }

            if (course.Schedules != null)
            {
                assignatureEntity.Schedules = course.Schedules.Select(schedule => Schedule.FromEntity(schedule));
            }

            if (course.Students != null)
            {
                assignatureEntity.Students = course.Students.Select(student => Student.FromEntity(student));
            }

            return assignatureEntity;
        }
    }
}
