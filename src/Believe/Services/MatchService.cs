using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Matches;
using Believe.Services.Matches;

namespace Believe.Services;

/// <inheritdoc/>
public sealed class MatchService : IMatchService
{
    readonly Lazy<IMatchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMatchServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IMatchService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new MatchService(this._client.WithOptions(modifier)); }

    public MatchService (IBelieveClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new MatchServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _commentary =new(() => new CommentaryService(client)) ;
    }

    readonly Lazy<ICommentaryService> _commentary;
    public ICommentaryService Commentary { get { return _commentary.Value; } }

    /// <inheritdoc/>
    public async Task<Match> Create(
        MatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Match> Retrieve(
        MatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Match> Retrieve(
        string matchID,
        MatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            MatchID = matchID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Match> Update(
        MatchUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Match> Update(
        string matchID,
        MatchUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            MatchID = matchID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MatchListPage> List(
        MatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        MatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string matchID,
        MatchDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            MatchID = matchID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> GetLesson(
        MatchGetLessonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetLesson(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Dictionary<string, JsonElement>> GetLesson(
        string matchID,
        MatchGetLessonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetLesson(parameters with{
            MatchID = matchID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<Dictionary<string, JsonElement>>> GetTurningPoints(
        MatchGetTurningPointsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetTurningPoints(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<List<Dictionary<string, JsonElement>>> GetTurningPoints(
        string matchID,
        MatchGetTurningPointsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetTurningPoints(parameters with{
            MatchID = matchID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task StreamLive(
        MatchStreamLiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    { return this.WithRawResponse.StreamLive(parameters, cancellationToken); }
}

/// <inheritdoc/>
public sealed class MatchServiceWithRawResponse : IMatchServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMatchServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MatchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MatchServiceWithRawResponse (IBelieveClientWithRawResponse client)
    {
        _client =client ;

        _commentary =new(() => new CommentaryServiceWithRawResponse(client)) ;
    }

    readonly Lazy<ICommentaryServiceWithRawResponse> _commentary;
    public ICommentaryServiceWithRawResponse Commentary {
        get { return _commentary.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Match>> Create(
        MatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MatchCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var match = await response.Deserialize<Match>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                match.Validate();
            }
            return match;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Match>> Retrieve(
        MatchRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MatchID == null)
        {
            throw new BelieveInvalidDataException(
                "'parameters.MatchID' cannot be null"
            );
        }

        HttpRequest<MatchRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var match = await response.Deserialize<Match>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                match.Validate();
            }
            return match;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Match>> Retrieve(
        string matchID,
        MatchRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            MatchID = matchID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Match>> Update(
        MatchUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MatchID == null)
        {
            throw new BelieveInvalidDataException(
                "'parameters.MatchID' cannot be null"
            );
        }

        HttpRequest<MatchUpdateParams> request = new()
        {
            Method = BelieveClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var match = await response.Deserialize<Match>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                match.Validate();
            }
            return match;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Match>> Update(
        string matchID,
        MatchUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            MatchID = matchID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MatchListPage>> List(
        MatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MatchListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<MatchListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new MatchListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        MatchDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MatchID == null)
        {
            throw new BelieveInvalidDataException(
                "'parameters.MatchID' cannot be null"
            );
        }

        HttpRequest<MatchDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string matchID,
        MatchDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            MatchID = matchID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> GetLesson(
        MatchGetLessonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MatchID == null)
        {
            throw new BelieveInvalidDataException(
                "'parameters.MatchID' cannot be null"
            );
        }

        HttpRequest<MatchGetLessonParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<Dictionary<string, JsonElement>>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Dictionary<string, JsonElement>>> GetLesson(
        string matchID,
        MatchGetLessonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetLesson(parameters with{
            MatchID = matchID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Dictionary<string, JsonElement>>>> GetTurningPoints(
        MatchGetTurningPointsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MatchID == null)
        {
            throw new BelieveInvalidDataException(
                "'parameters.MatchID' cannot be null"
            );
        }

        HttpRequest<MatchGetTurningPointsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<List<Dictionary<string, JsonElement>>>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<List<Dictionary<string, JsonElement>>>> GetTurningPoints(
        string matchID,
        MatchGetTurningPointsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetTurningPoints(parameters with{
            MatchID = matchID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> StreamLive(
        MatchStreamLiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MatchStreamLiveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}