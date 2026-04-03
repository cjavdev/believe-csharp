using System;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Reframe;

namespace Believe.Services;

/// <summary>
/// Interactive endpoints for motivation and guidance
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IReframeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReframeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReframeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Transform negative thoughts into positive perspectives with Ted's help.
/// </summary>
    Task<ReframeTransformNegativeThoughtsResponse> TransformNegativeThoughts(
        ReframeTransformNegativeThoughtsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IReframeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReframeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReframeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /reframe</c>, but is otherwise the
/// same as <see cref="IReframeService.TransformNegativeThoughts(ReframeTransformNegativeThoughtsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<ReframeTransformNegativeThoughtsResponse>> TransformNegativeThoughts(
        ReframeTransformNegativeThoughtsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}