using System.Net.Http;

namespace Believe.Client.Exceptions;

public class BelieveForbiddenException : Believe4xxException
{
    public BelieveForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
