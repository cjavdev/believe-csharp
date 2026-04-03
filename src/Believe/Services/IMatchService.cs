using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Matches;
using Believe.Services.Matches;

namespace Believe.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMatchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMatchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMatchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    ICommentaryService Commentary { get; }

    /// <summary>
/// Schedule a new match.
/// </summary>
    Task<Match> Create(
        MatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve detailed information about a specific match.
/// </summary>
    Task<Match> Retrieve(
        MatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MatchRetrieveParams, CancellationToken)"/>
    Task<Match> Retrieve(
        string matchID,
        MatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update specific fields of an existing match (e.g., update score).
/// </summary>
    Task<Match> Update(
        MatchUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MatchUpdateParams, CancellationToken)"/>
    Task<Match> Update(
        string matchID,
        MatchUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get a paginated list of all matches with optional filtering.
/// </summary>
    Task<MatchListPage> List(
        MatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Remove a match from the database.
/// </summary>
    Task Delete(
        MatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MatchDeleteParams, CancellationToken)"/>
    Task Delete(
        string matchID,
        MatchDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get the life lesson learned from a specific match.
/// </summary>
    Task<Dictionary<string, JsonElement>> GetLesson(
        MatchGetLessonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetLesson(MatchGetLessonParams, CancellationToken)"/>
    Task<Dictionary<string, JsonElement>> GetLesson(
        string matchID,
        MatchGetLessonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get all turning points from a specific match.
/// </summary>
    Task<List<Dictionary<string, JsonElement>>> GetTurningPoints(
        MatchGetTurningPointsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetTurningPoints(MatchGetTurningPointsParams, CancellationToken)"/>
    Task<List<Dictionary<string, JsonElement>>> GetTurningPoints(
        string matchID,
        MatchGetTurningPointsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// WebSocket endpoint for real-time live match simulation.
/// 
/// <para>Connect to receive a stream of match events as they happen in a simulated
/// football match.</para>
/// 
/// <para>## Connection</para>
/// 
/// <para>Connect via WebSocket with optional query parameters to customize the
/// simulation.</para>
/// 
/// <para>## Example WebSocket URL</para>
/// 
/// <para>```
/// ws://localhost:8000/matches/live?home_team=AFC%20Richmond&away_team=Manchester%20City&speed=2.0&excitement_level=7
/// ```</para>
/// 
/// <para>## Server Messages</para>
/// 
/// <para>The server sends JSON messages with these types: - `match_start` - When
/// the match begins - `match_event` - For each match event (goals, fouls, cards,
/// etc.) - `match_end` - When the match concludes - `error` - If an error occurs -
/// `pong` - Response to client ping</para>
/// 
/// <para>## Client Messages</para>
/// 
/// <para>Send JSON to control the simulation: - `{"action": "ping"}` - Keep-alive,
/// server responds with `{"type": "pong"}` - `{"action": "pause"}` - Pause the
/// simulation - `{"action": "resume"}` - Resume a paused simulation - `{"action":
/// "set_speed", "speed": 2.0}` - Change playback speed (0.1-10.0) - `{"action":
/// "get_status"}` - Request current match status </para>
/// </summary>
    Task StreamLive(
        MatchStreamLiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMatchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMatchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMatchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ICommentaryServiceWithRawResponse Commentary { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /matches</c>, but is otherwise the
/// same as <see cref="IMatchService.Create(MatchCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Match>> Create(
        MatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /matches/{match_id}</c>, but is otherwise the
/// same as <see cref="IMatchService.Retrieve(MatchRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Match>> Retrieve(
        MatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(MatchRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Match>> Retrieve(
        string matchID,
        MatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /matches/{match_id}</c>, but is otherwise the
/// same as <see cref="IMatchService.Update(MatchUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Match>> Update(
        MatchUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(MatchUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Match>> Update(
        string matchID,
        MatchUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /matches</c>, but is otherwise the
/// same as <see cref="IMatchService.List(MatchListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<MatchListPage>> List(
        MatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /matches/{match_id}</c>, but is otherwise the
/// same as <see cref="IMatchService.Delete(MatchDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        MatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(MatchDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string matchID,
        MatchDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /matches/{match_id}/lesson</c>, but is otherwise the
/// same as <see cref="IMatchService.GetLesson(MatchGetLessonParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> GetLesson(
        MatchGetLessonParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetLesson(MatchGetLessonParams, CancellationToken)"/>
    Task<HttpResponse<Dictionary<string, JsonElement>>> GetLesson(
        string matchID,
        MatchGetLessonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /matches/{match_id}/turning-points</c>, but is otherwise the
/// same as <see cref="IMatchService.GetTurningPoints(MatchGetTurningPointsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<List<Dictionary<string, JsonElement>>>> GetTurningPoints(
        MatchGetTurningPointsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetTurningPoints(MatchGetTurningPointsParams, CancellationToken)"/>
    Task<HttpResponse<List<Dictionary<string, JsonElement>>>> GetTurningPoints(
        string matchID,
        MatchGetTurningPointsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /matches/live</c>, but is otherwise the
/// same as <see cref="IMatchService.StreamLive(MatchStreamLiveParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> StreamLive(
        MatchStreamLiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}