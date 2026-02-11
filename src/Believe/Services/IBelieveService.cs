using System;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Believe;

namespace Believe.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBelieveService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBelieveServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBelieveService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Submit your situation and receive Ted Lasso-style motivational guidance.
    /// </summary>
    Task<BelieveSubmitResponse> Submit(
        BelieveSubmitParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBelieveService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBelieveServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBelieveServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /believe`, but is otherwise the
    /// same as <see cref="IBelieveService.Submit(BelieveSubmitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BelieveSubmitResponse>> Submit(
        BelieveSubmitParams parameters,
        CancellationToken cancellationToken = default
    );
}
