using System.Net.Http;

namespace Believe.Client.Exceptions;

public class BelieveRateLimitException : Believe4xxException
{
    public BelieveRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
