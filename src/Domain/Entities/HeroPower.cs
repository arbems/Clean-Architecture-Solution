namespace Domain.Entities;

public class HeroPower
{
    public int? HeroId { get; set; }
    public int? PowerId { get; set; }

    public Superhero? Hero { get; set; }
    public Superpower? Power { get; set; }
}