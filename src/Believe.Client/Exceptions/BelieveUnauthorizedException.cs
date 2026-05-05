using System.Net.Http;

namespace Believe.Client.Exceptions;

public class BelieveUnauthorizedException : Believe4xxException
{
    public BelieveUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
