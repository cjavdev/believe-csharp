using System;
using System.Net.Http;

namespace Believe.Exceptions;

public class BelieveIOException : BelieveException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public BelieveIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
