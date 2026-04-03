using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Stream;

namespace Believe.Services;

/// <summary>
/// Server-Sent Events (SSE) streaming endpoints
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IStreamService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IStreamServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStreamService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// A simple SSE test endpoint that streams numbers 1-5.
/// </summary>
    Task<JsonElement> TestConnection(
        StreamTestConnectionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IStreamService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IStreamServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IStreamServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /stream/test</c>, but is otherwise the
/// same as <see cref="IStreamService.TestConnection(StreamTestConnectionParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<JsonElement>> TestConnection(
        StreamTestConnectionParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}