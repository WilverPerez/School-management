namespace School_management.Models.Assignature
{
    /// <summary>
    /// Represent the assignature list view model
    /// </summary>
    public sealed class AssignatureListModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the assignature's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Represent the assignature's course quantity
        /// </summary>
        public int CourseCount { get; set; }

        /// <summary>
        /// Map to <see cref="Core.Assignature.Assignature"/>
        /// </summary>
        /// <returns><see cref="Core.Assignature.Assignature"/></returns>
        internal Core.Assignature.Assignature ToEntity()
        {
            Core.Assignature.Assignature assignature = new Core.Assignature.Assignature.Builder()
                                                                                       .WithId(Id)
                                                                                       .WithName(Name)
                                                                                       .Build();
            return assignature;
        }

        /// <summary>
        /// Map to <see cref="AssignatureListModel"/>
        /// </summary>
        /// <returns><see cref="AssignatureListModel"/></returns>
        internal static AssignatureListModel FromEntity(Core.Assignature.Assignature assignature)
        {
            AssignatureListModel assignatureListModel = new AssignatureListModel
            {
                Id = assignature.Id,
                Name = assignature.Name,
                CourseCount = assignature.Courses.Count()
            };

            return assignatureListModel;
        }
    }
}
