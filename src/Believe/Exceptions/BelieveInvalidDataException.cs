using System;

namespace Believe.Exceptions;

public class BelieveInvalidDataException : BelieveException
{
    public BelieveInvalidDataException (
        string message, Exception? innerException = null
    ) : base(message, innerException)
    {  }
}