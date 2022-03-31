using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class SuperheroConfiguration : IEntityTypeConfiguration<Superhero>
{
    public void Configure(EntityTypeBuilder<Superhero> builder)
    {
        builder.ToTable("superhero");

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.FullName)
            .HasMaxLength(200)
            .IsUnicode(false)
            .HasColumnName("full_name");

        builder.Property(e => e.SuperheroName)
            .HasMaxLength(200)
            .IsUnicode(false)
            .HasColumnName("superhero_name");

        builder.Property(e => e.HeightCm).HasColumnName("height_cm");

        builder.Property(e => e.WeightKg).HasColumnName("weight_kg");

        builder.Property(e => e.PublisherId).HasColumnName("publisher_id");

        builder.Property(e => e.RaceId).HasColumnName("race_id");

        builder
            .OwnsOne(b => b.EyeColour)
            .Property(e => e.Code).HasColumnName("eye_colour");

        builder
            .OwnsOne(b => b.HairColour)
            .Property(e => e.Code).HasColumnName("hair_colour");

        builder
            .OwnsOne(b => b.SkinColour)
            .Property(e => e.Code).HasColumnName("skin_colour");

        builder
            .OwnsOne(b => b.Gender)
            .Property(e => e.Value).HasColumnName("gender");

        builder
            .OwnsOne(b => b.Alignment)
            .Property(e => e.Value).HasColumnName("alignment");
    }
}
