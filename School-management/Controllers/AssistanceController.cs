using Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using School_management.Models.Assistance;
using School_management.Models.Student;

namespace School_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssistanceController : ControllerBase
    {
        private readonly IAssistanceRepository _assistanceRepository;

        /// <summary>
        /// Implement an instance of <see cref="AssistanceController"/>
        /// </summary>
        /// <param name="assignatureRepository"></param>
        public AssistanceController(IAssistanceRepository assignatureRepository)
        {
            _assistanceRepository = assignatureRepository;
        }

        /// <summary>
        /// Create an assistance
        /// </summary>
        /// <param name="assistanceModel"><see cref="AssistanceModel"/></param>
        [HttpPost]
        public async Task<IActionResult> CreateAssistance([FromBody] IEnumerable<AssistanceModel> assistanceModel)
        {
            if (assistanceModel == null) return BadRequest();

            IEnumerable<Core.Assistance.Assistance> assistance = assistanceModel.Select(assistance => assistance.ToEntity());

            await Core.Assistance.Assistance.Persist(_assistanceRepository, assistance);

            return Ok();
        }

        /// <summary>
        /// update an assistance
        /// </summary>
        /// <param name="assistanceModel"><see cref="AssistanceModel"/></param>
        [HttpPatch]
        public async Task<IActionResult> UpdateAssistance([FromBody] AssistanceModel assistanceModel)
        {
            if (assistanceModel == null) return BadRequest();

            Core.Assistance.Assistance assistance = assistanceModel.ToEntity();

            await assistance.Update(_assistanceRepository);

            return Ok();
        }

        /// <summary>
        /// Get all assistance
        /// </summary>
        [HttpGet]
        public IActionResult GetAllByDate([FromQuery] string dateIssue, [FromQuery] Guid courseId, [FromQuery] Guid assignatureId)
        {
            Core.Assistance.Assistance assistance = new Core.Assistance.Assistance.Builder()
                                                                                  .WithDateIssue(DateTime.Parse(dateIssue))
                                                                                  .Build();

            IEnumerable<Core.Assistance.Assistance> assistances = assistance.GetByDate(_assistanceRepository, courseId, assignatureId);

            IEnumerable<StudentAssistanceList> assignatureModels = assistances.Select(assistance => StudentAssistanceList.FromEntity(assistance));

            return Ok(assignatureModels);
        }
    }
}