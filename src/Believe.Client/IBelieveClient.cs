using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Client.Core;
using Believe.Client.Models;
using Believe.Client.Services;

namespace Believe.Client;

/// <summary>
/// A client for interacting with the Believe REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IBelieveClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBelieveClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBelieveClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICharacterService Characters { get; }

    ITeamService Teams { get; }

    IMatchService Matches { get; }

    IEpisodeService Episodes { get; }

    IQuoteService Quotes { get; }

    IBelieveService Believe { get; }

    IConflictService Conflicts { get; }

    IReframeService Reframe { get; }

    IPressService Press { get; }

    ICoachingService Coaching { get; }

    IBiscuitService Biscuits { get; }

    IPepTalkService PepTalk { get; }

    IStreamService Stream { get; }

    ITeamMemberService TeamMembers { get; }

    IWebhookService Webhooks { get; }

    ITicketSaleService TicketSales { get; }

    IHealthService Health { get; }

    IVersionService Version { get; }

    IClientService Client { get; }

    /// <summary>
    /// Get a warm welcome and overview of available endpoints.
    /// </summary>
    Task<JsonElement> GetWelcome(
        ClientGetWelcomeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBelieveClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IBelieveClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBelieveClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICharacterServiceWithRawResponse Characters { get; }

    ITeamServiceWithRawResponse Teams { get; }

    IMatchServiceWithRawResponse Matches { get; }

    IEpisodeServiceWithRawResponse Episodes { get; }

    IQuoteServiceWithRawResponse Quotes { get; }

    IBelieveServiceWithRawResponse Believe { get; }

    IConflictServiceWithRawResponse Conflicts { get; }

    IReframeServiceWithRawResponse Reframe { get; }

    IPressServiceWithRawResponse Press { get; }

    ICoachingServiceWithRawResponse Coaching { get; }

    IBiscuitServiceWithRawResponse Biscuits { get; }

    IPepTalkServiceWithRawResponse PepTalk { get; }

    IStreamServiceWithRawResponse Stream { get; }

    ITeamMemberServiceWithRawResponse TeamMembers { get; }

    IWebhookServiceWithRawResponse Webhooks { get; }

    ITicketSaleServiceWithRawResponse TicketSales { get; }

    IHealthServiceWithRawResponse Health { get; }

    IVersionServiceWithRawResponse Version { get; }

    IClientServiceWithRawResponse Client { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /</c>, but is otherwise the
    /// same as <see cref="IBelieveClient.GetWelcome(ClientGetWelcomeParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> GetWelcome(
        ClientGetWelcomeParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends a request to the Believe REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
