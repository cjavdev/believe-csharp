using System.Net.Http;

namespace Believe.Exceptions;

public class BelieveBadRequestException : Believe4xxException
{
    public BelieveBadRequestException (
        HttpRequestException? innerException = null
    ) : base(innerException)
    {  }
}