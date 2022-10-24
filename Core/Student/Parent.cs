using Core.Contracts;

namespace Core.Student
{
    /// <summary>
    /// Represent the parent entity logic manager
    /// </summary>
    public sealed class Parent
    {
        private Parent(Builder builder)
        {
            Id = builder.IdOption;
            Name = builder.NameOption;
            LastName = builder.LastNameOption;
            Email = builder.EmailOption;
            Link = builder.LinkOption;
            Phone = builder.PhoneOption;
        }

        #region props

        /// <summary>
        /// Represent the identification code
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Represent the parent's name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Represent the parent's lastname
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Represent the email
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Represent the link to student
        /// </summary>
        public string Link { get; }

        /// <summary>
        /// Represent a phone number
        /// </summary>
        public string Phone { get; }

        #endregion

        /// <summary>
        /// Class to build an <see cref="Parent"/> instance
        /// </summary>
        public class Builder
        {
            internal Guid IdOption { get; set; }
            internal string NameOption { get; set; }
            internal string LastNameOption { get; set; }
            internal string EmailOption { get; set; }
            internal string LinkOption { get; set; }
            internal string PhoneOption { get; set; }

            /// <summary>
            /// Implement an instance of <see cref="Builder"/>
            /// </summary>
            public Parent Build()
            {
                return new Parent(this);
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

            /// <summary>
            /// Set the <see cref="LastName"/> property
            /// </summary>
            /// <param name="lastName"><see cref="string"/></param>
            public Builder WithLastName(string lastName) => SetProperty(() => LastNameOption = lastName);

            /// <summary>
            /// Set the <see cref="Email"/> property
            /// </summary>
            /// <param name="email"><see cref="string"/></param>
            public Builder WithEmail(string email) => SetProperty(() => EmailOption = email);

            /// <summary>
            /// Set the <see cref="Link"/> property
            /// </summary>
            /// <param name="link"><see cref="string"/></param>
            public Builder WithLink(string link) => SetProperty(() => LinkOption = link);

            /// <summary>
            /// Set the <see cref="Phone"/> property
            /// </summary>
            /// <param name="phoneNumber"><see cref="string"/></param>
            public Builder WithPhoneNumber(string phoneNumber) => SetProperty(() => PhoneOption = phoneNumber);

            #endregion

            private Builder SetProperty<T>(Func<T> argument)
            {
                argument();
                return this;
            }

        }
    }
}