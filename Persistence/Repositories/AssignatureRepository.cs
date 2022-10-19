using Core.Assignature;
using Core.Contracts;
using Core.Schedule;

namespace Persistence.Repositories
{
    /// <summary>
    /// Implement all logic for manage assignature entity into db
    /// </summary>
    public sealed class AssignatureRepository : IAssignatureRepository
    {
        private readonly SqlContext _context;

        /// <summary>
        /// Implement an instance of <see cref="AssignatureRepository"/>
        /// </summary>
        public AssignatureRepository(SqlContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        IEnumerable<Assignature> IAssignatureRepository.GetAll()
        {
            IEnumerable<Models.Assignature> assignatures = _context.Assignature;

            IEnumerable<Assignature> assignatureEntities = assignatures.Select(assignature => assignature.ToEntity());

            return assignatureEntities;
        }

        /// <inheritdoc/>
        async Task IAssignatureRepository.Persist(Assignature assignature)
        {
            Models.Assignature assignatureEntity = Models.Assignature.FromEntity(assignature);
            
            await _context.Assignature.AddAsync(assignatureEntity);

            await _context.SaveChangesAsync();
        }
    }
}
