using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Stream;

namespace Believe.Services;

/// <inheritdoc/>
public sealed class StreamService : IStreamService
{
    readonly Lazy<IStreamServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IStreamServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IStreamService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StreamService(this._client.WithOptions(modifier));
    }

    public StreamService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new StreamServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<JsonElement> TestConnection(
        StreamTestConnectionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.TestConnection(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class StreamServiceWithRawResponse : IStreamServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IStreamServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new StreamServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public StreamServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> TestConnection(
        StreamTestConnectionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<StreamTestConnectionParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }
}
