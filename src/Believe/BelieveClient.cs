using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models;
using Believe.Services;

namespace Believe;

/// <inheritdoc/>
public sealed class BelieveClient : IBelieveClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    readonly Lazy<IBelieveClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBelieveClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IBelieveClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BelieveClient(modifier(this._options));
    }

    readonly Lazy<ICharacterService> _characters;
    public ICharacterService Characters
    {
        get { return _characters.Value; }
    }

    readonly Lazy<ITeamService> _teams;
    public ITeamService Teams
    {
        get { return _teams.Value; }
    }

    readonly Lazy<IMatchService> _matches;
    public IMatchService Matches
    {
        get { return _matches.Value; }
    }

    readonly Lazy<IEpisodeService> _episodes;
    public IEpisodeService Episodes
    {
        get { return _episodes.Value; }
    }

    readonly Lazy<IQuoteService> _quotes;
    public IQuoteService Quotes
    {
        get { return _quotes.Value; }
    }

    readonly Lazy<IBelieveService> _believe;
    public IBelieveService Believe
    {
        get { return _believe.Value; }
    }

    readonly Lazy<IConflictService> _conflicts;
    public IConflictService Conflicts
    {
        get { return _conflicts.Value; }
    }

    readonly Lazy<IReframeService> _reframe;
    public IReframeService Reframe
    {
        get { return _reframe.Value; }
    }

    readonly Lazy<IPressService> _press;
    public IPressService Press
    {
        get { return _press.Value; }
    }

    readonly Lazy<ICoachingService> _coaching;
    public ICoachingService Coaching
    {
        get { return _coaching.Value; }
    }

    readonly Lazy<IBiscuitService> _biscuits;
    public IBiscuitService Biscuits
    {
        get { return _biscuits.Value; }
    }

    readonly Lazy<IPepTalkService> _pepTalk;
    public IPepTalkService PepTalk
    {
        get { return _pepTalk.Value; }
    }

    readonly Lazy<IStreamService> _stream;
    public IStreamService Stream
    {
        get { return _stream.Value; }
    }

    readonly Lazy<ITeamMemberService> _teamMembers;
    public ITeamMemberService TeamMembers
    {
        get { return _teamMembers.Value; }
    }

    readonly Lazy<IWebhookService> _webhooks;
    public IWebhookService Webhooks
    {
        get { return _webhooks.Value; }
    }

    readonly Lazy<ITicketSaleService> _ticketSales;
    public ITicketSaleService TicketSales
    {
        get { return _ticketSales.Value; }
    }

    /// <inheritdoc/>
    public async Task<JsonElement> GetWelcome(
        ClientGetWelcomeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetWelcome(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    public void Dispose() => this.HttpClient.Dispose();

    public BelieveClient()
    {
        _options = new();

        _withRawResponse = new(() => new BelieveClientWithRawResponse(this._options));
        _characters = new(() => new CharacterService(this));
        _teams = new(() => new TeamService(this));
        _matches = new(() => new MatchService(this));
        _episodes = new(() => new EpisodeService(this));
        _quotes = new(() => new QuoteService(this));
        _believe = new(() => new BelieveService(this));
        _conflicts = new(() => new ConflictService(this));
        _reframe = new(() => new ReframeService(this));
        _press = new(() => new PressService(this));
        _coaching = new(() => new CoachingService(this));
        _biscuits = new(() => new BiscuitService(this));
        _pepTalk = new(() => new PepTalkService(this));
        _stream = new(() => new StreamService(this));
        _teamMembers = new(() => new TeamMemberService(this));
        _webhooks = new(() => new WebhookService(this));
        _ticketSales = new(() => new TicketSaleService(this));
    }

    public BelieveClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class BelieveClientWithRawResponse : IBelieveClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    internal static HttpMethod PatchMethod = new("PATCH");

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public IBelieveClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BelieveClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<ICharacterServiceWithRawResponse> _characters;
    public ICharacterServiceWithRawResponse Characters
    {
        get { return _characters.Value; }
    }

    readonly Lazy<ITeamServiceWithRawResponse> _teams;
    public ITeamServiceWithRawResponse Teams
    {
        get { return _teams.Value; }
    }

    readonly Lazy<IMatchServiceWithRawResponse> _matches;
    public IMatchServiceWithRawResponse Matches
    {
        get { return _matches.Value; }
    }

    readonly Lazy<IEpisodeServiceWithRawResponse> _episodes;
    public IEpisodeServiceWithRawResponse Episodes
    {
        get { return _episodes.Value; }
    }

    readonly Lazy<IQuoteServiceWithRawResponse> _quotes;
    public IQuoteServiceWithRawResponse Quotes
    {
        get { return _quotes.Value; }
    }

    readonly Lazy<IBelieveServiceWithRawResponse> _believe;
    public IBelieveServiceWithRawResponse Believe
    {
        get { return _believe.Value; }
    }

    readonly Lazy<IConflictServiceWithRawResponse> _conflicts;
    public IConflictServiceWithRawResponse Conflicts
    {
        get { return _conflicts.Value; }
    }

    readonly Lazy<IReframeServiceWithRawResponse> _reframe;
    public IReframeServiceWithRawResponse Reframe
    {
        get { return _reframe.Value; }
    }

    readonly Lazy<IPressServiceWithRawResponse> _press;
    public IPressServiceWithRawResponse Press
    {
        get { return _press.Value; }
    }

    readonly Lazy<ICoachingServiceWithRawResponse> _coaching;
    public ICoachingServiceWithRawResponse Coaching
    {
        get { return _coaching.Value; }
    }

    readonly Lazy<IBiscuitServiceWithRawResponse> _biscuits;
    public IBiscuitServiceWithRawResponse Biscuits
    {
        get { return _biscuits.Value; }
    }

    readonly Lazy<IPepTalkServiceWithRawResponse> _pepTalk;
    public IPepTalkServiceWithRawResponse PepTalk
    {
        get { return _pepTalk.Value; }
    }

    readonly Lazy<IStreamServiceWithRawResponse> _stream;
    public IStreamServiceWithRawResponse Stream
    {
        get { return _stream.Value; }
    }

    readonly Lazy<ITeamMemberServiceWithRawResponse> _teamMembers;
    public ITeamMemberServiceWithRawResponse TeamMembers
    {
        get { return _teamMembers.Value; }
    }

    readonly Lazy<IWebhookServiceWithRawResponse> _webhooks;
    public IWebhookServiceWithRawResponse Webhooks
    {
        get { return _webhooks.Value; }
    }

    readonly Lazy<ITicketSaleServiceWithRawResponse> _ticketSales;
    public ITicketSaleServiceWithRawResponse TicketSales
    {
        get { return _ticketSales.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> GetWelcome(
        ClientGetWelcomeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ClientGetWelcomeParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw BelieveExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new BelieveIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new BelieveIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is BelieveIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public BelieveClientWithRawResponse()
    {
        _options = new();

        _characters = new(() => new CharacterServiceWithRawResponse(this));
        _teams = new(() => new TeamServiceWithRawResponse(this));
        _matches = new(() => new MatchServiceWithRawResponse(this));
        _episodes = new(() => new EpisodeServiceWithRawResponse(this));
        _quotes = new(() => new QuoteServiceWithRawResponse(this));
        _believe = new(() => new BelieveServiceWithRawResponse(this));
        _conflicts = new(() => new ConflictServiceWithRawResponse(this));
        _reframe = new(() => new ReframeServiceWithRawResponse(this));
        _press = new(() => new PressServiceWithRawResponse(this));
        _coaching = new(() => new CoachingServiceWithRawResponse(this));
        _biscuits = new(() => new BiscuitServiceWithRawResponse(this));
        _pepTalk = new(() => new PepTalkServiceWithRawResponse(this));
        _stream = new(() => new StreamServiceWithRawResponse(this));
        _teamMembers = new(() => new TeamMemberServiceWithRawResponse(this));
        _webhooks = new(() => new WebhookServiceWithRawResponse(this));
        _ticketSales = new(() => new TicketSaleServiceWithRawResponse(this));
    }

    public BelieveClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
