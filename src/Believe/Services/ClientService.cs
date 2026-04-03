using System;
using Believe.Core;
using Believe.Services.Client;

namespace Believe.Services;

/// <inheritdoc/>
public sealed class ClientService : IClientService
{
    readonly Lazy<IClientServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IClientServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IClientService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ClientService(this._client.WithOptions(modifier)); }

    public ClientService (IBelieveClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ClientServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _ws =new(() => new WService(client)) ;
    }

    readonly Lazy<IWService> _ws;
    public IWService Ws { get { return _ws.Value; } }
}

/// <inheritdoc/>
public sealed class ClientServiceWithRawResponse : IClientServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IClientServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ClientServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ClientServiceWithRawResponse (IBelieveClientWithRawResponse client)
    {
        _client =client ;

        _ws =new(() => new WServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IWServiceWithRawResponse> _ws;
    public IWServiceWithRawResponse Ws { get { return _ws.Value; } }
}