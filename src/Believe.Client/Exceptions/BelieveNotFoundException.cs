using System.Net.Http;

namespace Believe.Client.Exceptions;

public class BelieveNotFoundException : Believe4xxException
{
    public BelieveNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
