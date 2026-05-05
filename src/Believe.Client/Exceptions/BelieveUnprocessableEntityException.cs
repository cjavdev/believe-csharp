using System.Net.Http;

namespace Believe.Client.Exceptions;

public class BelieveUnprocessableEntityException : Believe4xxException
{
    public BelieveUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
