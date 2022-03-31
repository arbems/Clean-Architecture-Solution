using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class HeroAttributeConfiguration : IEntityTypeConfiguration<HeroAttribute>
{
    public void Configure(EntityTypeBuilder<HeroAttribute> builder)
    {
        builder
           .HasKey(t => new { t.SuperheroId, t.AttributeId });

        builder.ToTable("hero_attribute");

        builder.Property(e => e.AttributeId).HasColumnName("attribute_id");

        builder.Property(e => e.AttributeValue).HasColumnName("attribute_value");

        builder.Property(e => e.SuperheroId).HasColumnName("hero_id");

        /*builder.HasOne(d => d.Attribute)
            .WithMany()
            .HasForeignKey(d => d.AttributeId)
            .HasConstraintName("fk_hat_at");

        builder.HasOne(d => d.Superhero)
            .WithMany()
            .HasForeignKey(d => d.SuperheroId)
            .HasConstraintName("fk_hat_hero");*/
    }
}
