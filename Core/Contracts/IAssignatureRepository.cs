namespace Core.Contracts
{
    /// <summary>
    /// Represent the interface for <see cref="Assignature.Assignature"/> implementation into db
    /// </summary>
    public interface IAssignatureRepository
    {
        /// <summary>
        /// Get all assignatures
        /// </summary>
        public IEnumerable<Assignature.Assignature> GetAll();

        /// <summary>
        /// Persist assignature data
        /// </summary>
        /// <param name="assignature"><see cref="Assignature.Assignature"/></param>
        Task Persist(Assignature.Assignature assignature);
    }
}
