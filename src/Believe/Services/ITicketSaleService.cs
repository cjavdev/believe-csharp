using System;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.TicketSales;

namespace Believe.Services;

/// <summary>
/// Ticket sales with 300 records for practicing pagination, filtering, and financial data
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITicketSaleService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITicketSaleServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITicketSaleService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Record a new ticket sale.
/// </summary>
    Task<TicketSale> Create(
        TicketSaleCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve detailed information about a specific ticket sale.
/// </summary>
    Task<TicketSale> Retrieve(
        TicketSaleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(TicketSaleRetrieveParams, CancellationToken)"/>
    Task<TicketSale> Retrieve(
        string ticketSaleID,
        TicketSaleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update specific fields of an existing ticket sale.
/// </summary>
    Task<TicketSale> Update(
        TicketSaleUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(TicketSaleUpdateParams, CancellationToken)"/>
    Task<TicketSale> Update(
        string ticketSaleID,
        TicketSaleUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get a paginated list of all ticket sales with optional filtering. With 300
/// records, this endpoint is ideal for practicing pagination.
/// </summary>
    Task<TicketSaleListPage> List(
        TicketSaleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Remove a ticket sale from the database.
/// </summary>
    Task Delete(
        TicketSaleDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TicketSaleDeleteParams, CancellationToken)"/>
    Task Delete(
        string ticketSaleID,
        TicketSaleDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITicketSaleService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITicketSaleServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITicketSaleServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ticket-sales</c>, but is otherwise the
/// same as <see cref="ITicketSaleService.Create(TicketSaleCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TicketSale>> Create(
        TicketSaleCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ticket-sales/{ticket_sale_id}</c>, but is otherwise the
/// same as <see cref="ITicketSaleService.Retrieve(TicketSaleRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TicketSale>> Retrieve(
        TicketSaleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(TicketSaleRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TicketSale>> Retrieve(
        string ticketSaleID,
        TicketSaleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /ticket-sales/{ticket_sale_id}</c>, but is otherwise the
/// same as <see cref="ITicketSaleService.Update(TicketSaleUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TicketSale>> Update(
        TicketSaleUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(TicketSaleUpdateParams, CancellationToken)"/>
    Task<HttpResponse<TicketSale>> Update(
        string ticketSaleID,
        TicketSaleUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ticket-sales</c>, but is otherwise the
/// same as <see cref="ITicketSaleService.List(TicketSaleListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TicketSaleListPage>> List(
        TicketSaleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ticket-sales/{ticket_sale_id}</c>, but is otherwise the
/// same as <see cref="ITicketSaleService.Delete(TicketSaleDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        TicketSaleDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TicketSaleDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string ticketSaleID,
        TicketSaleDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}