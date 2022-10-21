using Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using School_management.Models.Score;
using School_management.Models.Student;

namespace School_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreRepository _scoreRepository;

        /// <summary>
        /// Implement an instance of <see cref="ScoreController"/>
        /// </summary>
        /// <param name="assignatureRepository"></param>
        public ScoreController(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        /// <summary>
        /// Create an score
        /// </summary>
        /// <param name="scoreModel"><see cref="ScoreModel"/></param>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IEnumerable<ScoreModel> scoreModel)
        {
            if (scoreModel == null) return BadRequest();

            IEnumerable<Core.Score.Score> score = scoreModel.Select(score => score.ToEntity());

            await Core.Score.Score.Persist(_scoreRepository, score);

            return Ok();
        }

        /// <summary>
        /// update an score
        /// </summary>
        /// <param name="scoreModel"><see cref="ScoreModel"/></param>
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] ScoreModel scoreModel)
        {
            if (scoreModel == null) return BadRequest();

            Core.Score.Score score = scoreModel.ToEntity();

            await score.Update(_scoreRepository);

            return Ok();
        }

        /// <summary>
        /// Get all score by assignature
        /// </summary>
        [HttpGet]
        public IActionResult GetAllByAsignature([FromQuery] Guid courseId, [FromQuery] Guid assignatureId)
        {
            IEnumerable<Core.Score.Score> scores = Core.Score.Score.GetByDate(_scoreRepository, courseId, assignatureId);

            IEnumerable<StudentAssistanceList> assignatureModels = scores.Select(score => StudentAssistanceList.FromEntity(score));

            return Ok(assignatureModels);
        }
    }
}