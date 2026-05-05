using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Client.Core;

namespace Believe.Client.Models.Matches;

/// <summary>
/// Full match model with ID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Match, MatchFromRaw>))]
public sealed record class Match : JsonModel
{
    /// <summary>
    /// Unique identifier
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
    /// Match date and time
    /// </summary>
    public required DateTimeOffset Date
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("date");
        }
        init { this._rawData.Set("date", value); }
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
    /// Match attendance
    /// </summary>
    public long? Attendance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("attendance");
        }
        init { this._rawData.Set("attendance", value); }
    }

    /// <summary>
    /// Away team score
    /// </summary>
    public long? AwayScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("away_score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("away_score", value);
        }
    }

    /// <summary>
    /// Episode ID where this match is featured
    /// </summary>
    public string? EpisodeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("episode_id");
        }
        init { this._rawData.Set("episode_id", value); }
    }

    /// <summary>
    /// Home team score
    /// </summary>
    public long? HomeScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("home_score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("home_score", value);
        }
    }

    /// <summary>
    /// The life lesson learned from this match
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
    /// Home team possession percentage
    /// </summary>
    public double? PossessionPercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("possession_percentage");
        }
        init { this._rawData.Set("possession_percentage", value); }
    }

    /// <summary>
    /// Match result from home team perspective
    /// </summary>
    public ApiEnum<string, MatchResult>? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MatchResult>>("result");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("result", value);
        }
    }

    /// <summary>
    /// Ted's inspirational halftime speech
    /// </summary>
    public string? TedHalftimeSpeech
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ted_halftime_speech");
        }
        init { this._rawData.Set("ted_halftime_speech", value); }
    }

    /// <summary>
    /// Total ticket revenue in GBP
    /// </summary>
    public string? TicketRevenueGbp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ticket_revenue_gbp");
        }
        init { this._rawData.Set("ticket_revenue_gbp", value); }
    }

    /// <summary>
    /// Key moments that changed the match
    /// </summary>
    public IReadOnlyList<TurningPoint>? TurningPoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TurningPoint>>("turning_points");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TurningPoint>?>(
                "turning_points",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Temperature at kickoff in Celsius
    /// </summary>
    public double? WeatherTempCelsius
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("weather_temp_celsius");
        }
        init { this._rawData.Set("weather_temp_celsius", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AwayTeamID;
        _ = this.Date;
        _ = this.HomeTeamID;
        this.MatchType.Validate();
        _ = this.Attendance;
        _ = this.AwayScore;
        _ = this.EpisodeID;
        _ = this.HomeScore;
        _ = this.LessonLearned;
        _ = this.PossessionPercentage;
        this.Result?.Validate();
        _ = this.TedHalftimeSpeech;
        _ = this.TicketRevenueGbp;
        foreach (var item in this.TurningPoints ?? [])
        {
            item.Validate();
        }
        _ = this.WeatherTempCelsius;
    }

    public Match() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Match(Match match)
        : base(match) { }
#pragma warning restore CS8618

    public Match(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Match(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MatchFromRaw.FromRawUnchecked"/>
    public static Match FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatchFromRaw : IFromRawJson<Match>
{
    /// <inheritdoc/>
    public Match FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Match.FromRawUnchecked(rawData);
}
