using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Believe.Client.Core;
using Believe.Client.Exceptions;
using Believe.Client.Models.TeamMembers;

namespace Believe.Client.Services;

/// <inheritdoc/>
public sealed class TeamMemberService : ITeamMemberService
{
    readonly Lazy<ITeamMemberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITeamMemberServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public ITeamMemberService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TeamMemberService(this._client.WithOptions(modifier));
    }

    public TeamMemberService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TeamMemberServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TeamMemberCreateResponse> Create(
        TeamMemberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TeamMemberRetrieveResponse> Retrieve(
        TeamMemberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TeamMemberRetrieveResponse> Retrieve(
        string memberID,
        TeamMemberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { MemberID = memberID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TeamMemberUpdateResponse> Update(
        TeamMemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TeamMemberUpdateResponse> Update(
        string memberID,
        TeamMemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { MemberID = memberID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TeamMemberListPage> List(
        TeamMemberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        TeamMemberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string memberID,
        TeamMemberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { MemberID = memberID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TeamMemberListCoachesPage> ListCoaches(
        TeamMemberListCoachesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListCoaches(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TeamMemberListPlayersPage> ListPlayers(
        TeamMemberListPlayersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListPlayers(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TeamMemberListStaffPage> ListStaff(
        TeamMemberListStaffParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListStaff(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TeamMemberServiceWithRawResponse : ITeamMemberServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITeamMemberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TeamMemberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TeamMemberServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TeamMemberCreateResponse>> Create(
        TeamMemberCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TeamMemberCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var teamMember = await response
                    .Deserialize<TeamMemberCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    teamMember.Validate();
                }
                return teamMember;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TeamMemberRetrieveResponse>> Retrieve(
        TeamMemberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemberID == null)
        {
            throw new BelieveInvalidDataException("'parameters.MemberID' cannot be null");
        }

        HttpRequest<TeamMemberRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var teamMember = await response
                    .Deserialize<TeamMemberRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    teamMember.Validate();
                }
                return teamMember;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TeamMemberRetrieveResponse>> Retrieve(
        string memberID,
        TeamMemberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { MemberID = memberID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TeamMemberUpdateResponse>> Update(
        TeamMemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemberID == null)
        {
            throw new BelieveInvalidDataException("'parameters.MemberID' cannot be null");
        }

        HttpRequest<TeamMemberUpdateParams> request = new()
        {
            Method = BelieveClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var teamMember = await response
                    .Deserialize<TeamMemberUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    teamMember.Validate();
                }
                return teamMember;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TeamMemberUpdateResponse>> Update(
        string memberID,
        TeamMemberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { MemberID = memberID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TeamMemberListPage>> List(
        TeamMemberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TeamMemberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<TeamMemberListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TeamMemberListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TeamMemberDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MemberID == null)
        {
            throw new BelieveInvalidDataException("'parameters.MemberID' cannot be null");
        }

        HttpRequest<TeamMemberDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string memberID,
        TeamMemberDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { MemberID = memberID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TeamMemberListCoachesPage>> ListCoaches(
        TeamMemberListCoachesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TeamMemberListCoachesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<TeamMemberListCoachesPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TeamMemberListCoachesPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TeamMemberListPlayersPage>> ListPlayers(
        TeamMemberListPlayersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TeamMemberListPlayersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<TeamMemberListPlayersPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TeamMemberListPlayersPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TeamMemberListStaffPage>> ListStaff(
        TeamMemberListStaffParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TeamMemberListStaffParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<TeamMemberListStaffPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TeamMemberListStaffPage(this, parameters, page);
            }
        );
    }
}
