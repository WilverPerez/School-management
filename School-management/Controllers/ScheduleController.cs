using Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace School_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;

        /// <summary>
        /// Implement an instance of <see cref="ScheduleController"/>
        /// </summary>
        /// <param name="scheduleRepository">Implement an instance of <see cref="IScheduleRepository"/></param>
        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        /// <summary>
        /// Get all schedules
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Core.Schedule.Schedule> schedules = Core.Schedule.Schedule.GetAll(_scheduleRepository);

            return Ok(schedules);
        }
    }
}