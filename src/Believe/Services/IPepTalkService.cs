using System;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.PepTalk;

namespace Believe.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPepTalkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPepTalkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPepTalkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a motivational pep talk from Ted Lasso himself. By default returns the
    /// complete pep talk. Add `?stream=true` to get Server-Sent Events (SSE) streaming
    /// the pep talk chunk by chunk.
    /// </summary>
    Task<PepTalkRetrieveResponse> Retrieve(
        PepTalkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPepTalkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPepTalkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPepTalkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /pep-talk`, but is otherwise the
    /// same as <see cref="IPepTalkService.Retrieve(PepTalkRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PepTalkRetrieveResponse>> Retrieve(
        PepTalkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
