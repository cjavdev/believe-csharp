using System.Net.Http;

namespace Believe.Exceptions;

public class BelieveUnexpectedStatusCodeException : BelieveApiException
{
    public BelieveUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
