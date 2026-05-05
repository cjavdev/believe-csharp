using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Client.Core;
using Believe.Client.Exceptions;
using Believe.Client.Models.Matches.Commentary;

namespace Believe.Client.Services.Matches;

/// <inheritdoc/>
public sealed class CommentaryService : ICommentaryService
{
    readonly Lazy<ICommentaryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICommentaryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public ICommentaryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CommentaryService(this._client.WithOptions(modifier));
    }

    public CommentaryService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CommentaryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Stream(
        CommentaryStreamParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Stream(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JsonElement> Stream(
        string matchID,
        CommentaryStreamParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Stream(parameters with { MatchID = matchID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CommentaryServiceWithRawResponse : ICommentaryServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICommentaryServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CommentaryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CommentaryServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> Stream(
        CommentaryStreamParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MatchID == null)
        {
            throw new BelieveInvalidDataException("'parameters.MatchID' cannot be null");
        }

        HttpRequest<CommentaryStreamParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> Stream(
        string matchID,
        CommentaryStreamParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Stream(parameters with { MatchID = matchID }, cancellationToken);
    }
}
