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
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Represent the assignature's courses
        /// </summary>
        public IEnumerable<Course> Courses { get; set; } = new List<Course>();

        /// <summary>
        /// Represent the assignature's students
        /// </summary>
        public List<Student> Students { get; set; } = new List<Student>();

        /// <summary>
        /// Represent the creation date.
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Represent the assignature's assistances
        /// </summary>
        public IEnumerable<Assistance> Assistances { get; set; } = new List<Assistance>();

        /// <summary>
        /// Represent the assignature's scores
        /// </summary>
        public IEnumerable<Score> Scores { get; set; }

        /// <summary>
        /// Map the entity db to entity core
        /// </summary>
        /// <returns>An instance of <see cref="Core.Assignature.Assignature"/></returns>
        internal Core.Assignature.Assignature ToEntity()
        {
            Core.Assignature.Assignature assignature = new Core.Assignature.Assignature.Builder()
                                                                                       .WithId(Id)
                                                                                       .WithName(Name)
                                                                                       .WithCourses(Courses.Select(course => course.ToEntity()))
                                                                                       .WithStudents(Students.Select(student => student.ToEntity()))
                                                                                       .Build();
            return assignature;
        }

        /// <summary>
        /// Map the entity core to entity db
        /// </summary>
        /// <returns>An instance of <see cref="Assignature"/></returns>
        internal static Assignature FromEntity(Core.Assignature.Assignature assignature)
        {
            Assignature assignatureEntity = new Assignature
            {
                Id = assignature.Id,
                Name = assignature.Name
            };

            if(assignature.Courses != null)
            {
                assignatureEntity.Courses = assignature.Courses.Select(course => Course.FromEntity(course));
            }

            if (assignature.Students != null)
            {
                assignatureEntity.Students = assignature.Students.Select(student => Student.FromEntity(student)).ToList();
            }

            return assignatureEntity;
        }
    }
}
