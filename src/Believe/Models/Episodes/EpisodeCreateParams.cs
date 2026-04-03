using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Believe.Core;

namespace Believe.Models.Episodes;

/// <summary>
/// Add a new episode to the series.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EpisodeCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Original air date
    /// </summary>
    public required string AirDate {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "air_date"
            );
        }
        init { this._rawBodyData.Set("air_date", value); }
    }

    /// <summary>
    /// Characters with significant development
    /// </summary>
    public required IReadOnlyList<string> CharacterFocus {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>(
                "character_focus"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "director"
            );
        }
        init { this._rawBodyData.Set("director", value); }
    }

    /// <summary>
    /// Episode number within season
    /// </summary>
    public required long EpisodeNumber {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>(
                "episode_number"
            );
        }
        init { this._rawBodyData.Set("episode_number", value); }
    }

    /// <summary>
    /// Central theme of the episode
    /// </summary>
    public required string MainTheme {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "main_theme"
            );
        }
        init { this._rawBodyData.Set("main_theme", value); }
    }

    /// <summary>
    /// Episode runtime in minutes
    /// </summary>
    public required long RuntimeMinutes {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>(
                "runtime_minutes"
            );
        }
        init { this._rawBodyData.Set("runtime_minutes", value); }
    }

    /// <summary>
    /// Season number
    /// </summary>
    public required long Season {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>(
                "season"
            );
        }
        init { this._rawBodyData.Set("season", value); }
    }

    /// <summary>
    /// Brief plot synopsis
    /// </summary>
    public required string Synopsis {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "synopsis"
            );
        }
        init { this._rawBodyData.Set("synopsis", value); }
    }

    /// <summary>
    /// Key piece of Ted wisdom from the episode
    /// </summary>
    public required string TedWisdom {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "ted_wisdom"
            );
        }
        init { this._rawBodyData.Set("ted_wisdom", value); }
    }

    /// <summary>
    /// Episode title
    /// </summary>
    public required string Title {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "title"
            );
        }
        init { this._rawBodyData.Set("title", value); }
    }

    /// <summary>
    /// Episode writer(s)
    /// </summary>
    public required string Writer {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "writer"
            );
        }
        init { this._rawBodyData.Set("writer", value); }
    }

    /// <summary>
    /// Notable biscuits with the boss scene
    /// </summary>
    public string? BiscuitsWithBossMoment {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "biscuits_with_boss_moment"
            );
        }
        init { this._rawBodyData.Set("biscuits_with_boss_moment", value); }
    }

    /// <summary>
    /// Standout moments from the episode
    /// </summary>
    public IReadOnlyList<string>? MemorableMoments {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "memorable_moments"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "us_viewers_millions"
            );
        }
        init { this._rawBodyData.Set("us_viewers_millions", value); }
    }

    /// <summary>
    /// Viewer rating out of 10
    /// </summary>
    public double? ViewerRating {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "viewer_rating"
            );
        }
        init { this._rawBodyData.Set("viewer_rating", value); }
    }

    public EpisodeCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EpisodeCreateParams (EpisodeCreateParams episodeCreateParams) : base(
        episodeCreateParams
    )
    { this._rawBodyData = new(episodeCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public EpisodeCreateParams (
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
    EpisodeCreateParams (
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
    public static EpisodeCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(EpisodeCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/episodes"
        )
        {
            Query = this.QueryString(options)
        }.Uri ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}