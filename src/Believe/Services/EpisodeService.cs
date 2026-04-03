using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Episodes;

namespace Believe.Services;

/// <inheritdoc/>
public sealed class EpisodeService : IEpisodeService
{
    readonly Lazy<IEpisodeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEpisodeServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IEpisodeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new EpisodeService(this._client.WithOptions(modifier)); }

    public EpisodeService (IBelieveClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new EpisodeServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<Episode> Create(
        EpisodeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Episode> Retrieve(
        EpisodeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Episode> Retrieve(
        string episodeID,
        EpisodeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            EpisodeID = episodeID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Episode> Update(
        EpisodeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Episode> Update(
        string episodeID,
        EpisodeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            EpisodeID = episodeID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EpisodeListPage> List(
        EpisodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        EpisodeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string episodeID,
        EpisodeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            EpisodeID = episodeID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> GetWisdom(
        EpisodeGetWisdomParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetWisdom(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Dictionary<string, JsonElement>> GetWisdom(
        string episodeID,
        EpisodeGetWisdomParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetWisdom(parameters with{
            EpisodeID = episodeID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EpisodeServiceWithRawResponse : IEpisodeServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEpisodeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EpisodeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EpisodeServiceWithRawResponse (IBelieveClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<Episode>> Create(
        EpisodeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EpisodeCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var episode = await response.Deserialize<Episode>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                episode.Validate();
            }
            return episode;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Episode>> Retrieve(
        EpisodeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EpisodeID == null)
        {
            throw new BelieveInvalidDataException(
                "'parameters.EpisodeID' cannot be null"
            );
        }

        HttpRequest<EpisodeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var episode = await response.Deserialize<Episode>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                episode.Validate();
            }
            return episode;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Episode>> Retrieve(
        string episodeID,
        EpisodeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            EpisodeID = episodeID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Episode>> Update(
        EpisodeUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EpisodeID == null)
        {
            throw new BelieveInvalidDataException(
                "'parameters.EpisodeID' cannot be null"
            );
        }

        HttpRequest<EpisodeUpdateParams> request = new()
        {
            Method = BelieveClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var episode = await response.Deserialize<Episode>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                episode.Validate();
            }
            return episode;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Episode>> Update(
        string episodeID,
        EpisodeUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            EpisodeID = episodeID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EpisodeListPage>> List(
        EpisodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EpisodeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PaginatedResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new EpisodeListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        EpisodeDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EpisodeID == null)
        {
            throw new BelieveInvalidDataException(
                "'parameters.EpisodeID' cannot be null"
            );
        }

        HttpRequest<EpisodeDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string episodeID,
        EpisodeDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            EpisodeID = episodeID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> GetWisdom(
        EpisodeGetWisdomParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EpisodeID == null)
        {
            throw new BelieveInvalidDataException(
                "'parameters.EpisodeID' cannot be null"
            );
        }

        HttpRequest<EpisodeGetWisdomParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<Dictionary<string, JsonElement>>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Dictionary<string, JsonElement>>> GetWisdom(
        string episodeID,
        EpisodeGetWisdomParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetWisdom(parameters with{
            EpisodeID = episodeID
        }, cancellationToken);
    }
}