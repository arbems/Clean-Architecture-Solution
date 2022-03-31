using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class SuperpowerConfiguration : IEntityTypeConfiguration<Superpower>
{
    public void Configure(EntityTypeBuilder<Superpower> builder)
    {
        builder.ToTable("superpower");

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.PowerName)
            .HasMaxLength(200)
            .IsUnicode(false)
            .HasColumnName("power_name");
    }
}
