using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.Configurations
{
    /// <summary>
    /// Represents de Entity Configuration for <see cref="Assignature"/>
    /// </summary>
    public sealed class AssignatureConfiguration : IEntityTypeConfiguration<Assignature>
    {
        /// <summary>
        /// Configure relationships and restrictions of <see cref="Assignature"/> Entity.
        /// </summary>
        /// <param name="builder">An instance of <see cref="EntityTypeBuilder"/></param>
        public void Configure(EntityTypeBuilder<Assignature> builder)
        {
            builder.HasKey(assignature => assignature.Id);

            builder.HasMany(assignature => assignature.Courses)
                   .WithMany(course => course.Assignatures);

            builder.HasMany(assignature => assignature.Students)
                   .WithMany(assignature => assignature.Assignatures);
        }
    }
}
