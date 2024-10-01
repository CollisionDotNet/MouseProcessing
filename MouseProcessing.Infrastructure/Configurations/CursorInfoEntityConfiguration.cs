using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MouseProcessing.Infrastructure.Entities;

namespace MouseProcessing.Infrastructure.Configurations
{
    public class CursorInfoEntityConfiguration : IEntityTypeConfiguration<CursorInfoEntity>
    {
        public void Configure(EntityTypeBuilder<CursorInfoEntity> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.X)
                .IsRequired();

            builder
                .Property(e => e.Y)
                .IsRequired();

            builder
                .Property(e => e.Time)
                .IsRequired();
        }
    }
}
