using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;
using Believe.Exceptions;

namespace Believe.Models.Webhooks;

/// <summary>
/// Response after triggering webhook events.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<WebhookTriggerEventResponse, WebhookTriggerEventResponseFromRaw>)
)]
public sealed record class WebhookTriggerEventResponse : JsonModel
{
    /// <summary>
    /// Results of webhook deliveries
    /// </summary>
    public required IReadOnlyList<Delivery> Deliveries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Delivery>>("deliveries");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Delivery>>(
                "deliveries",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Unique event identifier
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_id");
        }
        init { this._rawData.Set("event_id", value); }
    }

    /// <summary>
    /// The type of event triggered
    /// </summary>
    public required ApiEnum<string, WebhookTriggerEventResponseEventType> EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, WebhookTriggerEventResponseEventType>
            >("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    /// <summary>
    /// Number of successful deliveries
    /// </summary>
    public required long SuccessfulDeliveries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("successful_deliveries");
        }
        init { this._rawData.Set("successful_deliveries", value); }
    }

    /// <summary>
    /// Ted's reaction
    /// </summary>
    public required string TedSays
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ted_says");
        }
        init { this._rawData.Set("ted_says", value); }
    }

    /// <summary>
    /// Total number of webhooks that received this event
    /// </summary>
    public required long TotalWebhooks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_webhooks");
        }
        init { this._rawData.Set("total_webhooks", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Deliveries)
        {
            item.Validate();
        }
        _ = this.EventID;
        this.EventType.Validate();
        _ = this.SuccessfulDeliveries;
        _ = this.TedSays;
        _ = this.TotalWebhooks;
    }

    public WebhookTriggerEventResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookTriggerEventResponse(WebhookTriggerEventResponse webhookTriggerEventResponse)
        : base(webhookTriggerEventResponse) { }
#pragma warning restore CS8618

    public WebhookTriggerEventResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookTriggerEventResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookTriggerEventResponseFromRaw.FromRawUnchecked"/>
    public static WebhookTriggerEventResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookTriggerEventResponseFromRaw : IFromRawJson<WebhookTriggerEventResponse>
{
    /// <inheritdoc/>
    public WebhookTriggerEventResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookTriggerEventResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Result of delivering a webhook to a single endpoint.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Delivery, DeliveryFromRaw>))]
public sealed record class Delivery : JsonModel
{
    /// <summary>
    /// Whether delivery was successful
    /// </summary>
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// URL the webhook was sent to
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// ID of the webhook
    /// </summary>
    public required string WebhookID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("webhook_id");
        }
        init { this._rawData.Set("webhook_id", value); }
    }

    /// <summary>
    /// Error message if delivery failed
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// HTTP status code from the endpoint
    /// </summary>
    public long? StatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("status_code");
        }
        init { this._rawData.Set("status_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Success;
        _ = this.Url;
        _ = this.WebhookID;
        _ = this.Error;
        _ = this.StatusCode;
    }

    public Delivery() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Delivery(Delivery delivery)
        : base(delivery) { }
#pragma warning restore CS8618

    public Delivery(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Delivery(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeliveryFromRaw.FromRawUnchecked"/>
    public static Delivery FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeliveryFromRaw : IFromRawJson<Delivery>
{
    /// <inheritdoc/>
    public Delivery FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Delivery.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of event triggered
/// </summary>
[JsonConverter(typeof(WebhookTriggerEventResponseEventTypeConverter))]
public enum WebhookTriggerEventResponseEventType
{
    MatchCompleted,
    TeamMemberTransferred,
}

sealed class WebhookTriggerEventResponseEventTypeConverter
    : JsonConverter<WebhookTriggerEventResponseEventType>
{
    public override WebhookTriggerEventResponseEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match.completed" => WebhookTriggerEventResponseEventType.MatchCompleted,
            "team_member.transferred" => WebhookTriggerEventResponseEventType.TeamMemberTransferred,
            _ => (WebhookTriggerEventResponseEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookTriggerEventResponseEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookTriggerEventResponseEventType.MatchCompleted => "match.completed",
                WebhookTriggerEventResponseEventType.TeamMemberTransferred =>
                    "team_member.transferred",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
