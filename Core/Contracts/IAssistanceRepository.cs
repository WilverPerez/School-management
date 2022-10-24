namespace Core.Contracts
{
    /// <summary>
    /// Represent the interface for <see cref="Assistance.Assistance"/> implementation into db
    /// </summary>
    public interface IAssistanceRepository
    {
        /// <summary>
        /// Get all assistances by date
        /// </summary>
        /// <param name="courseId">Represent the course identification</param>
        /// <param name="assignatureId">Represent the assignature identification</param>
        /// <param name="dateIssue">Represent the assignature date issue</param>
        IEnumerable<Assistance.Assistance> GetByDate(DateTime dateIssue, Guid assignatureId, Guid courseId);

        /// <summary>
        /// Persist assistance data
        /// </summary>
        /// <param name="assignature"><see cref="IEnumerable{Assistance.Assistance}"/></param>
        Task PersistRange(IEnumerable<Assistance.Assistance> assignature);

        /// <summary>
        /// Update assistance data
        /// </summary>
        /// <param name="assignature"><see cref="Assistance.Assistance"/></param>
        Task Update(Assistance.Assistance assistance);
    }
}
