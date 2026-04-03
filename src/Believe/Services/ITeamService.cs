using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Teams;
using Believe.Models.Teams.Logo;
using Believe.Services.Teams;

namespace Believe.Services;

/// <summary>
/// Operations related to football teams
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITeamService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITeamServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITeamService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    ILogoService Logo { get; }

    /// <summary>
/// Add a new team to the league.
/// </summary>
    Task<Team> Create(
        TeamCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve detailed information about a specific team.
/// </summary>
    Task<Team> Retrieve(
        TeamRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(TeamRetrieveParams, CancellationToken)"/>
    Task<Team> Retrieve(
        string teamID,
        TeamRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Update specific fields of an existing team.
/// </summary>
    Task<Team> Update(
        TeamUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(TeamUpdateParams, CancellationToken)"/>
    Task<Team> Update(
        string teamID,
        TeamUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get a paginated list of all teams with optional filtering by league or culture
/// score.
/// </summary>
    Task<TeamListPage> List(
        TeamListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Remove a team from the database (relegation to oblivion).
/// </summary>
    Task Delete(
        TeamDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TeamDeleteParams, CancellationToken)"/>
    Task Delete(
        string teamID,
        TeamDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get detailed culture and values information for a team.
/// </summary>
    Task<Dictionary<string, JsonElement>> GetCulture(
        TeamGetCultureParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetCulture(TeamGetCultureParams, CancellationToken)"/>
    Task<Dictionary<string, JsonElement>> GetCulture(
        string teamID,
        TeamGetCultureParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Get all rival teams for a specific team.
/// </summary>
    Task<List<Team>> GetRivals(
        TeamGetRivalsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetRivals(TeamGetRivalsParams, CancellationToken)"/>
    Task<List<Team>> GetRivals(
        string teamID,
        TeamGetRivalsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// List all uploaded logos for a team.
/// </summary>
    Task<List<FileUpload>> ListLogos(
        TeamListLogosParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListLogos(TeamListLogosParams, CancellationToken)"/>
    Task<List<FileUpload>> ListLogos(
        string teamID,
        TeamListLogosParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="ITeamService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITeamServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITeamServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    ILogoServiceWithRawResponse Logo { get; }

    /// <summary>
/// Returns a raw HTTP response for <c>post /teams</c>, but is otherwise the
/// same as <see cref="ITeamService.Create(TeamCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Team>> Create(
        TeamCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /teams/{team_id}</c>, but is otherwise the
/// same as <see cref="ITeamService.Retrieve(TeamRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Team>> Retrieve(
        TeamRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(TeamRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Team>> Retrieve(
        string teamID,
        TeamRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>patch /teams/{team_id}</c>, but is otherwise the
/// same as <see cref="ITeamService.Update(TeamUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Team>> Update(
        TeamUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(TeamUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Team>> Update(
        string teamID,
        TeamUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /teams</c>, but is otherwise the
/// same as <see cref="ITeamService.List(TeamListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<TeamListPage>> List(
        TeamListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /teams/{team_id}</c>, but is otherwise the
/// same as <see cref="ITeamService.Delete(TeamDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        TeamDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(TeamDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string teamID,
        TeamDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /teams/{team_id}/culture</c>, but is otherwise the
/// same as <see cref="ITeamService.GetCulture(TeamGetCultureParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> GetCulture(
        TeamGetCultureParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetCulture(TeamGetCultureParams, CancellationToken)"/>
    Task<HttpResponse<Dictionary<string, JsonElement>>> GetCulture(
        string teamID,
        TeamGetCultureParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /teams/{team_id}/rivals</c>, but is otherwise the
/// same as <see cref="ITeamService.GetRivals(TeamGetRivalsParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<List<Team>>> GetRivals(
        TeamGetRivalsParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="GetRivals(TeamGetRivalsParams, CancellationToken)"/>
    Task<HttpResponse<List<Team>>> GetRivals(
        string teamID,
        TeamGetRivalsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /teams/{team_id}/logos</c>, but is otherwise the
/// same as <see cref="ITeamService.ListLogos(TeamListLogosParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<List<FileUpload>>> ListLogos(
        TeamListLogosParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="ListLogos(TeamListLogosParams, CancellationToken)"/>
    Task<HttpResponse<List<FileUpload>>> ListLogos(
        string teamID,
        TeamListLogosParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}