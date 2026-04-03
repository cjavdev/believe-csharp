using System;
using System.Net.Http;

namespace Believe.Exceptions;

public class BelieveException : Exception
{
    public BelieveException (
        string message, Exception? innerException = null
    ) : base(message, innerException)
    {  }

    protected BelieveException (HttpRequestException? innerException) : base(
        null, innerException
    )
    {  }
}