using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Believe.Client.Core;
using Believe.Client.Exceptions;
using Believe.Client.Models.Biscuits;

namespace Believe.Client.Services;

/// <inheritdoc/>
public sealed class BiscuitService : IBiscuitService
{
    readonly Lazy<IBiscuitServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBiscuitServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IBiscuitService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BiscuitService(this._client.WithOptions(modifier));
    }

    public BiscuitService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BiscuitServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Biscuit> Retrieve(
        BiscuitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Biscuit> Retrieve(
        string biscuitID,
        BiscuitRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BiscuitID = biscuitID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BiscuitListPage> List(
        BiscuitListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Biscuit> GetFresh(
        BiscuitGetFreshParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetFresh(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BiscuitServiceWithRawResponse : IBiscuitServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBiscuitServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BiscuitServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BiscuitServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Biscuit>> Retrieve(
        BiscuitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BiscuitID == null)
        {
            throw new BelieveInvalidDataException("'parameters.BiscuitID' cannot be null");
        }

        HttpRequest<BiscuitRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var biscuit = await response.Deserialize<Biscuit>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    biscuit.Validate();
                }
                return biscuit;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Biscuit>> Retrieve(
        string biscuitID,
        BiscuitRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BiscuitID = biscuitID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BiscuitListPage>> List(
        BiscuitListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BiscuitListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<BiscuitListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BiscuitListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Biscuit>> GetFresh(
        BiscuitGetFreshParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BiscuitGetFreshParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var biscuit = await response.Deserialize<Biscuit>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    biscuit.Validate();
                }
                return biscuit;
            }
        );
    }
}
