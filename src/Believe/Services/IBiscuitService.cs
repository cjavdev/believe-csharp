using System;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Biscuits;

namespace Believe.Services;

/// <summary>
/// Interactive endpoints for motivation and guidance
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBiscuitService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBiscuitServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBiscuitService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a specific type of biscuit by ID.
    /// </summary>
    Task<Biscuit> Retrieve(
        BiscuitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BiscuitRetrieveParams, CancellationToken)"/>
    Task<Biscuit> Retrieve(
        string biscuitID,
        BiscuitRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a paginated list of Ted's famous homemade biscuits! Each comes with a
    /// heartwarming message.
    /// </summary>
    Task<BiscuitListPage> List(
        BiscuitListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single fresh biscuit with a personalized message from Ted.
    /// </summary>
    Task<Biscuit> GetFresh(
        BiscuitGetFreshParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBiscuitService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBiscuitServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBiscuitServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /biscuits/{biscuit_id}`, but is otherwise the
    /// same as <see cref="IBiscuitService.Retrieve(BiscuitRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Biscuit>> Retrieve(
        BiscuitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BiscuitRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Biscuit>> Retrieve(
        string biscuitID,
        BiscuitRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /biscuits`, but is otherwise the
    /// same as <see cref="IBiscuitService.List(BiscuitListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BiscuitListPage>> List(
        BiscuitListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /biscuits/fresh`, but is otherwise the
    /// same as <see cref="IBiscuitService.GetFresh(BiscuitGetFreshParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Biscuit>> GetFresh(
        BiscuitGetFreshParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
