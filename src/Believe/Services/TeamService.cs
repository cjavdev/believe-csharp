using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Teams;
using Believe.Models.Teams.Logo;
using Believe.Services.Teams;

namespace Believe.Services;

/// <inheritdoc/>
public sealed class TeamService : ITeamService
{
    readonly Lazy<ITeamServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITeamServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public ITeamService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TeamService(this._client.WithOptions(modifier));
    }

    public TeamService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TeamServiceWithRawResponse(client.WithRawResponse));
        _logo = new(() => new LogoService(client));
    }

    readonly Lazy<ILogoService> _logo;
    public ILogoService Logo
    {
        get { return _logo.Value; }
    }

    /// <inheritdoc/>
    public async Task<Team> Create(
        TeamCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Team> Retrieve(
        TeamRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Team> Retrieve(
        string teamID,
        TeamRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TeamID = teamID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Team> Update(
        TeamUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Team> Update(
        string teamID,
        TeamUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { TeamID = teamID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TeamListPage> List(
        TeamListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(TeamDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string teamID,
        TeamDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { TeamID = teamID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> GetCulture(
        TeamGetCultureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetCulture(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Dictionary<string, JsonElement>> GetCulture(
        string teamID,
        TeamGetCultureParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetCulture(parameters with { TeamID = teamID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<Team>> GetRivals(
        TeamGetRivalsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetRivals(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<Team>> GetRivals(
        string teamID,
        TeamGetRivalsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetRivals(parameters with { TeamID = teamID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<FileUpload>> ListLogos(
        TeamListLogosParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListLogos(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<FileUpload>> ListLogos(
        string teamID,
        TeamListLogosParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListLogos(parameters with { TeamID = teamID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TeamServiceWithRawResponse : ITeamServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITeamServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TeamServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TeamServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;

        _logo = new(() => new LogoServiceWithRawResponse(client));
    }

    readonly Lazy<ILogoServiceWithRawResponse> _logo;
    public ILogoServiceWithRawResponse Logo
    {
        get { return _logo.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Team>> Create(
        TeamCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TeamCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var team = await response.Deserialize<Team>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    team.Validate();
                }
                return team;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Team>> Retrieve(
        TeamRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TeamID == null)
        {
            throw new BelieveInvalidDataException("'parameters.TeamID' cannot be null");
        }

        HttpRequest<TeamRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var team = await response.Deserialize<Team>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    team.Validate();
                }
                return team;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Team>> Retrieve(
        string teamID,
        TeamRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TeamID = teamID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Team>> Update(
        TeamUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TeamID == null)
        {
            throw new BelieveInvalidDataException("'parameters.TeamID' cannot be null");
        }

        HttpRequest<TeamUpdateParams> request = new()
        {
            Method = BelieveClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var team = await response.Deserialize<Team>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    team.Validate();
                }
                return team;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Team>> Update(
        string teamID,
        TeamUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { TeamID = teamID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TeamListPage>> List(
        TeamListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TeamListParams> request = new()
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
                    .Deserialize<TeamListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TeamListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TeamDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TeamID == null)
        {
            throw new BelieveInvalidDataException("'parameters.TeamID' cannot be null");
        }

        HttpRequest<TeamDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string teamID,
        TeamDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { TeamID = teamID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> GetCulture(
        TeamGetCultureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TeamID == null)
        {
            throw new BelieveInvalidDataException("'parameters.TeamID' cannot be null");
        }

        HttpRequest<TeamGetCultureParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response
                    .Deserialize<Dictionary<string, JsonElement>>(token)
                    .ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Dictionary<string, JsonElement>>> GetCulture(
        string teamID,
        TeamGetCultureParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetCulture(parameters with { TeamID = teamID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Team>>> GetRivals(
        TeamGetRivalsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TeamID == null)
        {
            throw new BelieveInvalidDataException("'parameters.TeamID' cannot be null");
        }

        HttpRequest<TeamGetRivalsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var teams = await response.Deserialize<List<Team>>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in teams)
                    {
                        item.Validate();
                    }
                }
                return teams;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<Team>>> GetRivals(
        string teamID,
        TeamGetRivalsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetRivals(parameters with { TeamID = teamID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<FileUpload>>> ListLogos(
        TeamListLogosParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TeamID == null)
        {
            throw new BelieveInvalidDataException("'parameters.TeamID' cannot be null");
        }

        HttpRequest<TeamListLogosParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fileUploads = await response
                    .Deserialize<List<FileUpload>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in fileUploads)
                    {
                        item.Validate();
                    }
                }
                return fileUploads;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<FileUpload>>> ListLogos(
        string teamID,
        TeamListLogosParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListLogos(parameters with { TeamID = teamID }, cancellationToken);
    }
}
