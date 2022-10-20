using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.Configurations
{
    /// <summary>
    /// Represents de Entity Configuration for <see cref="Student"/>
    /// </summary>
    public sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        /// <summary>
        /// Configure relationships and restrictions of Bond Entity.
        /// </summary>
        /// <param name="builder">An instance of <see cref="EntityTypeBuilder"/></param>
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(student => student.Id);

            builder.HasOne(student => student.Parent)
                   .WithMany(parent => parent.Students);

            builder.HasMany(student => student.Courses)
                   .WithMany(course => course.Students);
        }
    }
}
