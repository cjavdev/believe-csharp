using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Believe.Client.Core;
using Believe.Client.Models.Client.Ws;

namespace Believe.Client.Services.Client;

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

    /// <inheritdoc/>
    public Task Test(WTestParams? parameters = null, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Test(parameters, cancellationToken);
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

    /// <inheritdoc/>
    public Task<HttpResponse> Test(
        WTestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WTestParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        return this._client.Execute(request, cancellationToken);
    }
}
