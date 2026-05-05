using System.Net.Http;

namespace Believe.Client.Exceptions;

public class BelieveUnexpectedStatusCodeException : BelieveApiException
{
    public BelieveUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
