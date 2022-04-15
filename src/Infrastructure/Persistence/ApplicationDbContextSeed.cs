using Domain.Entities;
using Domain.ValueObjects;

namespace Infrastructure.Persistence;

public class ApplicationDbContextSeed
{
    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        if (!context.Attributes.Any())
        {
            context.Publishers.AddRange(
                new Publisher { Id = 1, PublisherName = "ABC Studios" },
                new Publisher { Id = 2, PublisherName = "DC Comics" },
                new Publisher { Id = 3, PublisherName = "George Lucas" },
                new Publisher { Id = 4, PublisherName = "Icon Comics" },
                new Publisher { Id = 5, PublisherName = "J. K. Rowling" },
                new Publisher { Id = 6, PublisherName = "Marvel Comics" }
            );

            context.Races.AddRange(
                new Race { Id = 1, RaceName = "Alien" },
                new Race { Id = 2, RaceName = "Android" },
                new Race { Id = 3, RaceName = "Animal" },
                new Race { Id = 4, RaceName = "Demon" },
                new Race { Id = 5, RaceName = "Eternal" },
                new Race { Id = 6, RaceName = "Human" }
            );

            context.Attributes.AddRange(
                new Domain.Entities.Attribute { Id = 1, AttributeName = "Intelligence" },
                new Domain.Entities.Attribute { Id = 2, AttributeName = "Strength" },
                new Domain.Entities.Attribute { Id = 3, AttributeName = "Speed" },
                new Domain.Entities.Attribute { Id = 4, AttributeName = "Durability" },
                new Domain.Entities.Attribute { Id = 5, AttributeName = "Power" },
                new Domain.Entities.Attribute { Id = 6, AttributeName = "Combat" }
            );

            context.Powers.AddRange(
                new Power { Id = 1, PowerName = "Agility" },
                new Power { Id = 2, PowerName = "Accelerated Healing" },
                new Power { Id = 3, PowerName = "Lantern Power Ring" },
                new Power { Id = 4, PowerName = "Cold Resistance" },
                new Power { Id = 5, PowerName = "Marksmanship" },
                new Power { Id = 6, PowerName = "Power Augmentation" }
            );

            await context.SaveChangesAsync();

            context.Superheroes.AddRange(
                new Superhero
                {
                    Id = 1,
                    Alignment = Alignment.Good,
                    EyeColour = Colour.Amber,
                    Gender = Gender.Male,
                    HairColour = Colour.Auburn,
                    HeightCm = 183,
                    WeightKg = 83,
                    PublisherId = 1,
                    RaceId = 1,
                    SkinColour = Colour.Black,
                    SuperheroName = "Animal Man",
                    FullName = "Bernhard Baker",
                    Attributes =
                    {
                        context.Attributes.FindAsync(1).Result!,
                        context.Attributes.FindAsync(2).Result!
                    },
                    Powers =
                    {
                        context.Powers.FindAsync(3).Result!,
                        context.Powers.FindAsync(4).Result!
                    }
                },
                new Superhero
                {
                    Id = 2,
                    Alignment = Alignment.Good,
                    EyeColour = Colour.Amber,
                    Gender = Gender.Male,
                    HairColour = Colour.Auburn,
                    HeightCm = 180,
                    WeightKg = 85,
                    PublisherId = 1,
                    RaceId = 1,
                    SkinColour = Colour.Black,
                    SuperheroName = "Ant-Man",
                    FullName = "Henry Jonathan Pym",
                    Attributes =
                    {
                        context.Attributes.FindAsync(1).Result!,
                        context.Attributes.FindAsync(2).Result!
                    },
                        Powers =
                    {
                        context.Powers.FindAsync(3).Result!,
                        context.Powers.FindAsync(4).Result!
                    }
                },
                new Superhero
                {
                    Id = 3,
                    Alignment = Alignment.Good,
                    EyeColour = Colour.Amber,
                    Gender = Gender.Male,
                    HairColour = Colour.Auburn,
                    HeightCm = 188,
                    WeightKg = 95,
                    PublisherId = 1,
                    RaceId = 1,
                    SkinColour = Colour.Black,
                    SuperheroName = "Batman",
                    FullName = "Bruce Wayne",
                    Attributes =
                    {
                        context.Attributes.FindAsync(1).Result!,
                        context.Attributes.FindAsync(2).Result!
                    },
                        Powers =
                    {
                        context.Powers.FindAsync(3).Result!,
                        context.Powers.FindAsync(4).Result!
                    }
                },
                new Superhero
                {
                    Id = 4,
                    Alignment = Alignment.Good,
                    EyeColour = Colour.Amber,
                    Gender = Gender.Male,
                    HairColour = Colour.Auburn,
                    HeightCm = 160,
                    WeightKg = 90,
                    PublisherId = 1,
                    RaceId = 1,
                    SkinColour = Colour.Black,
                    SuperheroName = "Bionic Woman",
                    FullName = "Jamie Wells Sommers",
                    Attributes =
                    {
                        context.Attributes.FindAsync(1).Result!,
                        context.Attributes.FindAsync(2).Result!
                    },
                        Powers =
                    {
                        context.Powers.FindAsync(3).Result!,
                        context.Powers.FindAsync(4).Result!
                    }
                },
                new Superhero
                {
                    Id = 5,
                    Alignment = Alignment.Good,
                    EyeColour = Colour.Amber,
                    Gender = Gender.Male,
                    HairColour = Colour.Auburn,
                    HeightCm = 170,
                    WeightKg = 87,
                    PublisherId = 1,
                    RaceId = 1,
                    SkinColour = Colour.Black,
                    SuperheroName = "Black Bolt",
                    FullName = "Blackagar Boltagon",
                    Attributes =
                    {
                        context.Attributes.FindAsync(1).Result!,
                        context.Attributes.FindAsync(2).Result!
                    },
                        Powers =
                    {
                        context.Powers.FindAsync(3).Result!,
                        context.Powers.FindAsync(4).Result!
                    }
                }
            );

            await context.SaveChangesAsync();
        }
    }
}


