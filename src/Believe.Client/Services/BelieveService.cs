using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Believe.Client.Core;
using Believe.Client.Models.Believe;

namespace Believe.Client.Services;

/// <inheritdoc/>
public sealed class BelieveService : IBelieveService
{
    readonly Lazy<IBelieveServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBelieveServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IBelieveService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BelieveService(this._client.WithOptions(modifier));
    }

    public BelieveService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BelieveServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BelieveSubmitResponse> Submit(
        BelieveSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Submit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BelieveServiceWithRawResponse : IBelieveServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBelieveServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BelieveServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BelieveServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BelieveSubmitResponse>> Submit(
        BelieveSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BelieveSubmitParams> request = new()
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
                    .Deserialize<BelieveSubmitResponse>(token)
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
