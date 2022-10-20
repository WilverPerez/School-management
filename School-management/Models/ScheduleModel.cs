using Core.Schedule;

namespace School_management.Models
{
    /// <summary>
    /// Represent the schedule view model
    /// </summary>
    public sealed class ScheduleModel
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the schedule's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Map to <see cref="Core.Schedule.Schedule"/>
        /// </summary>
        internal Schedule ToEntity()
        {
            Core.Schedule.Schedule schedule = new Core.Schedule.Schedule.Builder()
                                                                        .WithId(Id)
                                                                        .WithName(Name)
                                                                        .Build();
            return schedule;
        }
    }
}
