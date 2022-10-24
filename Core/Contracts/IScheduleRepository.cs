namespace Core.Contracts
{
    /// <summary>
    /// Represent the interface for <see cref="Schedule.Schedule"/> implementation into db
    /// </summary>
    public interface IScheduleRepository
    {
        /// <summary>
        /// Get all schedules
        /// </summary>
        public IEnumerable<Schedule.Schedule> GetAll();
    }
}
