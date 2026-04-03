using System;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Conflicts;

namespace Believe.Services;

/// <summary>
/// Interactive endpoints for motivation and guidance
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IConflictService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConflictServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConflictService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Get Ted Lasso-style advice for resolving conflicts.
/// </summary>
    Task<ConflictResolveResponse> Resolve(
        ConflictResolveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IConflictService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConflictServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConflictServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /conflicts/resolve</c>, but is otherwise the
/// same as <see cref="IConflictService.Resolve(ConflictResolveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ConflictResolveResponse>> Resolve(
        ConflictResolveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}