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
        public DateTime CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Represent the student's courses
        /// </summary>
        public IEnumerable<Course> Courses { get; set; } = new List<Course>();

        /// <summary>
        /// Represent the student's assignatures
        /// </summary>
        public IEnumerable<Assignature> Assignatures { get; set; } = new List<Assignature>();

        /// <summary>
        /// Represent the student's assistances
        /// </summary>
        public IEnumerable<Assistance> Assistances { get; set; } = new List<Assistance>();

        /// <summary>
        /// Represent the student's scores
        /// </summary>
        public IEnumerable<Score> Scores { get; set; } = new List<Score>();

        /// <summary>
        /// Map the entity db to entity core
        /// </summary>
        /// <returns>An instance of <see cref="Core.Student.Student"/></returns>
        internal Core.Student.Student ToEntity()
        {
            Core.Student.Student student = new Core.Student.Student.Builder()
                                                                   .WithId(Id)
                                                                   .WithName(Name)
                                                                   .WithLastName(LastName)
                                                                   .WithCourses(Courses.Select(course => course.ToEntity()))
                                                                   .WithAssignatures(Assignatures.Select(assignature => assignature.ToEntity()))
                                                                   .WithScore(Scores.Select(score => score.ToEntity()))
                                                                   .WithParent(Parent.ToEntity())
                                                                   .Build();
            return student;
        }

        /// <summary>
        /// Map the entity core to entity db
        /// </summary>
        /// <param name="student">An instance of <see cref="Core.Student.Student"/></param>
        /// <returns>An instance of <see cref="Student"/></returns>
        internal static Student FromEntity(Core.Student.Student student)
        {
            Student studentEntity = new Student
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                DateOfBorn = student.DateOfBorn,
                Courses = student.Courses.Select(course => Models.Course.FromEntity(course)),
                Assignatures = student.Assignatures.Select(course => Models.Assignature.FromEntity(course)),
                Parent = Models.Parent.FromEntity(student.Parent)
            };

            return studentEntity;
        }
    }
}
