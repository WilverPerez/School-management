using System.ComponentModel.DataAnnotations;

namespace Persistence.Models
{
    /// <summary>
    /// Represent the student table into db
    /// </summary>
    public sealed class Student
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Represent the student's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represent the student's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Represent the student's date
        /// </summary>
        public DateTime DateOfBorn { get; set; }

        /// <summary>
        /// Represent the student's parent
        /// </summary>
        public Parent Parent { get; set; }

        /// <summary>
        /// Represent the student's creation date
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Represent the student's courses
        /// </summary>
        public IEnumerable<Course> Courses { get; set; }

        /// <summary>
        /// Represent the student's assignatures
        /// </summary>
        public IEnumerable<Assignature> Assignatures { get; set; }

        /// <summary>
        /// Represent the student's assistances
        /// </summary>
        //public IEnumerable<Assistance> Assistances { get; set; }

        /// <summary>
        /// Represent the student's scores
        /// </summary>
        //public IEnumerable<Score> Scores { get; set; }
    }
}
