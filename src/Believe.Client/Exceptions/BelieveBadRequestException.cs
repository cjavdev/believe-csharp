using System.Net.Http;

namespace Believe.Client.Exceptions;

public class BelieveBadRequestException : Believe4xxException
{
    public BelieveBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
