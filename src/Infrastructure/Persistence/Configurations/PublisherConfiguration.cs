using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable("Publisher");

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.RowVersion)
           .IsConcurrencyToken()
           .ValueGeneratedOnAddOrUpdate();

        builder.Property(e => e.PublisherName)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}
