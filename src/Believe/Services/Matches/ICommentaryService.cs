using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Matches.Commentary;

namespace Believe.Services.Matches;

/// <summary>
/// Server-Sent Events (SSE) streaming endpoints
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICommentaryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICommentaryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICommentaryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Stream live match commentary for a specific match. Uses Server-Sent Events
    /// (SSE) to stream commentary events in real-time.
    /// </summary>
    Task<JsonElement> Stream(
        CommentaryStreamParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stream(CommentaryStreamParams, CancellationToken)"/>
    Task<JsonElement> Stream(
        string matchID,
        CommentaryStreamParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICommentaryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICommentaryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICommentaryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /matches/{match_id}/commentary/stream`, but is otherwise the
    /// same as <see cref="ICommentaryService.Stream(CommentaryStreamParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> Stream(
        CommentaryStreamParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stream(CommentaryStreamParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> Stream(
        string matchID,
        CommentaryStreamParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
