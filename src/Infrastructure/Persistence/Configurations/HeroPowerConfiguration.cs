using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class HeroPowerConfiguration : IEntityTypeConfiguration<HeroPower>
{
    public void Configure(EntityTypeBuilder<HeroPower> builder)
    {
        builder.HasNoKey();

        builder.ToTable("hero_power");

        builder.Property(e => e.HeroId).HasColumnName("hero_id");

        builder.Property(e => e.PowerId).HasColumnName("power_id");

        builder.HasOne(d => d.Hero)
            .WithMany()
            .HasForeignKey(d => d.HeroId)
            .HasConstraintName("fk_hpo_hero");

        builder.HasOne(d => d.Power)
            .WithMany()
            .HasForeignKey(d => d.PowerId)
            .HasConstraintName("fk_hpo_po");
    }
}
