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
    }
}
