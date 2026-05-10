using System;

namespace Believe.Client.Exceptions;

public class BelieveInvalidDataException : BelieveException
{
    public BelieveInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
