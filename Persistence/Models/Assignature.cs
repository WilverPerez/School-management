using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    /// <summary>
    /// Represent the assignature table into db
    /// </summary>
    public sealed class Assignature
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the assignature's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represent the assignature's courses
        /// </summary>
        public IEnumerable<Course> Courses { get; set; }

        /// <summary>
        /// Represent the assignature's students
        /// </summary>
        public IEnumerable<Student> Students { get; set; }
    }
}
