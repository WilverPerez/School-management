using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.Configurations
{
    /// <summary>
    /// Represents de Entity Configuration for <see cref="Score"/>
    /// </summary>
    public sealed class ScoreConfiguration : IEntityTypeConfiguration<Score>
    {
        /// <summary>
        /// Configure relationships and restrictions of <see cref="Score"/> Entity.
        /// </summary>
        /// <param name="builder">An instance of <see cref="EntityTypeBuilder"/></param>
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.HasKey(score => score.Id);

            builder.HasOne(score => score.Student)
                   .WithMany(student => student.Scores);

            builder.HasOne(score => score.Assignature)
                   .WithMany(assignature => assignature.Scores);

            builder.HasOne(score => score.Course)
                   .WithMany(course => course.Scores);
        }
    }
}
