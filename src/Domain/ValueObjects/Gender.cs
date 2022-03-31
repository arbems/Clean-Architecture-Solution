using Domain.Common;
using Domain.Exceptions;

namespace Domain.ValueObjects;

public class Gender : ValueObject
{
    static Gender()
    {
    }

    private Gender()
    {
    }

    private Gender(string gender)
    {
        Value = gender;
    }

    public static Gender From(string value)
    {
        var gender = new Gender { Value = value };

        if (!SupportedGenders.Contains(gender))
        {
            throw new UnsupportedGenderException(gender);
        }

        return gender;
    }       

    public static Gender Male => new("Male");
    public static Gender Female => new("Female");
    public static Gender NA => new("N/A");

    public string Value { get; private set; } = "N/A";

    public static implicit operator string(Gender gender)
    {
        return gender;
    }

    public static explicit operator Gender(string gender)
    {
        return From(gender);
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    protected static IEnumerable<Gender> SupportedGenders
    {
        get
        {
            yield return Male;
            yield return Female;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
