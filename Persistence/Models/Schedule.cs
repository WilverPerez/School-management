using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    /// <summary>
    /// Represent the schedule table into db
    /// </summary>
    public sealed class Schedule
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the schedule's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Represent the schedule's creation date
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Represent the schedule's courses
        /// </summary>
        public IEnumerable<Course> Courses { get; set; } = new List<Course>();

        /// <summary>
        /// Map the entity db to entity core
        /// </summary>
        /// <returns>An instance of <see cref="Core.Schedule.Schedule"/></returns>
        internal Core.Schedule.Schedule ToEntity()
        {
            Core.Schedule.Schedule schedule = new Core.Schedule.Schedule.Builder()
                                                                        .WithId(Id)
                                                                        .WithName(Name)
                                                                        .Build();
            return schedule;
        }

        /// <summary>
        /// Map the entity core to entity db.
        /// </summary>
        /// <param name="schedule">An instance of <see cref="Core.Schedule.Schedule"/></param>
        /// <returns>An instance of <see cref="Core.Schedule.Schedule"/></returns>
        internal static Schedule FromEntity(Core.Schedule.Schedule schedule)
        {
            Schedule scheduleEntity = new Schedule
            {
                Id = schedule.Id,
                Name = schedule.Name
            };

            return scheduleEntity;
        }
    }
}
