using Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using School_management.Models.Assignature;

namespace School_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignatureController : ControllerBase
    {
        private readonly IAssignatureRepository _assignatureRepository;

        /// <summary>
        /// Implement an instance of <see cref="AssignatureController"/>
        /// </summary>
        /// <param name="assignatureRepository"></param>
        public AssignatureController(IAssignatureRepository assignatureRepository)
        {
            _assignatureRepository = assignatureRepository;
        }

        /// <summary>
        /// Create an assignature
        /// </summary>
        /// <param name="assignatureModel"><see cref="AssignatureModel"/></param>
        [HttpPost]
        public async Task<IActionResult> CreateAssignature([FromBody] AssignatureModel assignatureModel)
        {
            if (assignatureModel == null) return BadRequest();

            Core.Assignature.Assignature assignature = assignatureModel.ToEntity();

            await assignature.Persist(_assignatureRepository);

            return Ok();
        }

        /// <summary>
        /// Get all assignature
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Core.Assignature.Assignature> assignatures = Core.Assignature.Assignature.GetAll(_assignatureRepository);

            IEnumerable<AssignatureListModel> assignatureModels = assignatures.Select(assignature => AssignatureListModel.FromEntity(assignature));

            return Ok(assignatureModels);
        }
    }
}