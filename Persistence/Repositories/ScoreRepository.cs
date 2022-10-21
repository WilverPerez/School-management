using Core.Assistance;
using Core.Contracts;
using Core.Score;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    /// <summary>
    /// Implement all logic for manage score entity into db
    /// </summary>
    public sealed class ScoreRepository : IScoreRepository
    {
        private readonly SqlContext _context;

        /// <summary>
        /// Implement an instance of <see cref="ScoreRepository"/>
        /// </summary>
        public ScoreRepository(SqlContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        IEnumerable<Score> IScoreRepository.GetByAssignature(Guid assignatureId, Guid courseId)
        {
            IEnumerable<Models.Score> scores = _context.Score
                                                       .AsNoTracking()
                                                       .Include(score => score.Student)
                                                       .Include(score => score.Course)
                                                       .Include(score => score.Assignature)
                                                       .Where(score => score.Course.Id == courseId &&
                                                                       score.Assignature.Id == assignatureId);

            IEnumerable<Score> scoreEntities = scores.Select(score => score.ToEntity());

            return scoreEntities;
        }

        /// <inheritdoc/>
        async Task IScoreRepository.PersistRange(IEnumerable<Score> scoreEntities)
        {
            IEnumerable<Models.Score> scores = scoreEntities.Select(assis => Models.Score.FromEntity(assis));

            foreach (Models.Score score in scores)
            {
                score.Student = await _context.Student.FirstOrDefaultAsync(student => student.Id == score.Student.Id);
                score.Assignature = await _context.Assignature.FirstOrDefaultAsync(assignature => assignature.Id == score.Assignature.Id);
                score.Course = await _context.Course.FirstOrDefaultAsync(course => course.Id == score.Course.Id);
            }

            await _context.Score.AddRangeAsync(scores);

            await _context.SaveChangesAsync();
        }

        Task IScoreRepository.Update(Score assistance)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        //async Task IScoreRepository.Update(IEnumerable<Score> scores)
        //{
        //    Models.Assistance assistanceEntity = await _context.Assistance.FirstOrDefaultAsync(score => score.Id == scores.Id);

        //    assistanceEntity.Value = scores.Value;

        //    _context.Assistance.Update(assistanceEntity);

        //    await _context.SaveChangesAsync();
        //}
    }
}
