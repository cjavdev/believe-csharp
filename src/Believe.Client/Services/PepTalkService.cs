using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Believe.Client.Core;
using Believe.Client.Models.PepTalk;

namespace Believe.Client.Services;

/// <inheritdoc/>
public sealed class PepTalkService : IPepTalkService
{
    readonly Lazy<IPepTalkServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPepTalkServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IPepTalkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PepTalkService(this._client.WithOptions(modifier));
    }

    public PepTalkService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PepTalkServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PepTalkRetrieveResponse> Retrieve(
        PepTalkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PepTalkServiceWithRawResponse : IPepTalkServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPepTalkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PepTalkServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PepTalkServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PepTalkRetrieveResponse>> Retrieve(
        PepTalkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PepTalkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pepTalk = await response
                    .Deserialize<PepTalkRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pepTalk.Validate();
                }
                return pepTalk;
            }
        );
    }
}
