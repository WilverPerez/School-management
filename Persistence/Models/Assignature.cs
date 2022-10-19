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
        public IEnumerable<Course> Courses { get; set; } = Enumerable.Empty<Course>();

        /// <summary>
        /// Represent the assignature's students
        /// </summary>
        public IEnumerable<Student> Students { get; set; } = Enumerable.Empty<Student>();

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
                Name = assignature.Name,
                Courses = assignature.Courses.Select(course => Course.FromEntity(course)),
                //Students = assignature.Students.Select(student => Student.FromEntity(student)),
            };

            return assignatureEntity;
        }
    }
}
