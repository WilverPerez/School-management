using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    /// <summary>
    /// Represent the course table into db
    /// </summary>
    public sealed class Course
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the course's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represent the course's creation date
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Represent the course's assignatures
        /// </summary>
        public IEnumerable<Assignature> Assignatures { get; set; }

        /// <summary>
        /// Represent the course's students
        /// </summary>
        public IEnumerable<Student> Students { get; set; }

        /// <summary>
        /// Represent the course's students
        /// </summary>
        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
