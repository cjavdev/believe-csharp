using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Health;

namespace Believe.Services;

/// <inheritdoc/>
public sealed class HealthService : IHealthService
{
    readonly Lazy<IHealthServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IHealthServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IHealthService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new HealthService(this._client.WithOptions(modifier)); }

    public HealthService (IBelieveClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new HealthServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Check(
        HealthCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Check(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class HealthServiceWithRawResponse : IHealthServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IHealthServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new HealthServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public HealthServiceWithRawResponse (IBelieveClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> Check(
        HealthCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<HealthCheckParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
        });
    }
}