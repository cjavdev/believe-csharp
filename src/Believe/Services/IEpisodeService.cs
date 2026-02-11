using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Episodes;

namespace Believe.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEpisodeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEpisodeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEpisodeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Add a new episode to the series.
    /// </summary>
    Task<Episode> Create(
        EpisodeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve detailed information about a specific episode.
    /// </summary>
    Task<Episode> Retrieve(
        EpisodeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EpisodeRetrieveParams, CancellationToken)"/>
    Task<Episode> Retrieve(
        string episodeID,
        EpisodeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update specific fields of an existing episode.
    /// </summary>
    Task<Episode> Update(
        EpisodeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EpisodeUpdateParams, CancellationToken)"/>
    Task<Episode> Update(
        string episodeID,
        EpisodeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a paginated list of all Ted Lasso episodes with optional filtering by season.
    /// </summary>
    Task<EpisodeListPage> List(
        EpisodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove an episode from the database.
    /// </summary>
    Task Delete(EpisodeDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(EpisodeDeleteParams, CancellationToken)"/>
    Task Delete(
        string episodeID,
        EpisodeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Ted's wisdom and memorable moments from a specific episode.
    /// </summary>
    Task<Dictionary<string, JsonElement>> GetWisdom(
        EpisodeGetWisdomParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetWisdom(EpisodeGetWisdomParams, CancellationToken)"/>
    Task<Dictionary<string, JsonElement>> GetWisdom(
        string episodeID,
        EpisodeGetWisdomParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a paginated list of episodes from a specific season.
    /// </summary>
    Task<EpisodeListBySeasonPage> ListBySeason(
        EpisodeListBySeasonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListBySeason(EpisodeListBySeasonParams, CancellationToken)"/>
    Task<EpisodeListBySeasonPage> ListBySeason(
        long seasonNumber,
        EpisodeListBySeasonParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEpisodeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEpisodeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEpisodeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /episodes`, but is otherwise the
    /// same as <see cref="IEpisodeService.Create(EpisodeCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Episode>> Create(
        EpisodeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /episodes/{episode_id}`, but is otherwise the
    /// same as <see cref="IEpisodeService.Retrieve(EpisodeRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Episode>> Retrieve(
        EpisodeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EpisodeRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Episode>> Retrieve(
        string episodeID,
        EpisodeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /episodes/{episode_id}`, but is otherwise the
    /// same as <see cref="IEpisodeService.Update(EpisodeUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Episode>> Update(
        EpisodeUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EpisodeUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Episode>> Update(
        string episodeID,
        EpisodeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /episodes`, but is otherwise the
    /// same as <see cref="IEpisodeService.List(EpisodeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EpisodeListPage>> List(
        EpisodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /episodes/{episode_id}`, but is otherwise the
    /// same as <see cref="IEpisodeService.Delete(EpisodeDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        EpisodeDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EpisodeDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string episodeID,
        EpisodeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /episodes/{episode_id}/wisdom`, but is otherwise the
    /// same as <see cref="IEpisodeService.GetWisdom(EpisodeGetWisdomParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> GetWisdom(
        EpisodeGetWisdomParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetWisdom(EpisodeGetWisdomParams, CancellationToken)"/>
    Task<HttpResponse<Dictionary<string, JsonElement>>> GetWisdom(
        string episodeID,
        EpisodeGetWisdomParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /episodes/seasons/{season_number}`, but is otherwise the
    /// same as <see cref="IEpisodeService.ListBySeason(EpisodeListBySeasonParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EpisodeListBySeasonPage>> ListBySeason(
        EpisodeListBySeasonParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListBySeason(EpisodeListBySeasonParams, CancellationToken)"/>
    Task<HttpResponse<EpisodeListBySeasonPage>> ListBySeason(
        long seasonNumber,
        EpisodeListBySeasonParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
