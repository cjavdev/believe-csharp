using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Webhooks;

namespace Believe.Services;

/// <summary>
/// Register webhook endpoints and trigger events for testing
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IWebhookService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWebhookServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Register a new webhook endpoint to receive event notifications.
    ///
    /// <para>## Event Types</para>
    ///
    /// <para>Available event types to subscribe to: - `match.completed` - Fired when a
    /// football match ends - `team_member.transferred` - Fired when a player/coach
    /// joins or leaves a team</para>
    ///
    /// <para>If no event types are specified, the webhook will receive all event types.</para>
    ///
    /// <para>## Webhook Signatures</para>
    ///
    /// <para>All webhook deliveries include Standard Webhooks signature headers: -
    /// `webhook-id` - Unique message identifier - `webhook-timestamp` - Unix timestamp
    /// of when the webhook was sent - `webhook-signature` - HMAC-SHA256 signature in
    /// format `v1,{base64_signature}`</para>
    ///
    /// <para>Store the returned `secret` securely - you'll need it to verify webhook
    /// signatures.</para>
    /// </summary>
    Task<WebhookCreateResponse> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get details of a specific webhook endpoint.
    /// </summary>
    Task<RegisteredWebhook> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WebhookRetrieveParams, CancellationToken)"/>
    Task<RegisteredWebhook> Retrieve(
        string webhookID,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a list of all registered webhook endpoints.
    /// </summary>
    Task<List<RegisteredWebhook>> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Unregister a webhook endpoint. It will no longer receive events.
    /// </summary>
    Task<Dictionary<string, JsonElement>> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(WebhookDeleteParams, CancellationToken)"/>
    Task<Dictionary<string, JsonElement>> Delete(
        string webhookID,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Trigger a webhook event and deliver it to all subscribed endpoints.
    ///
    /// <para>This endpoint is useful for testing your webhook integration. It will: 1.
    /// Generate an event with the specified type and payload 2. Find all webhooks
    /// subscribed to that event type 3. Send a POST request to each webhook URL with
    /// signature headers 4. Return the delivery results</para>
    ///
    /// <para>## Event Payload</para>
    ///
    /// <para>You can provide a custom payload, or leave it empty to use a sample
    /// payload.</para>
    ///
    /// <para>## Webhook Signature Headers</para>
    ///
    /// <para>Each webhook delivery includes: - `webhook-id` - Unique event identifier
    /// (e.g., `evt_abc123...`) - `webhook-timestamp` - Unix timestamp -
    /// `webhook-signature` - HMAC-SHA256 signature (`v1,{base64}`)</para>
    ///
    /// <para>To verify signatures, compute: ``` signature = HMAC-SHA256(     key =
    /// base64_decode(secret_without_prefix),     message =
    /// "{timestamp}.{raw_json_payload}" ) ```</para>
    /// </summary>
    Task<WebhookTriggerEventResponse> TriggerEvent(
        WebhookTriggerEventParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWebhookService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWebhookServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /webhooks</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Create(WebhookCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookCreateResponse>> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /webhooks/{webhook_id}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Retrieve(WebhookRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RegisteredWebhook>> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WebhookRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RegisteredWebhook>> Retrieve(
        string webhookID,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /webhooks</c>, but is otherwise the
    /// same as <see cref="IWebhookService.List(WebhookListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<RegisteredWebhook>>> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /webhooks/{webhook_id}</c>, but is otherwise the
    /// same as <see cref="IWebhookService.Delete(WebhookDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Dictionary<string, JsonElement>>> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(WebhookDeleteParams, CancellationToken)"/>
    Task<HttpResponse<Dictionary<string, JsonElement>>> Delete(
        string webhookID,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /webhooks/trigger</c>, but is otherwise the
    /// same as <see cref="IWebhookService.TriggerEvent(WebhookTriggerEventParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookTriggerEventResponse>> TriggerEvent(
        WebhookTriggerEventParams parameters,
        CancellationToken cancellationToken = default
    );
}
