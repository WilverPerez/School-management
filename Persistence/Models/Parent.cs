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
        public string Name { get; set; }

        /// <summary>
        /// Represent the parent's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Represent the parent's link
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Represent the parent's phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Represent the parent's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Represent the parent's creation date
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Represent the parent's creation date
        /// </summary>
        public IEnumerable<Student> Students { get; set; }
    }
}
