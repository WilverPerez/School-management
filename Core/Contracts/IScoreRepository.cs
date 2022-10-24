namespace Core.Contracts
{
    /// <summary>
    /// Represent the interface for <see cref="Score.Score"/> implementation into db
    /// </summary>
    public interface IScoreRepository
    {
        /// <summary>
        /// Get all score by date
        /// </summary>
        /// <param name="courseId">Represent the course identification</param>
        /// <param name="assignatureId">Represent the assignature identification</param>
        IEnumerable<Score.Score> GetByAssignature(Guid assignatureId, Guid courseId);

        /// <summary>
        /// Persist assistance data
        /// </summary>
        /// <param name="assignature"><see cref="IEnumerable{Score.Score}"/></param>
        Task PersistRange(IEnumerable<Score.Score> assignature);

        /// <summary>
        /// Update assistance data
        /// </summary>
        /// <param name="assignature"><see cref="Score.Score"/></param>
        Task Update(Score.Score assistance);
    }
}
