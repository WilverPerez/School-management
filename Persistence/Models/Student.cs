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
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Represent the student's last name
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Represent the student's date
        /// </summary>
        public DateTime DateOfBorn { get; set; }

        /// <summary>
        /// Represent the student's parent
        /// </summary>
        public Parent Parent { get; set; } = new Parent();

        /// <summary>
        /// Represent the student's creation date
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Represent the student's courses
        /// </summary>
        public IEnumerable<Course> Courses { get; set; } = Enumerable.Empty<Course>();

        /// <summary>
        /// Represent the student's assignatures
        /// </summary>
        public IEnumerable<Assignature> Assignatures { get; set; } = Enumerable.Empty<Assignature>();

        /// <summary>
        /// Represent the student's assistances
        /// </summary>
        //public IEnumerable<Assistance> Assistances { get; set; }

        /// <summary>
        /// Represent the student's scores
        /// </summary>
        //public IEnumerable<Score> Scores { get; set; }


        /// <summary>
        /// Map the entity db to entity core
        /// </summary>
        /// <returns>An instance of <see cref="Core.Student.Student"/></returns>
        internal Core.Student.Student ToEntity()
        {
            Core.Student.Student student = new Core.Student.Student.Builder()
                                                                   .WithId(Id)
                                                                   .WithName(Name)
                                                                   .WithCourses(Courses.Select(course => course.ToEntity()))
                                                                   .WithAssignatures(Assignatures.Select(assignature => assignature.ToEntity()))
                                                                   //.WithParent(Parent.ToEntity())
                                                                   .Build();
            return student;
        }
    }
}
