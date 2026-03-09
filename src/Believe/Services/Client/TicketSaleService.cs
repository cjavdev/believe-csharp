using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Client.TicketSales;

namespace Believe.Services.Client;

/// <inheritdoc/>
public sealed class TicketSaleService : ITicketSaleService
{
    readonly Lazy<ITicketSaleServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITicketSaleServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public ITicketSaleService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TicketSaleService(this._client.WithOptions(modifier));
    }

    public TicketSaleService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TicketSaleServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TicketSaleCreateResponse> Create(
        TicketSaleCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TicketSaleRetrieveResponse> Retrieve(
        TicketSaleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TicketSaleRetrieveResponse> Retrieve(
        string ticketSaleID,
        TicketSaleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TicketSaleID = ticketSaleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TicketSaleUpdateResponse> Update(
        TicketSaleUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TicketSaleUpdateResponse> Update(
        string ticketSaleID,
        TicketSaleUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { TicketSaleID = ticketSaleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TicketSaleListPage> List(
        TicketSaleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        TicketSaleDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string ticketSaleID,
        TicketSaleDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { TicketSaleID = ticketSaleID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TicketSaleServiceWithRawResponse : ITicketSaleServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITicketSaleServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TicketSaleServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TicketSaleServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TicketSaleCreateResponse>> Create(
        TicketSaleCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TicketSaleCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ticketSale = await response
                    .Deserialize<TicketSaleCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ticketSale.Validate();
                }
                return ticketSale;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TicketSaleRetrieveResponse>> Retrieve(
        TicketSaleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TicketSaleID == null)
        {
            throw new BelieveInvalidDataException("'parameters.TicketSaleID' cannot be null");
        }

        HttpRequest<TicketSaleRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ticketSale = await response
                    .Deserialize<TicketSaleRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ticketSale.Validate();
                }
                return ticketSale;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TicketSaleRetrieveResponse>> Retrieve(
        string ticketSaleID,
        TicketSaleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TicketSaleID = ticketSaleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TicketSaleUpdateResponse>> Update(
        TicketSaleUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TicketSaleID == null)
        {
            throw new BelieveInvalidDataException("'parameters.TicketSaleID' cannot be null");
        }

        HttpRequest<TicketSaleUpdateParams> request = new()
        {
            Method = BelieveClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var ticketSale = await response
                    .Deserialize<TicketSaleUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    ticketSale.Validate();
                }
                return ticketSale;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TicketSaleUpdateResponse>> Update(
        string ticketSaleID,
        TicketSaleUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { TicketSaleID = ticketSaleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TicketSaleListPage>> List(
        TicketSaleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TicketSaleListParams> request = new()
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
                    .Deserialize<TicketSaleListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TicketSaleListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TicketSaleDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TicketSaleID == null)
        {
            throw new BelieveInvalidDataException("'parameters.TicketSaleID' cannot be null");
        }

        HttpRequest<TicketSaleDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string ticketSaleID,
        TicketSaleDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { TicketSaleID = ticketSaleID }, cancellationToken);
    }
}
