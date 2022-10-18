namespace Core.Student
{
    /// <summary>
    /// Represent the parent entity logic manager
    /// </summary>
    public sealed class Parent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Link { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}