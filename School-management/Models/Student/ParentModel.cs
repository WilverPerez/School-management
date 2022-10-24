namespace School_management.Models.Student
{
    /// <summary>
    /// Represent the parent view model
    /// </summary>
    public sealed class ParentModel
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Represent the parent's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Represent the parent's last name
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        
        /// <summary>
        /// Represent the parent's full name
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Represent the parent's email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Represent the parent's phone number
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Represent the parent's link
        /// </summary>
        public string Link { get; set; } = string.Empty;

        /// <summary>
        /// Map the entity core to entity db
        /// </summary>
        /// <param name="parent">An instance of <see cref="Core.Student.Parent"/></param>
        /// <returns>An instance of <see cref="ParentModel"/></returns>
        internal static ParentModel FromEntity(Core.Student.Parent parent)
        {
            ParentModel studentEntity = new ParentModel
            {
                Id = parent.Id,
                Name = parent.Name,
                LastName = parent.LastName,
                Email = parent.Email,
                Link = parent.Link,
                PhoneNumber = parent.Phone,
                FullName = $"{parent.Name} {parent.LastName}"
            };

            return studentEntity;
        }

        /// <summary>
        /// Map to <see cref="Core.Student.Parent"/>
        /// </summary>
        /// <returns><see cref="Core.Student.Parent"/></returns>
        internal Core.Student.Parent ToEntity()
        {
            Core.Student.Parent parent = new Core.Student.Parent.Builder()
                                                                .WithId(Id)
                                                                .WithName(Name)
                                                                .WithLastName(LastName)
                                                                .WithEmail(Email)
                                                                .WithPhoneNumber(PhoneNumber)
                                                                .WithLink(Link)
                                                                .Build();
            return parent;
        }
    }
}
