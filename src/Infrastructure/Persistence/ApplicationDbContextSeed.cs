using Domain.Entities;
using Domain.ValueObjects;

namespace Infrastructure.Persistence;

public class ApplicationDbContextSeed
{
    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        // Seed, if necessary
        if (!context.Attributes.Any())
        {
            context.Attributes.Add(new Domain.Entities.Attribute { Id = 1, AttributeName = "Intelligence" });
            context.Attributes.Add(new Domain.Entities.Attribute { Id = 2, AttributeName = "Strength" });
            context.Attributes.Add(new Domain.Entities.Attribute { Id = 3, AttributeName = "Speed" });
            context.Attributes.Add(new Domain.Entities.Attribute { Id = 4, AttributeName = "Durability" });
            context.Attributes.Add(new Domain.Entities.Attribute { Id = 5, AttributeName = "Power" });
            context.Attributes.Add(new Domain.Entities.Attribute { Id = 6, AttributeName = "Combat" });
            //..

            //context.HeroAttributes.Add(new HeroAttribute {  AttributeId = 1, SuperheroId = 1 });
            //...

            //context.HeroPowers.Add(new HeroPower { HeroId = 1, PowerId = 1 });
            //...

            context.Publishers.Add(new Publisher { Id = 1,  Publisher1 = "ABC Studios" });
            context.Publishers.Add(new Publisher { Id = 2, Publisher1 = "DC Comics" });
            context.Publishers.Add(new Publisher { Id = 3, Publisher1 = "George Lucas" });
            context.Publishers.Add(new Publisher { Id = 4, Publisher1 = "Icon Comics" });
            context.Publishers.Add(new Publisher { Id = 5, Publisher1 = "J. K. Rowling" });
            context.Publishers.Add(new Publisher { Id = 6, Publisher1 = "Marvel Comics" });
            //...

            context.Races.Add(new Race { Id = 1, Race1 = "Alien" });
            context.Races.Add(new Race { Id = 2, Race1 = "Android" });
            context.Races.Add(new Race { Id = 3, Race1 = "Animal" });
            context.Races.Add(new Race { Id = 4, Race1 = "Demon" });
            context.Races.Add(new Race { Id = 5, Race1 = "Eternal" });
            context.Races.Add(new Race { Id = 6, Race1 = "Human" });
            //...

            context.Superheroes.Add(new Superhero
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
                    new HeroAttribute { AttributeId = 6 },
                    new HeroAttribute { AttributeId = 2 }
                }
            });
            context.Superheroes.Add(new Superhero
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
                    new HeroAttribute { AttributeId = 3 },
                    new HeroAttribute { AttributeId = 4 }
                },
                Powers =
                {
                    new HeroPower { PowerId = 1, HeroId = 2 },
                    new HeroPower { PowerId = 2, HeroId = 2 }
                }
            });
            context.Superheroes.Add(new Superhero
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
                    new HeroAttribute { AttributeId = 1 },
                    new HeroAttribute { AttributeId = 2 }
                },
                Powers =
                {
                    new HeroPower { PowerId = 3, HeroId = 3 },
                    new HeroPower { PowerId = 4, HeroId = 3 }
                }
            });
            context.Superheroes.Add(new Superhero
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
                    new HeroAttribute { AttributeId = 1 },
                    new HeroAttribute { AttributeId = 4 }
                },
                Powers =
                {
                    new HeroPower { PowerId = 1, HeroId = 4 },
                    new HeroPower { PowerId = 2, HeroId = 4 }
                }
            });
            context.Superheroes.Add(new Superhero
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
                    new HeroAttribute { AttributeId = 3 },
                    new HeroAttribute { AttributeId = 5 }
                },
                Powers =
                {
                    new HeroPower { PowerId = 5, HeroId = 5 },
                    new HeroPower { PowerId = 6, HeroId = 5 }
                }
            });
            //...

            context.Superpowers.Add(new Superpower { Id = 1, PowerName = "Agility" });
            context.Superpowers.Add(new Superpower { Id = 2, PowerName = "Accelerated Healing" });
            context.Superpowers.Add(new Superpower { Id = 3, PowerName = "Lantern Power Ring" });
            context.Superpowers.Add(new Superpower { Id = 4, PowerName = "Cold Resistance" });
            context.Superpowers.Add(new Superpower { Id = 5, PowerName = "Marksmanship" });
            context.Superpowers.Add(new Superpower { Id = 6, PowerName = "Power Augmentation" });
            //...

            await context.SaveChangesAsync();
        }
    }
}


