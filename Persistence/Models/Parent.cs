using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    /// <summary>
    /// Represent the parent asociated to a student table into db
    /// </summary>
    public sealed class Parent
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the parent's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Represent the parent's last name
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Represent the parent's link
        /// </summary>
        public string Link { get; set; } = string.Empty;

        /// <summary>
        /// Represent the parent's phone
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Represent the parent's email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Represent the parent's creation date
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Represent the parent's creation date
        /// </summary>
        public IEnumerable<Student> Students { get; set; } = new List<Student>();

        /// <summary>
        /// Map the entity db to entity core
        /// </summary>
        /// <returns>An instance of <see cref="Core.Student.Parent"/></returns>
        internal Core.Student.Parent ToEntity()
        {
            Core.Student.Parent parent = new Core.Student.Parent.Builder()
                                                                .WithId(Id)
                                                                .WithName(Name)
                                                                .WithLastName(LastName)
                                                                .WithLink(Link)
                                                                .WithPhoneNumber(Phone)
                                                                .WithEmail(Email)
                                                                .Build();
            return parent;
        }

        /// <summary>
        /// Map the entity db to entity core
        /// </summary>
        /// <param name="parent">An instance of <see cref="Core.Student.Parent"/></param>
        /// <returns>An instance of <see cref="Parent"/></returns>
        internal static Parent FromEntity(Core.Student.Parent parent)
        {
            Parent parentEntity = new Parent
            {
                Id = parent.Id,
                Name = parent.Name,
                LastName = parent.LastName,
                Link = parent.Link,
                Phone = parent.Phone,
                Email = parent.Email,
            };

            return parentEntity;
        }
    }
}
