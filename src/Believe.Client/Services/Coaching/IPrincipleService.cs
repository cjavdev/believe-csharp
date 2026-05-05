using System;
using System.Threading;
using System.Threading.Tasks;
using Believe.Client.Core;
using Believe.Client.Models.Coaching.Principles;

namespace Believe.Client.Services.Coaching;

/// <summary>
/// Interactive endpoints for motivation and guidance
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPrincipleService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPrincipleServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPrincipleService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get details about a specific coaching principle.
    /// </summary>
    Task<CoachingPrinciple> Retrieve(
        PrincipleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PrincipleRetrieveParams, CancellationToken)"/>
    Task<CoachingPrinciple> Retrieve(
        string principleID,
        PrincipleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a paginated list of Ted Lasso's core coaching principles and philosophy.
    /// </summary>
    Task<PrincipleListPage> List(
        PrincipleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a random coaching principle to inspire your day.
    /// </summary>
    Task<CoachingPrinciple> GetRandom(
        PrincipleGetRandomParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPrincipleService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPrincipleServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPrincipleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /coaching/principles/{principle_id}</c>, but is otherwise the
    /// same as <see cref="IPrincipleService.Retrieve(PrincipleRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CoachingPrinciple>> Retrieve(
        PrincipleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PrincipleRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CoachingPrinciple>> Retrieve(
        string principleID,
        PrincipleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /coaching/principles</c>, but is otherwise the
    /// same as <see cref="IPrincipleService.List(PrincipleListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PrincipleListPage>> List(
        PrincipleListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /coaching/principles/random</c>, but is otherwise the
    /// same as <see cref="IPrincipleService.GetRandom(PrincipleGetRandomParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CoachingPrinciple>> GetRandom(
        PrincipleGetRandomParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
