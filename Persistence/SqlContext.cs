using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using System.Reflection;

namespace Persistence
{
    /// <summary>
    /// Application DbContext that storage and manage all data.
    /// </summary>
    public class SqlContext : DbContext
    {
        /// <summary>
        /// Implement an instance of <see cref="SqlContext"/>
        /// </summary>
        /// <param name="options"></param>
        public SqlContext(DbContextOptions options) : base(options) { }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => base.OnConfiguring(optionsBuilder);

        /// <inheritdoc cref="DbContext.OnModelCreating(ModelBuilder)"/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(SqlContext)));
        }

        /// <summary>
        /// Set the student's table
        /// </summary>
        public DbSet<Student> Student { get; set; }

        /// <summary>
        /// Set the parent's table
        /// </summary>
        public DbSet<Parent> Parent { get; set; }

        /// <summary>
        /// Set the course's table
        /// </summary>
        public DbSet<Course> Course { get; set; }

        /// <summary>
        /// Set the assignature's table
        /// </summary>
        public DbSet<Assignature> Assignature { get; set; }

        /// <summary>
        /// Set the schedule's table
        /// </summary>
        public DbSet<Schedule> Schedule { get; set; }

    }
}