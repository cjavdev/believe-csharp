using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Press;

namespace Believe.Services;

/// <inheritdoc/>
public sealed class PressService : IPressService
{
    readonly Lazy<IPressServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPressServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IPressService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PressService(this._client.WithOptions(modifier));
    }

    public PressService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PressServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PressSimulateResponse> Simulate(
        PressSimulateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Simulate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PressServiceWithRawResponse : IPressServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPressServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PressServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PressServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PressSimulateResponse>> Simulate(
        PressSimulateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PressSimulateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PressSimulateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
