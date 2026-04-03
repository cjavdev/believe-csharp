using System.Net.Http;

namespace Believe.Exceptions;

public class BelieveNotFoundException : Believe4xxException
{
    public BelieveNotFoundException (
        HttpRequestException? innerException = null
    ) : base(innerException)
    {  }
}