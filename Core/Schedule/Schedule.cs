using Core.Contracts;

namespace Core.Schedule
{
    /// <summary>
    /// Represent the schedule entity logic manager
    /// </summary>
    public sealed class Schedule
    {
        private Schedule(Builder builder)
        {
            Id = builder.IdOption;
            Name = builder.NameOption;
        }

        #region props

        /// <summary>
        /// Represent the identification code
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Represent the schedule's name
        /// </summary>
        public string Name { get; }

        #endregion

        /// <summary>
        /// Get all schedules
        /// </summary>
        /// <param name="scheduleRepository">An instance of <see cref="IScheduleRepository"/></param>
        /// <returns>An instance of <see cref="Schedule"/></returns>
        public static IEnumerable<Schedule> GetAll(IScheduleRepository scheduleRepository)
        {
            return scheduleRepository.GetAll();
        }

        /// <summary>
        /// Class to build an <see cref="Schedule"/> instance
        /// </summary>
        public class Builder {
            internal Guid IdOption { get; set; }
            internal string NameOption { get; set; } = string.Empty;
            internal DateTime DateOfBornOption { get; set; }

            /// <summary>
            /// Implement an instance of <see cref="Builder"/>
            /// </summary>
            public Schedule Build()
            {
                return new Schedule(this);
            }

            #region With methods

            /// <summary>
            /// Set the <see cref="Id"/> property
            /// </summary>
            /// <param name="id"><see cref="Guid"/></param>
            public Builder WithId(Guid id) => SetProperty(() => IdOption = id);

            /// <summary>
            /// Set the <see cref="Name"/> property
            /// </summary>
            /// <param name="name"><see cref="string"/></param>
            public Builder WithName(string name) => SetProperty(() => NameOption = name);

            #endregion

            private Builder SetProperty<T>(Func<T> argument)
            {
                argument();
                return this;
            }

        }
    }
}