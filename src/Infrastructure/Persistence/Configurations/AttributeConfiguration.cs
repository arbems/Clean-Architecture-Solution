using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AttributeConfiguration : IEntityTypeConfiguration<Domain.Entities.Attribute>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Attribute> builder)
    {
        builder.ToTable("Attribute");

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.RowVersion)
           .IsConcurrencyToken()
           .ValueGeneratedOnAddOrUpdate();

        builder.Property(e => e.AttributeName)
            .HasMaxLength(200)
            .IsUnicode(false);
    }
}
