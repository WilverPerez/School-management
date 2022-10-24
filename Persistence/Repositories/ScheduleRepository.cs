using Core.Contracts;
using Core.Schedule;

namespace Persistence.Repositories
{
    /// <summary>
    /// Implement all logic for manage schedule entity into db
    /// </summary>
    public sealed class ScheduleRepository : IScheduleRepository
    {
        private readonly SqlContext _context;
        /// <summary>
        /// Implement an instance of <see cref="ScheduleRepository"/>
        /// </summary>
        public ScheduleRepository(SqlContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        IEnumerable<Schedule> IScheduleRepository.GetAll()
        {
            IEnumerable<Models.Schedule> schedules = _context.Schedule;

            IEnumerable<Schedule> scheduleEntities = schedules.Select(schedule => schedule.ToEntity());

            return scheduleEntities;
        }
    }
}
