using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.Configurations
{
    /// <summary>
    /// Represents de Entity Configuration for <see cref="Parent"/>
    /// </summary>
    public sealed class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        /// <summary>
        /// Configure relationships and restrictions of <see cref="Parent"/> Entity.
        /// </summary>
        /// <param name="builder">An instance of <see cref="EntityTypeBuilder"/></param>
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.HasKey(parent => parent.Id);

            builder.HasMany(parent => parent.Students)
                   .WithOne(parent => parent.Parent);
        }
    }
}
