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
/// A registered webhook endpoint.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RegisteredWebhook, RegisteredWebhookFromRaw>))]
public sealed record class RegisteredWebhook : JsonModel
{
    /// <summary>
    /// Unique webhook identifier
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// When the webhook was registered
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// List of event types this webhook is subscribed to
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, RegisteredWebhookEventType>> EventTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, RegisteredWebhookEventType>>
            >("event_types");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, RegisteredWebhookEventType>>>(
                "event_types",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The secret key for verifying webhook signatures (base64 encoded)
    /// </summary>
    public required string Secret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("secret");
        }
        init { this._rawData.Set("secret", value); }
    }

    /// <summary>
    /// The URL to send webhook events to
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
    /// Optional description for this webhook
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        foreach (var item in this.EventTypes)
        {
            item.Validate();
        }
        _ = this.Secret;
        _ = this.Url;
        _ = this.Description;
    }

    public RegisteredWebhook() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegisteredWebhook(RegisteredWebhook registeredWebhook)
        : base(registeredWebhook) { }
#pragma warning restore CS8618

    public RegisteredWebhook(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RegisteredWebhook(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RegisteredWebhookFromRaw.FromRawUnchecked"/>
    public static RegisteredWebhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RegisteredWebhookFromRaw : IFromRawJson<RegisteredWebhook>
{
    /// <inheritdoc/>
    public RegisteredWebhook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RegisteredWebhook.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RegisteredWebhookEventTypeConverter))]
public enum RegisteredWebhookEventType
{
    MatchCompleted,
    TeamMemberTransferred,
}

sealed class RegisteredWebhookEventTypeConverter : JsonConverter<RegisteredWebhookEventType>
{
    public override RegisteredWebhookEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match.completed" => RegisteredWebhookEventType.MatchCompleted,
            "team_member.transferred" => RegisteredWebhookEventType.TeamMemberTransferred,
            _ => (RegisteredWebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RegisteredWebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RegisteredWebhookEventType.MatchCompleted => "match.completed",
                RegisteredWebhookEventType.TeamMemberTransferred => "team_member.transferred",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
