using System.Net.Http;

namespace Believe.Exceptions;

public class Believe5xxException : BelieveApiException
{
    public Believe5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
