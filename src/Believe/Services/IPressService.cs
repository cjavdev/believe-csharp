using System;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Press;

namespace Believe.Services;

/// <summary>
/// Interactive endpoints for motivation and guidance
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IPressService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPressServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPressService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Get Ted's response to press conference questions.
/// </summary>
    Task<PressSimulateResponse> Simulate(
        PressSimulateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IPressService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPressServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPressServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /press</c>, but is otherwise the
/// same as <see cref="IPressService.Simulate(PressSimulateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<PressSimulateResponse>> Simulate(
        PressSimulateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;
}