using System;
using Believe.Core;

namespace Believe.Services.Client;

/// <inheritdoc/>
public sealed class WService : IWService
{
    readonly Lazy<IWServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IWService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WService(this._client.WithOptions(modifier));
    }

    public WService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class WServiceWithRawResponse : IWServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;
    }
}
