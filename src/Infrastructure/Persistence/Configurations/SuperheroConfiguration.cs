using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class SuperheroConfiguration : IEntityTypeConfiguration<Superhero>
{
    public void Configure(EntityTypeBuilder<Superhero> builder)
    {
        builder.ToTable("SuperHero");

        builder.Ignore(e => e.DomainEvents);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.RowVersion)
           .IsConcurrencyToken()
           .ValueGeneratedOnAddOrUpdate();

        builder.Property(e => e.FullName)
            .HasMaxLength(200)
            .IsUnicode(false);

        builder.Property(e => e.SuperheroName)
            .HasMaxLength(200)
            .IsUnicode(false);

        builder
            .OwnsOne(b => b.EyeColour)
            .Property(e => e.Code);

        builder
            .OwnsOne(b => b.HairColour)
            .Property(e => e.Code);

        builder
            .OwnsOne(b => b.SkinColour)
            .Property(e => e.Code);

        builder
            .OwnsOne(b => b.Gender)
            .Property(e => e.Value);

        builder
            .OwnsOne(b => b.Alignment)
            .Property(e => e.Value);

        builder
            .HasMany(p => p.Attributes)
            .WithMany(p => p.Heroes)
            .UsingEntity<Dictionary<string, object>>(
                "HeroAttribute",
                j => j
                    .HasOne<Domain.Entities.Attribute>()
                    .WithMany()
                    .HasForeignKey("AttributeId")
                    .HasConstraintName("FK_HeroAttribute_Attributes_AttributeId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Superhero>()
                    .WithMany()
                    .HasForeignKey("HeroId")
                    .HasConstraintName("FK_HeroAttribute_Heroes_HeroId")
                    .OnDelete(DeleteBehavior.ClientCascade));

        builder
            .HasMany(p => p.Powers)
            .WithMany(p => p.Heroes)
            .UsingEntity<Dictionary<string, object>>(
                "HeroPower",
                j => j
                    .HasOne<Power>()
                    .WithMany()
                    .HasForeignKey("PowerId")
                    .HasConstraintName("FK_HeroPower_Attributes_PowerId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Superhero>()
                    .WithMany()
                    .HasForeignKey("HeroId")
                    .HasConstraintName("FK_HeroPower_Heroes_HeroId")
                    .OnDelete(DeleteBehavior.ClientCascade));

    }
}
