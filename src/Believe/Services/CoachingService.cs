using System;
using Believe.Core;
using Believe.Services.Coaching;

namespace Believe.Services;

/// <inheritdoc/>
public sealed class CoachingService : ICoachingService
{
    readonly Lazy<ICoachingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICoachingServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public ICoachingService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new CoachingService(this._client.WithOptions(modifier)); }

    public CoachingService (IBelieveClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new CoachingServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _principles =new(() => new PrincipleService(client)) ;
    }

    readonly Lazy<IPrincipleService> _principles;
    public IPrincipleService Principles { get { return _principles.Value; } }
}

/// <inheritdoc/>
public sealed class CoachingServiceWithRawResponse : ICoachingServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICoachingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CoachingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CoachingServiceWithRawResponse (IBelieveClientWithRawResponse client)
    {
        _client =client ;

        _principles =new(() => new PrincipleServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IPrincipleServiceWithRawResponse> _principles;
    public IPrincipleServiceWithRawResponse Principles {
        get { return _principles.Value; }
    }
}