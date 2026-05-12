using System.Net.Http;

namespace Believe.Client.Exceptions;

public class Believe4xxException : BelieveApiException
{
    public Believe4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
