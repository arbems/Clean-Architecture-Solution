using System;

namespace Domain.Exceptions;

public class UnsupportedAlignmentException : Exception
{
    public UnsupportedAlignmentException(string gender)
        : base($"Alignment \"{gender}\" is unsupported.")
    {
    }
}


