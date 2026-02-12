using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;
using Believe.Exceptions;

namespace Believe.Models.Webhooks;

/// <summary>
/// Webhook event sent when a match completes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<MatchCompletedWebhookEvent, MatchCompletedWebhookEventFromRaw>)
)]
public sealed record class MatchCompletedWebhookEvent : JsonModel
{
    /// <summary>
    /// When the event was created
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
    /// Data payload for a match completed event.
    /// </summary>
    public required MatchCompletedWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MatchCompletedWebhookEventData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Unique identifier for this event
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
    /// The type of webhook event
    /// </summary>
    public required ApiEnum<string, MatchCompletedWebhookEventEventType> EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MatchCompletedWebhookEventEventType>
            >("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        this.Data.Validate();
        _ = this.EventID;
        this.EventType.Validate();
    }

    public MatchCompletedWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MatchCompletedWebhookEvent(MatchCompletedWebhookEvent matchCompletedWebhookEvent)
        : base(matchCompletedWebhookEvent) { }
#pragma warning restore CS8618

    public MatchCompletedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatchCompletedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MatchCompletedWebhookEventFromRaw.FromRawUnchecked"/>
    public static MatchCompletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatchCompletedWebhookEventFromRaw : IFromRawJson<MatchCompletedWebhookEvent>
{
    /// <inheritdoc/>
    public MatchCompletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MatchCompletedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Data payload for a match completed event.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        MatchCompletedWebhookEventData,
        MatchCompletedWebhookEventDataFromRaw
    >)
)]
public sealed record class MatchCompletedWebhookEventData : JsonModel
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
    public required ApiEnum<string, MatchCompletedWebhookEventDataMatchType> MatchType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MatchCompletedWebhookEventDataMatchType>
            >("match_type");
        }
        init { this._rawData.Set("match_type", value); }
    }

    /// <summary>
    /// Match result from home team perspective
    /// </summary>
    public required ApiEnum<string, MatchCompletedWebhookEventDataResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MatchCompletedWebhookEventDataResult>
            >("result");
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

    public MatchCompletedWebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MatchCompletedWebhookEventData(
        MatchCompletedWebhookEventData matchCompletedWebhookEventData
    )
        : base(matchCompletedWebhookEventData) { }
#pragma warning restore CS8618

    public MatchCompletedWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatchCompletedWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MatchCompletedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static MatchCompletedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatchCompletedWebhookEventDataFromRaw : IFromRawJson<MatchCompletedWebhookEventData>
{
    /// <inheritdoc/>
    public MatchCompletedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MatchCompletedWebhookEventData.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of match
/// </summary>
[JsonConverter(typeof(MatchCompletedWebhookEventDataMatchTypeConverter))]
public enum MatchCompletedWebhookEventDataMatchType
{
    League,
    Cup,
    Friendly,
    Playoff,
    Final,
}

sealed class MatchCompletedWebhookEventDataMatchTypeConverter
    : JsonConverter<MatchCompletedWebhookEventDataMatchType>
{
    public override MatchCompletedWebhookEventDataMatchType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "league" => MatchCompletedWebhookEventDataMatchType.League,
            "cup" => MatchCompletedWebhookEventDataMatchType.Cup,
            "friendly" => MatchCompletedWebhookEventDataMatchType.Friendly,
            "playoff" => MatchCompletedWebhookEventDataMatchType.Playoff,
            "final" => MatchCompletedWebhookEventDataMatchType.Final,
            _ => (MatchCompletedWebhookEventDataMatchType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MatchCompletedWebhookEventDataMatchType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MatchCompletedWebhookEventDataMatchType.League => "league",
                MatchCompletedWebhookEventDataMatchType.Cup => "cup",
                MatchCompletedWebhookEventDataMatchType.Friendly => "friendly",
                MatchCompletedWebhookEventDataMatchType.Playoff => "playoff",
                MatchCompletedWebhookEventDataMatchType.Final => "final",
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
[JsonConverter(typeof(MatchCompletedWebhookEventDataResultConverter))]
public enum MatchCompletedWebhookEventDataResult
{
    HomeWin,
    AwayWin,
    Draw,
}

sealed class MatchCompletedWebhookEventDataResultConverter
    : JsonConverter<MatchCompletedWebhookEventDataResult>
{
    public override MatchCompletedWebhookEventDataResult Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "home_win" => MatchCompletedWebhookEventDataResult.HomeWin,
            "away_win" => MatchCompletedWebhookEventDataResult.AwayWin,
            "draw" => MatchCompletedWebhookEventDataResult.Draw,
            _ => (MatchCompletedWebhookEventDataResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MatchCompletedWebhookEventDataResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MatchCompletedWebhookEventDataResult.HomeWin => "home_win",
                MatchCompletedWebhookEventDataResult.AwayWin => "away_win",
                MatchCompletedWebhookEventDataResult.Draw => "draw",
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
[JsonConverter(typeof(MatchCompletedWebhookEventEventTypeConverter))]
public enum MatchCompletedWebhookEventEventType
{
    MatchCompleted,
}

sealed class MatchCompletedWebhookEventEventTypeConverter
    : JsonConverter<MatchCompletedWebhookEventEventType>
{
    public override MatchCompletedWebhookEventEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "match.completed" => MatchCompletedWebhookEventEventType.MatchCompleted,
            _ => (MatchCompletedWebhookEventEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MatchCompletedWebhookEventEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MatchCompletedWebhookEventEventType.MatchCompleted => "match.completed",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
