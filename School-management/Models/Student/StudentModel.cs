namespace School_management.Models.Student
{
    /// <summary>
    /// Represent the course view model
    /// </summary>
    public sealed class StudentModel
    {
        /// <summary>
        /// Represent the identification field
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Represent the student's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Represent the student's last name
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Represent the student's full name
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Represent the student's date
        /// </summary>
        public DateTime DateOfBorn { get; set; }

        /// <summary>
        /// Represent the student's parent
        /// </summary>
        public ParentModel Parent { get; set; } = new ParentModel();

        /// <summary>
        /// Represent the student's courses
        /// </summary>
        public IEnumerable<Course.CourseListModel> Courses { get; set; } = Enumerable.Empty<Course.CourseListModel>();

        /// <summary>
        /// Represent the student's assignatures
        /// </summary>
        public IEnumerable<Assignature.AssignatureListModel> Assignatures { get; set; } = Enumerable.Empty<Assignature.AssignatureListModel>();

        /// <summary>
        /// Map the entity core to entity db
        /// </summary>
        /// <param name="student">An instance of <see cref="Core.Student.Student"/></param>
        /// <returns>An instance of <see cref="StudentModel"/></returns>
        internal static StudentModel FromEntity(Core.Student.Student student)
        {
            StudentModel studentEntity = new StudentModel
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                DateOfBorn = student.DateOfBorn,
                Assignatures = student.Assignatures.Select(assignature => Assignature.AssignatureListModel.FromEntity(assignature)),
                Courses = student.Courses.Select(course => Course.CourseListModel.FromEntity(course)),
                Parent = ParentModel.FromEntity(student.Parent),
                FullName = $"{student.Name} {student.LastName}"
            };

            return studentEntity;
        }

        /// <summary>
        /// Map to <see cref="Core.Student.Student"/>
        /// </summary>
        /// <returns><see cref="Core.Student.Student"/></returns>
        internal Core.Student.Student ToEntity()
        {
            Core.Student.Student student = new Core.Student.Student.Builder()
                                                                   .WithId(Id)
                                                                   .WithName(Name)
                                                                   .WithLastName(LastName)
                                                                   .WithDateOfBorn(DateOfBorn)
                                                                   .WithAssignatures(Assignatures.Select(assignature => assignature.ToEntity()))
                                                                   .WithCourses(Courses.Select(course => course.ToEntity()))
                                                                   .WithParent(Parent.ToEntity())
                                                                   .Build();
            return student;
        }
    }
}
