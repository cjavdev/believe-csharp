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
/// Update specific fields of an existing episode.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EpisodeUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? EpisodeID { get; init; }

    public string? AirDate {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "air_date"
            );
        }
        init { this._rawBodyData.Set("air_date", value); }
    }

    public string? BiscuitsWithBossMoment {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "biscuits_with_boss_moment"
            );
        }
        init { this._rawBodyData.Set("biscuits_with_boss_moment", value); }
    }

    public IReadOnlyList<string>? CharacterFocus {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "character_focus"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "character_focus",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Director {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "director"
            );
        }
        init { this._rawBodyData.Set("director", value); }
    }

    public long? EpisodeNumber {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "episode_number"
            );
        }
        init { this._rawBodyData.Set("episode_number", value); }
    }

    public string? MainTheme {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "main_theme"
            );
        }
        init { this._rawBodyData.Set("main_theme", value); }
    }

    public IReadOnlyList<string>? MemorableMoments {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "memorable_moments"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "memorable_moments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? RuntimeMinutes {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "runtime_minutes"
            );
        }
        init { this._rawBodyData.Set("runtime_minutes", value); }
    }

    public long? Season {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "season"
            );
        }
        init { this._rawBodyData.Set("season", value); }
    }

    public string? Synopsis {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "synopsis"
            );
        }
        init { this._rawBodyData.Set("synopsis", value); }
    }

    public string? TedWisdom {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "ted_wisdom"
            );
        }
        init { this._rawBodyData.Set("ted_wisdom", value); }
    }

    public string? Title {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "title"
            );
        }
        init { this._rawBodyData.Set("title", value); }
    }

    public double? UsViewersMillions {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "us_viewers_millions"
            );
        }
        init { this._rawBodyData.Set("us_viewers_millions", value); }
    }

    public double? ViewerRating {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "viewer_rating"
            );
        }
        init { this._rawBodyData.Set("viewer_rating", value); }
    }

    public string? Writer {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "writer"
            );
        }
        init { this._rawBodyData.Set("writer", value); }
    }

    public EpisodeUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EpisodeUpdateParams (EpisodeUpdateParams episodeUpdateParams) : base(
        episodeUpdateParams
    )
    {
        this.EpisodeID = episodeUpdateParams.EpisodeID;

        this._rawBodyData = new(episodeUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public EpisodeUpdateParams (
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
    EpisodeUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string episodeID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.EpisodeID = episodeID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EpisodeUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string episodeID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            episodeID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["EpisodeID"] = JsonSerializer.SerializeToElement(this.EpisodeID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(EpisodeUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.EpisodeID?.Equals(other.EpisodeID) ?? other.EpisodeID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/episodes/{0}",
            this.EpisodeID)
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