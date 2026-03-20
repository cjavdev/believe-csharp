using System;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.TeamMembers;

namespace Believe.Services;

/// <summary>
/// Team members with union types (oneOf) - Players, Coaches, Medical Staff, Equipment Managers
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ITeamMemberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITeamMemberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITeamMemberService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Add a new team member to a team.
    ///
    /// <para>The request body is a **union type (oneOf)** - you must include the
    /// `member_type` discriminator field: - `"member_type": "player"` - Creates a
    /// player (requires position, jersey_number, etc.) - `"member_type": "coach"` -
    /// Creates a coach (requires specialty, etc.) - `"member_type": "medical_staff"` -
    /// Creates medical staff (requires medical specialty, etc.) - `"member_type":
    /// "equipment_manager"` - Creates equipment manager (requires responsibilities,
    /// etc.)</para>
    ///
    /// <para>The `character_id` field references an existing character from
    /// `/characters/{id}`.</para>
    ///
    /// <para>**Example for creating a player:** ```json {   "member_type": "player",
    /// "character_id": "sam-obisanya",   "team_id": "afc-richmond",
    /// "years_with_team": 2,   "position": "midfielder",   "jersey_number": 24,
    /// "goals_scored": 12,   "assists": 15 } ```</para>
    /// </summary>
    Task<TeamMemberCreateResponse> Create(
        TeamMemberCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve detailed information about a specific team member.
    ///
    /// <para>The response is a **union type (oneOf)** - the actual shape depends on the
    /// member's type: - **player**: Includes position, jersey_number, goals_scored,
    /// assists, is_captain - **coach**: Includes specialty, certifications, win_rate -
    /// **medical_staff**: Includes specialty, qualifications, license_number -
    /// **equipment_manager**: Includes responsibilities, is_head_kitman</para>
    ///
    /// <para>Use `character_id` to fetch full character details from
    /// `/characters/{character_id}`.</para>
    /// </summary>
    Task<TeamMemberRetrieveResponse> Retrieve(
        TeamMemberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TeamMemberRetrieveParams, CancellationToken)"/>
    Task<TeamMemberRetrieveResponse> Retrieve(
        string memberID,
        TeamMemberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update specific fields of an existing team member. Fields vary by member type.
    /// </summary>
    Task<TeamMemberUpdateResponse> Update(
        TeamMemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TeamMemberUpdateParams, CancellationToken)"/>
    Task<TeamMemberUpdateResponse> Update(
        string memberID,
        TeamMemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a paginated list of all team members.
    ///
    /// <para>This endpoint demonstrates **union types (oneOf)** in the response. Each
    /// team member can be one of: Player, Coach, MedicalStaff, or EquipmentManager. The
    /// `member_type` field acts as a discriminator to determine the shape of each
    /// object.</para>
    /// </summary>
    Task<TeamMemberListPage> List(
        TeamMemberListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a team member from the roster.
    /// </summary>
    Task Delete(TeamMemberDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(TeamMemberDeleteParams, CancellationToken)"/>
    Task Delete(
        string memberID,
        TeamMemberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get only coaches (filtered subset of team members).
    /// </summary>
    Task<TeamMemberListCoachesPage> ListCoaches(
        TeamMemberListCoachesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get only players (filtered subset of team members).
    /// </summary>
    Task<TeamMemberListPlayersPage> ListPlayers(
        TeamMemberListPlayersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get all staff members (medical staff and equipment managers).
    ///
    /// <para>This demonstrates a **narrower union type** - the response is oneOf
    /// MedicalStaff or EquipmentManager.</para>
    /// </summary>
    Task<TeamMemberListStaffPage> ListStaff(
        TeamMemberListStaffParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITeamMemberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITeamMemberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITeamMemberServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /team-members</c>, but is otherwise the
    /// same as <see cref="ITeamMemberService.Create(TeamMemberCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TeamMemberCreateResponse>> Create(
        TeamMemberCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /team-members/{member_id}</c>, but is otherwise the
    /// same as <see cref="ITeamMemberService.Retrieve(TeamMemberRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TeamMemberRetrieveResponse>> Retrieve(
        TeamMemberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TeamMemberRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TeamMemberRetrieveResponse>> Retrieve(
        string memberID,
        TeamMemberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /team-members/{member_id}</c>, but is otherwise the
    /// same as <see cref="ITeamMemberService.Update(TeamMemberUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TeamMemberUpdateResponse>> Update(
        TeamMemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TeamMemberUpdateParams, CancellationToken)"/>
    Task<HttpResponse<TeamMemberUpdateResponse>> Update(
        string memberID,
        TeamMemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /team-members</c>, but is otherwise the
    /// same as <see cref="ITeamMemberService.List(TeamMemberListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TeamMemberListPage>> List(
        TeamMemberListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /team-members/{member_id}</c>, but is otherwise the
    /// same as <see cref="ITeamMemberService.Delete(TeamMemberDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        TeamMemberDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TeamMemberDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string memberID,
        TeamMemberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /team-members/coaches/</c>, but is otherwise the
    /// same as <see cref="ITeamMemberService.ListCoaches(TeamMemberListCoachesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TeamMemberListCoachesPage>> ListCoaches(
        TeamMemberListCoachesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /team-members/players/</c>, but is otherwise the
    /// same as <see cref="ITeamMemberService.ListPlayers(TeamMemberListPlayersParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TeamMemberListPlayersPage>> ListPlayers(
        TeamMemberListPlayersParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /team-members/staff/</c>, but is otherwise the
    /// same as <see cref="ITeamMemberService.ListStaff(TeamMemberListStaffParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TeamMemberListStaffPage>> ListStaff(
        TeamMemberListStaffParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
