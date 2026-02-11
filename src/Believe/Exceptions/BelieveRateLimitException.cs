using System.Net.Http;

namespace Believe.Exceptions;

public class BelieveRateLimitException : Believe4xxException
{
    public BelieveRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
