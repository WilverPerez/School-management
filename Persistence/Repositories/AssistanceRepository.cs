using Core.Assistance;
using Core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    /// <summary>
    /// Implement all logic for manage assistance entity into db
    /// </summary>
    public sealed class AssistanceRepository : IAssistanceRepository
    {
        private readonly SqlContext _context;

        /// <summary>
        /// Implement an instance of <see cref="AssistanceRepository"/>
        /// </summary>
        public AssistanceRepository(SqlContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        IEnumerable<Assistance> IAssistanceRepository.GetByDate(DateTime dateIssue, Guid assignatureId, Guid courseId)
        {
            var eso = dateIssue.Date.ToString("yyyy-MM-dd");

            IEnumerable<Models.Assistance> assignatures = _context.Assistance
                                                                   .AsNoTracking()
                                                                   .Include(assistance => assistance.Student)
                                                                   .Include(assistance => assistance.Course)
                                                                   .Include(assistance => assistance.Assignature)
                                                                   .Where(assistance => assistance.Course.Id == courseId &&
                                                                                        assistance.Assignature.Id == assignatureId &&
                                                                                        assistance.DateIssue.Date == dateIssue.Date);

            IEnumerable<Assistance> assignatureEntities = assignatures.Select(assistance => assistance.ToEntity());

            return assignatureEntities;
        }

        /// <inheritdoc/>
        async Task IAssistanceRepository.PersistRange(IEnumerable<Assistance> assistance)
        {
            IEnumerable<Models.Assistance> assistances = assistance.Select(assis => Models.Assistance.FromEntity(assis));

            foreach (Models.Assistance assistanceEntity in assistances)
            {
                assistanceEntity.Student = await _context.Student.FirstOrDefaultAsync(student => student.Id == assistanceEntity.Student.Id);
                assistanceEntity.Assignature = await _context.Assignature.FirstOrDefaultAsync(assignature => assignature.Id == assistanceEntity.Assignature.Id);
                assistanceEntity.Course = await _context.Course.FirstOrDefaultAsync(course => course.Id == assistanceEntity.Course.Id);
            }

            await _context.Assistance.AddRangeAsync(assistances);

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        async Task IAssistanceRepository.Update(Assistance assistanceCore)
        {
            Models.Assistance assistanceEntity = await _context.Assistance.FirstOrDefaultAsync(assistance => assistance.Id == assistanceCore.Id);

            assistanceEntity.Value = assistanceCore.Value;

            _context.Assistance.Update(assistanceEntity);

            await _context.SaveChangesAsync();
        }
    }
}
