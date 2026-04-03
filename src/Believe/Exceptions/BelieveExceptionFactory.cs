using System.Net;

namespace Believe.Exceptions;

public class BelieveExceptionFactory
{
    public static BelieveApiException CreateApiException(
        HttpStatusCode statusCode, string responseBody
    )
    {
        return (int) statusCode switch
        {
            400=>new BelieveBadRequestException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            401=>new BelieveUnauthorizedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            403=>new BelieveForbiddenException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            404=>new BelieveNotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            422=>new BelieveUnprocessableEntityException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            429=>new BelieveRateLimitException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 400 and <= 499=>new Believe4xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 500 and <= 599=>new Believe5xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            _ =>new BelieveUnexpectedStatusCodeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            }
        };
    }
}