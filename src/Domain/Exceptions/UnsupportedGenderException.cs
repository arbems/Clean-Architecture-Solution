using System;

namespace Domain.Exceptions;

public class UnsupportedGenderException : Exception
{
    public UnsupportedGenderException(string gender)
        : base($"Gender \"{gender}\" is unsupported.")
    {
    }
}


