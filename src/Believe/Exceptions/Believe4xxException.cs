using System.Net.Http;

namespace Believe.Exceptions;

public class Believe4xxException : BelieveApiException
{
    public Believe4xxException (
        HttpRequestException? innerException = null
    ) : base(innerException)
    {  }
}