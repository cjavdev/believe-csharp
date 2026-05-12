using System.Net.Http;

namespace Believe.Client.Exceptions;

public class Believe5xxException : BelieveApiException
{
    public Believe5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
