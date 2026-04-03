using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Episodes;

/// <summary>
/// Full episode model with ID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Episode, EpisodeFromRaw>))]
public sealed record class Episode : JsonModel
{
    /// <summary>
    /// Unique identifier (format: s##e##)
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Original air date
    /// </summary>
    public required string AirDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "air_date"
            );
        }
        init { this._rawData.Set("air_date", value); }
    }

    /// <summary>
    /// Characters with significant development
    /// </summary>
    public required IReadOnlyList<string> CharacterFocus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "character_focus"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "character_focus",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Episode director
    /// </summary>
    public required string Director {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "director"
            );
        }
        init { this._rawData.Set("director", value); }
    }

    /// <summary>
    /// Episode number within season
    /// </summary>
    public required long EpisodeNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "episode_number"
            );
        }
        init { this._rawData.Set("episode_number", value); }
    }

    /// <summary>
    /// Central theme of the episode
    /// </summary>
    public required string MainTheme {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "main_theme"
            );
        }
        init { this._rawData.Set("main_theme", value); }
    }

    /// <summary>
    /// Episode runtime in minutes
    /// </summary>
    public required long RuntimeMinutes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "runtime_minutes"
            );
        }
        init { this._rawData.Set("runtime_minutes", value); }
    }

    /// <summary>
    /// Season number
    /// </summary>
    public required long Season {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "season"
            );
        }
        init { this._rawData.Set("season", value); }
    }

    /// <summary>
    /// Brief plot synopsis
    /// </summary>
    public required string Synopsis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "synopsis"
            );
        }
        init { this._rawData.Set("synopsis", value); }
    }

    /// <summary>
    /// Key piece of Ted wisdom from the episode
    /// </summary>
    public required string TedWisdom {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "ted_wisdom"
            );
        }
        init { this._rawData.Set("ted_wisdom", value); }
    }

    /// <summary>
    /// Episode title
    /// </summary>
    public required string Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "title"
            );
        }
        init { this._rawData.Set("title", value); }
    }

    /// <summary>
    /// Episode writer(s)
    /// </summary>
    public required string Writer {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "writer"
            );
        }
        init { this._rawData.Set("writer", value); }
    }

    /// <summary>
    /// Notable biscuits with the boss scene
    /// </summary>
    public string? BiscuitsWithBossMoment {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "biscuits_with_boss_moment"
            );
        }
        init { this._rawData.Set("biscuits_with_boss_moment", value); }
    }

    /// <summary>
    /// Standout moments from the episode
    /// </summary>
    public IReadOnlyList<string>? MemorableMoments {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "memorable_moments"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "memorable_moments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// US viewership in millions
    /// </summary>
    public double? UsViewersMillions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "us_viewers_millions"
            );
        }
        init { this._rawData.Set("us_viewers_millions", value); }
    }

    /// <summary>
    /// Viewer rating out of 10
    /// </summary>
    public double? ViewerRating {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "viewer_rating"
            );
        }
        init { this._rawData.Set("viewer_rating", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AirDate;
        _ = this.CharacterFocus;
        _ = this.Director;
        _ = this.EpisodeNumber;
        _ = this.MainTheme;
        _ = this.RuntimeMinutes;
        _ = this.Season;
        _ = this.Synopsis;
        _ = this.TedWisdom;
        _ = this.Title;
        _ = this.Writer;
        _ = this.BiscuitsWithBossMoment;
        _ = this.MemorableMoments;
        _ = this.UsViewersMillions;
        _ = this.ViewerRating;
    }

    public Episode ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Episode (Episode episode) : base(episode)
    {  }
    #pragma warning restore CS8618

    public Episode (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Episode (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EpisodeFromRaw.FromRawUnchecked"/>
    public static Episode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EpisodeFromRaw : IFromRawJson<Episode>
{
    /// <inheritdoc/>
    public Episode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Episode.FromRawUnchecked(rawData);
}