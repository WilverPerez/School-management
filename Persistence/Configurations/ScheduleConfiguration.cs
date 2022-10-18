using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.Configurations
{
    /// <summary>
    /// Represents de Entity Configuration for <see cref="Schedule"/>
    /// </summary>
    public sealed class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        /// <summary>
        /// Configure relationships and restrictions of Bond Entity.
        /// </summary>
        /// <param name="builder">An instance of <see cref="EntityTypeBuilder"/></param>
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(schedule => schedule.Id);

            builder.HasMany(schedule => schedule.Courses)
                   .WithMany(course => course.Schedules);

            builder.HasData(
                    new Schedule { Id = Guid.Parse("91a7ad32-70b7-4f3a-92d7-abdec43fe029"), Name = "Lunes", CreationDate = DateTime.Now },
                    new Schedule { Id = Guid.Parse("4174672a-1fe7-4945-b579-bc95a12a81f9"), Name = "Martes", CreationDate = DateTime.Now },
                    new Schedule { Id = Guid.Parse("91a7ad32-70b7-4f3a-92d7-abdec43fe028"), Name = "Miércoles", CreationDate = DateTime.Now },
                    new Schedule { Id = Guid.Parse("d08b8e67-44cb-4ed9-ada8-cac86a6e2e42"), Name = "Jueves", CreationDate = DateTime.Now },
                    new Schedule { Id = Guid.Parse("2251ef77-c607-4bca-ba50-70b62f33fe31"), Name = "Viernes", CreationDate = DateTime.Now },
                    new Schedule { Id = Guid.Parse("b5c8c13d-8cb8-43f2-be1f-ebc5fb0772b5"), Name = "Sábado", CreationDate = DateTime.Now }
            );
        }
    }
}
