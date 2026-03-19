using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Webhooks;

/// <summary>
/// Response after registering a webhook.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookCreateResponse, WebhookCreateResponseFromRaw>))]
public sealed record class WebhookCreateResponse : JsonModel
{
    /// <summary>
    /// The registered webhook details
    /// </summary>
    public required RegisteredWebhook Webhook
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RegisteredWebhook>("webhook");
        }
        init { this._rawData.Set("webhook", value); }
    }

    /// <summary>
    /// Status message
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <summary>
    /// Ted's reaction
    /// </summary>
    public string? TedSays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ted_says");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ted_says", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Webhook.Validate();
        _ = this.Message;
        _ = this.TedSays;
    }

    public WebhookCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookCreateResponse(WebhookCreateResponse webhookCreateResponse)
        : base(webhookCreateResponse) { }
#pragma warning restore CS8618

    public WebhookCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookCreateResponseFromRaw.FromRawUnchecked"/>
    public static WebhookCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebhookCreateResponse(RegisteredWebhook webhook)
        : this()
    {
        this.Webhook = webhook;
    }
}

class WebhookCreateResponseFromRaw : IFromRawJson<WebhookCreateResponse>
{
    /// <inheritdoc/>
    public WebhookCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookCreateResponse.FromRawUnchecked(rawData);
}
