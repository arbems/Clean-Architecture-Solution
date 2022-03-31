using Domain.Common;
using Domain.Exceptions;

namespace Domain.ValueObjects;

public class Alignment : ValueObject
{
    static Alignment()
    {
    }

    private Alignment()
    {
    }

    private Alignment(string alignment)
    {
        Value = alignment;
    }

    public static Alignment From(string alignment)
    {
        var Value = new Alignment { Value = alignment };

        if (!SupportedAlignments.Contains(Value))
        {
            throw new UnsupportedAlignmentException(alignment);
        }

        return Value;
    }
        
    public static Alignment Good => new("Good");
    public static Alignment Bad => new("Bad");
    public static Alignment Neutral => new("Neutral");
    public static Alignment NA => new("N/A");

    public string Value { get; private set; } = "N/A";

    public static implicit operator string(Alignment alignment)
    {
        return alignment;
    }

    public static explicit operator Alignment(string alignment)
    {
        return From(alignment);
    }

    public override string ToString()
    {
        return Value;
    }

    protected static IEnumerable<Alignment> SupportedAlignments
    {
        get
        {
            yield return Good;
            yield return Bad;
            yield return Neutral;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
