using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Client.Core;
using Believe.Client.Exceptions;

namespace Believe.Client.Models.Webhooks;

/// <summary>
/// Trigger a webhook event and deliver it to all subscribed endpoints.
///
/// <para>This endpoint is useful for testing your webhook integration. It will: 1.
/// Generate an event with the specified type and payload 2. Find all webhooks subscribed
/// to that event type 3. Send a POST request to each webhook URL with signature headers
/// 4. Return the delivery results</para>
///
/// <para>## Event Payload</para>
///
/// <para>You can provide a custom payload, or leave it empty to use a sample payload.</para>
///
/// <para>## Webhook Signature Headers</para>
///
/// <para>Each webhook delivery includes: - `webhook-id` - Unique event identifier
/// (e.g., `evt_abc123...`) - `webhook-timestamp` - Unix timestamp - `webhook-signature`
/// - HMAC-SHA256 signature (`v1,{base64}`)</para>
///
/// <para>To verify signatures, compute: ``` signature = HMAC-SHA256(     key = base64_decode(secret_without_prefix),
///     message = "{timestamp}.{raw_json_payload}" ) ```</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WebhookTriggerEventParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The type of event to trigger
    /// </summary>
    public required ApiEnum<string, WebhookTriggerEventParamsEventType> EventType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, WebhookTriggerEventParamsEventType>
            >("event_type");
        }
        init { this._rawBodyData.Set("event_type", value); }
    }

    /// <summary>
    /// Optional event payload. If not provided, a sample payload will be generated.
    /// </summary>
    public Payload? Payload
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Payload>("payload");
        }
        init { this._rawBodyData.Set("payload", value); }
    }

    public WebhookTriggerEventParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookTriggerEventParams(WebhookTriggerEventParams webhookTriggerEventParams)
        : base(webhookTriggerEventParams)
    {
        this._rawBodyData = new(webhookTriggerEventParams._rawBodyData);
    }
#pragma warning restore CS8618

    public WebhookTriggerEventParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookTriggerEventParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WebhookTriggerEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(WebhookTriggerEventParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/webhooks/trigger")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// The type of event to trigger
/// </summary>
[JsonConverter(typeof(WebhookTriggerEventParamsEventTypeConverter))]
public enum WebhookTriggerEventParamsEventType
{
    MatchCompleted,
    TeamMemberTransferred,
}

sealed class WebhookTriggerEventParamsEventTypeConverter
    : JsonConverter<WebhookTriggerEventParamsEventType>
{
    public override WebhookTriggerEventParamsEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match.completed" => WebhookTriggerEventParamsEventType.MatchCompleted,
            "team_member.transferred" => WebhookTriggerEventParamsEventType.TeamMemberTransferred,
            _ => (WebhookTriggerEventParamsEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookTriggerEventParamsEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookTriggerEventParamsEventType.MatchCompleted => "match.completed",
                WebhookTriggerEventParamsEventType.TeamMemberTransferred =>
                    "team_member.transferred",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Optional event payload. If not provided, a sample payload will be generated.
/// </summary>
[JsonConverter(typeof(PayloadConverter))]
public record class Payload : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Payload(MatchCompleted value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Payload(TeamMemberTransferred value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Payload(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MatchCompleted"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMatchCompleted(out var value)) {
    ///     // `value` is of type `MatchCompleted`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMatchCompleted([NotNullWhen(true)] out MatchCompleted? value)
    {
        value = this.Value as MatchCompleted;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TeamMemberTransferred"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTeamMemberTransferred(out var value)) {
    ///     // `value` is of type `TeamMemberTransferred`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTeamMemberTransferred([NotNullWhen(true)] out TeamMemberTransferred? value)
    {
        value = this.Value as TeamMemberTransferred;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="BelieveInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (MatchCompleted value) =&gt; {...},
    ///     (TeamMemberTransferred value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<MatchCompleted> matchCompleted,
        Action<TeamMemberTransferred> teamMemberTransferred
    )
    {
        switch (this.Value)
        {
            case MatchCompleted value:
                matchCompleted(value);
                break;
            case TeamMemberTransferred value:
                teamMemberTransferred(value);
                break;
            default:
                throw new BelieveInvalidDataException("Data did not match any variant of Payload");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="BelieveInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (MatchCompleted value) =&gt; {...},
    ///     (TeamMemberTransferred value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<MatchCompleted, T> matchCompleted,
        Func<TeamMemberTransferred, T> teamMemberTransferred
    )
    {
        return this.Value switch
        {
            MatchCompleted value => matchCompleted(value),
            TeamMemberTransferred value => teamMemberTransferred(value),
            _ => throw new BelieveInvalidDataException("Data did not match any variant of Payload"),
        };
    }

    public static implicit operator Payload(MatchCompleted value) => new(value);

    public static implicit operator Payload(TeamMemberTransferred value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="BelieveInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new BelieveInvalidDataException("Data did not match any variant of Payload");
        }
        this.Switch(
            (matchCompleted) => matchCompleted.Validate(),
            (teamMemberTransferred) => teamMemberTransferred.Validate()
        );
    }

    public virtual bool Equals(Payload? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            MatchCompleted _ => 0,
            TeamMemberTransferred _ => 1,
            _ => -1,
        };
    }
}

sealed class PayloadConverter : JsonConverter<Payload?>
{
    public override Payload? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? eventType;
        try
        {
            eventType = element.GetProperty("event_type").GetString();
        }
        catch
        {
            eventType = null;
        }

        switch (eventType)
        {
            case "match.completed":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MatchCompleted>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "team_member.transferred":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TeamMemberTransferred>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Payload(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Payload? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Payload for match.completed event.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MatchCompleted, MatchCompletedFromRaw>))]
public sealed record class MatchCompleted : JsonModel
{
    /// <summary>
    /// Event data
    /// </summary>
    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// The type of webhook event
    /// </summary>
    public ApiEnum<string, MatchCompletedEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MatchCompletedEventType>>(
                "event_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        this.EventType?.Validate();
    }

    public MatchCompleted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MatchCompleted(MatchCompleted matchCompleted)
        : base(matchCompleted) { }
#pragma warning restore CS8618

    public MatchCompleted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatchCompleted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MatchCompletedFromRaw.FromRawUnchecked"/>
    public static MatchCompleted FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MatchCompleted(Data data)
        : this()
    {
        this.Data = data;
    }
}

class MatchCompletedFromRaw : IFromRawJson<MatchCompleted>
{
    /// <inheritdoc/>
    public MatchCompleted FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MatchCompleted.FromRawUnchecked(rawData);
}

/// <summary>
/// Event data
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Final away team score
    /// </summary>
    public required long AwayScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("away_score");
        }
        init { this._rawData.Set("away_score", value); }
    }

    /// <summary>
    /// Away team ID
    /// </summary>
    public required string AwayTeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("away_team_id");
        }
        init { this._rawData.Set("away_team_id", value); }
    }

    /// <summary>
    /// When the match completed
    /// </summary>
    public required DateTimeOffset CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("completed_at");
        }
        init { this._rawData.Set("completed_at", value); }
    }

    /// <summary>
    /// Final home team score
    /// </summary>
    public required long HomeScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("home_score");
        }
        init { this._rawData.Set("home_score", value); }
    }

    /// <summary>
    /// Home team ID
    /// </summary>
    public required string HomeTeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("home_team_id");
        }
        init { this._rawData.Set("home_team_id", value); }
    }

    /// <summary>
    /// Unique match identifier
    /// </summary>
    public required string MatchID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("match_id");
        }
        init { this._rawData.Set("match_id", value); }
    }

    /// <summary>
    /// Type of match
    /// </summary>
    public required ApiEnum<string, MatchType> MatchType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MatchType>>("match_type");
        }
        init { this._rawData.Set("match_type", value); }
    }

    /// <summary>
    /// Match result from home team perspective
    /// </summary>
    public required ApiEnum<string, Result> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Result>>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// Ted's post-match wisdom
    /// </summary>
    public required string TedPostMatchQuote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ted_post_match_quote");
        }
        init { this._rawData.Set("ted_post_match_quote", value); }
    }

    /// <summary>
    /// Ted's lesson from the match
    /// </summary>
    public string? LessonLearned
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lesson_learned");
        }
        init { this._rawData.Set("lesson_learned", value); }
    }

    /// <summary>
    /// Player of the match (if awarded)
    /// </summary>
    public string? ManOfTheMatch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("man_of_the_match");
        }
        init { this._rawData.Set("man_of_the_match", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AwayScore;
        _ = this.AwayTeamID;
        _ = this.CompletedAt;
        _ = this.HomeScore;
        _ = this.HomeTeamID;
        _ = this.MatchID;
        this.MatchType.Validate();
        this.Result.Validate();
        _ = this.TedPostMatchQuote;
        _ = this.LessonLearned;
        _ = this.ManOfTheMatch;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of match
/// </summary>
[JsonConverter(typeof(MatchTypeConverter))]
public enum MatchType
{
    League,
    Cup,
    Friendly,
    Playoff,
    Final,
}

sealed class MatchTypeConverter : JsonConverter<MatchType>
{
    public override MatchType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "league" => MatchType.League,
            "cup" => MatchType.Cup,
            "friendly" => MatchType.Friendly,
            "playoff" => MatchType.Playoff,
            "final" => MatchType.Final,
            _ => (MatchType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MatchType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MatchType.League => "league",
                MatchType.Cup => "cup",
                MatchType.Friendly => "friendly",
                MatchType.Playoff => "playoff",
                MatchType.Final => "final",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Match result from home team perspective
/// </summary>
[JsonConverter(typeof(ResultConverter))]
public enum Result
{
    HomeWin,
    AwayWin,
    Draw,
}

sealed class ResultConverter : JsonConverter<Result>
{
    public override Result Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "home_win" => Result.HomeWin,
            "away_win" => Result.AwayWin,
            "draw" => Result.Draw,
            _ => (Result)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Result value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Result.HomeWin => "home_win",
                Result.AwayWin => "away_win",
                Result.Draw => "draw",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of webhook event
/// </summary>
[JsonConverter(typeof(MatchCompletedEventTypeConverter))]
public enum MatchCompletedEventType
{
    MatchCompleted,
}

sealed class MatchCompletedEventTypeConverter : JsonConverter<MatchCompletedEventType>
{
    public override MatchCompletedEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match.completed" => MatchCompletedEventType.MatchCompleted,
            _ => (MatchCompletedEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MatchCompletedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MatchCompletedEventType.MatchCompleted => "match.completed",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Payload for team_member.transferred event.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TeamMemberTransferred, TeamMemberTransferredFromRaw>))]
public sealed record class TeamMemberTransferred : JsonModel
{
    /// <summary>
    /// Event data
    /// </summary>
    public required TeamMemberTransferredData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TeamMemberTransferredData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// The type of webhook event
    /// </summary>
    public ApiEnum<string, TeamMemberTransferredEventType>? EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TeamMemberTransferredEventType>>(
                "event_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("event_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        this.EventType?.Validate();
    }

    public TeamMemberTransferred() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamMemberTransferred(TeamMemberTransferred teamMemberTransferred)
        : base(teamMemberTransferred) { }
#pragma warning restore CS8618

    public TeamMemberTransferred(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TeamMemberTransferred(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TeamMemberTransferredFromRaw.FromRawUnchecked"/>
    public static TeamMemberTransferred FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TeamMemberTransferred(TeamMemberTransferredData data)
        : this()
    {
        this.Data = data;
    }
}

class TeamMemberTransferredFromRaw : IFromRawJson<TeamMemberTransferred>
{
    /// <inheritdoc/>
    public TeamMemberTransferred FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TeamMemberTransferred.FromRawUnchecked(rawData);
}

/// <summary>
/// Event data
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TeamMemberTransferredData, TeamMemberTransferredDataFromRaw>)
)]
public sealed record class TeamMemberTransferredData : JsonModel
{
    /// <summary>
    /// ID of the character (links to /characters)
    /// </summary>
    public required string CharacterID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("character_id");
        }
        init { this._rawData.Set("character_id", value); }
    }

    /// <summary>
    /// Name of the character
    /// </summary>
    public required string CharacterName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("character_name");
        }
        init { this._rawData.Set("character_name", value); }
    }

    /// <summary>
    /// Type of team member
    /// </summary>
    public required ApiEnum<string, MemberType> MemberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MemberType>>("member_type");
        }
        init { this._rawData.Set("member_type", value); }
    }

    /// <summary>
    /// ID of the team involved
    /// </summary>
    public required string TeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("team_id");
        }
        init { this._rawData.Set("team_id", value); }
    }

    /// <summary>
    /// ID of the team member
    /// </summary>
    public required string TeamMemberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("team_member_id");
        }
        init { this._rawData.Set("team_member_id", value); }
    }

    /// <summary>
    /// Name of the team involved
    /// </summary>
    public required string TeamName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("team_name");
        }
        init { this._rawData.Set("team_name", value); }
    }

    /// <summary>
    /// Ted's reaction to the transfer
    /// </summary>
    public required string TedReaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ted_reaction");
        }
        init { this._rawData.Set("ted_reaction", value); }
    }

    /// <summary>
    /// Whether the member joined or departed
    /// </summary>
    public required ApiEnum<string, TransferType> TransferType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TransferType>>("transfer_type");
        }
        init { this._rawData.Set("transfer_type", value); }
    }

    /// <summary>
    /// Previous team ID (for joins from another team)
    /// </summary>
    public string? PreviousTeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("previous_team_id");
        }
        init { this._rawData.Set("previous_team_id", value); }
    }

    /// <summary>
    /// Previous team name (for joins from another team)
    /// </summary>
    public string? PreviousTeamName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("previous_team_name");
        }
        init { this._rawData.Set("previous_team_name", value); }
    }

    /// <summary>
    /// Transfer fee in GBP (for players)
    /// </summary>
    public string? TransferFeeGbp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transfer_fee_gbp");
        }
        init { this._rawData.Set("transfer_fee_gbp", value); }
    }

    /// <summary>
    /// Years spent with previous team
    /// </summary>
    public long? YearsWithPreviousTeam
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("years_with_previous_team");
        }
        init { this._rawData.Set("years_with_previous_team", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CharacterID;
        _ = this.CharacterName;
        this.MemberType.Validate();
        _ = this.TeamID;
        _ = this.TeamMemberID;
        _ = this.TeamName;
        _ = this.TedReaction;
        this.TransferType.Validate();
        _ = this.PreviousTeamID;
        _ = this.PreviousTeamName;
        _ = this.TransferFeeGbp;
        _ = this.YearsWithPreviousTeam;
    }

    public TeamMemberTransferredData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamMemberTransferredData(TeamMemberTransferredData teamMemberTransferredData)
        : base(teamMemberTransferredData) { }
#pragma warning restore CS8618

    public TeamMemberTransferredData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TeamMemberTransferredData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TeamMemberTransferredDataFromRaw.FromRawUnchecked"/>
    public static TeamMemberTransferredData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TeamMemberTransferredDataFromRaw : IFromRawJson<TeamMemberTransferredData>
{
    /// <inheritdoc/>
    public TeamMemberTransferredData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TeamMemberTransferredData.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of team member
/// </summary>
[JsonConverter(typeof(MemberTypeConverter))]
public enum MemberType
{
    Player,
    Coach,
    MedicalStaff,
    EquipmentManager,
}

sealed class MemberTypeConverter : JsonConverter<MemberType>
{
    public override MemberType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "player" => MemberType.Player,
            "coach" => MemberType.Coach,
            "medical_staff" => MemberType.MedicalStaff,
            "equipment_manager" => MemberType.EquipmentManager,
            _ => (MemberType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MemberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MemberType.Player => "player",
                MemberType.Coach => "coach",
                MemberType.MedicalStaff => "medical_staff",
                MemberType.EquipmentManager => "equipment_manager",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the member joined or departed
/// </summary>
[JsonConverter(typeof(TransferTypeConverter))]
public enum TransferType
{
    Joined,
    Departed,
}

sealed class TransferTypeConverter : JsonConverter<TransferType>
{
    public override TransferType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "joined" => TransferType.Joined,
            "departed" => TransferType.Departed,
            _ => (TransferType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransferType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransferType.Joined => "joined",
                TransferType.Departed => "departed",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of webhook event
/// </summary>
[JsonConverter(typeof(TeamMemberTransferredEventTypeConverter))]
public enum TeamMemberTransferredEventType
{
    TeamMemberTransferred,
}

sealed class TeamMemberTransferredEventTypeConverter : JsonConverter<TeamMemberTransferredEventType>
{
    public override TeamMemberTransferredEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "team_member.transferred" => TeamMemberTransferredEventType.TeamMemberTransferred,
            _ => (TeamMemberTransferredEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TeamMemberTransferredEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TeamMemberTransferredEventType.TeamMemberTransferred => "team_member.transferred",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
