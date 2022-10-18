using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.Configurations
{
    /// <summary>
    /// Represents de Entity Configuration for <see cref="Course"/>
    /// </summary>
    public sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        /// <summary>
        /// Configure relationships and restrictions of Bond Entity.
        /// </summary>
        /// <param name="builder">An instance of <see cref="EntityTypeBuilder"/></param>
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(course => course.Id);
         
            builder.HasMany(course => course.Students)
                   .WithMany(course => course.Courses);

            builder.HasMany(course => course.Assignatures)
                   .WithMany(assignature => assignature.Courses);

            builder.HasMany(course => course.Schedules)
                   .WithMany(assignature => assignature.Courses);
        }
    }
}
