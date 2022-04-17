using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PowerConfiguration : IEntityTypeConfiguration<Power>
{
    public void Configure(EntityTypeBuilder<Power> builder)
    {
        builder.ToTable("Power");

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.RowVersion)
           .IsConcurrencyToken()
           .ValueGeneratedOnAddOrUpdate();

        builder.Property(e => e.PowerName)
            .HasMaxLength(200)
            .IsUnicode(false);
    }
}
