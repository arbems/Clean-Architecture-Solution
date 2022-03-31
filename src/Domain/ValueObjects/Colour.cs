using Domain.Common;
using Domain.Exceptions;

namespace Domain.ValueObjects;

public class Colour : ValueObject
{
    static Colour()
    {
    }

    private Colour()
    {
    }

    private Colour(string code)
    {
        Code = code;
    }

    public static Colour From(string code)
    {
        var colour = new Colour { Code = code };

        if (!SupportedColours.Contains(colour))
        {
            throw new UnsupportedColourException(code);
        }

        return colour;
    }

    public static Colour NoColour => new("No Colour");
    public static Colour Amber => new("Amber");
    public static Colour Auburn => new("Auburn");
    public static Colour Black => new("Black");
    public static Colour BlackBlue => new ("Black/Blue");
    public static Colour Blond => new("Blond");
    public static Colour Blue => new("Blue");
    public static Colour BlueWhite => new ("Blue/White");
    public static Colour Brown => new("Brown");
    public static Colour BrownBlack => new ("Brown/Black");
    public static Colour BrownWhite => new ("Brown/White");
    public static Colour Gold => new("Gold");
    public static Colour Grey => new("Grey");
    public static Colour Green => new("Green");
    public static Colour GreenBlue => new ("Green/Blue");
    public static Colour Hazel => new("Hazel");
    public static Colour Indigo => new("Indigo");
    public static Colour Magenta => new("Magenta");
    public static Colour Orange => new("Orange");
    public static Colour OrangeWhite => new ("Orange/White");
    public static Colour Pink => new("Pink");
    public static Colour Purple => new("Purple");
    public static Colour Red => new("Red");
    public static Colour RedBlack => new ("Red/Black");
    public static Colour RedGrey => new ("Red/Grey");
    public static Colour RedOrange => new ("Red/Orange");
    public static Colour RedWhite => new ("Red/White");
    public static Colour Silver => new("Silver");
    public static Colour StrawberryBlond => new ("Strawberry/Blond");
    public static Colour Violet => new("Violet");
    public static Colour White => new("White");
    public static Colour WhiteRed => new ("White/Red");
    public static Colour Yellow => new("Yellow");
    public static Colour YellowBlue => new ("Yellow/Blue");
    public static Colour YellowRed => new ("Yellow/Red");

    public string Code { get; private set; } = "No Colour";

    public static implicit operator string(Colour colour)
    {
        return colour;
    }

    public static explicit operator Colour(string code)
    {
        return From(code);
    }

    public override string ToString()
    {
        return Code;
    }

    protected static IEnumerable<Colour> SupportedColours
    {
        get
        {
            yield return Amber;
            yield return Auburn;
            yield return Black;
            yield return BlackBlue;
            yield return Blond;
            yield return Blue;
            yield return BlueWhite;
            yield return Brown;
            yield return BrownBlack;
            yield return BrownWhite;
            yield return Gold;
            yield return Grey;
            yield return Green;
            yield return GreenBlue;
            yield return Hazel;
            yield return Indigo;
            yield return Magenta;
            yield return Orange;
            yield return OrangeWhite;
            yield return Pink;
            yield return Purple;
            yield return Red;
            yield return RedBlack;
            yield return RedGrey;
            yield return RedOrange;
            yield return RedWhite;
            yield return Silver;
            yield return StrawberryBlond;
            yield return Violet;
            yield return White;
            yield return WhiteRed;
            yield return Yellow;
            yield return YellowBlue;
            yield return YellowRed;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}
