namespace Domain.Entities;

public class HeroAttribute
{    
    public int AttributeId { get; set; }
    public Attribute Attribute { get; set; }

    public int SuperheroId { get; set; }
    public Superhero Superhero { get; set; }

    public int AttributeValue { get; set; }
}
