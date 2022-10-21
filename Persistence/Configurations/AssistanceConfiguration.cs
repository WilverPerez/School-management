using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.Configurations
{
    /// <summary>
    /// Represents de Entity Configuration for <see cref="Assistance"/>
    /// </summary>
    public sealed class AssistanceConfiguration : IEntityTypeConfiguration<Assistance>
    {
        /// <summary>
        /// Configure relationships and restrictions of <see cref="Assistance"/> Entity.
        /// </summary>
        /// <param name="builder">An instance of <see cref="EntityTypeBuilder"/></param>
        public void Configure(EntityTypeBuilder<Assistance> builder)
        {
            builder.HasKey(assistance => assistance.Id);

            builder.HasOne(assistance => assistance.Student)
                   .WithMany(student => student.Assistances);

            builder.HasOne(assistance => assistance.Assignature)
                   .WithMany(assignature => assignature.Assistances);

            builder.HasOne(assistance => assistance.Course)
                   .WithMany(course => course.Assistances);
        }
    }
}
