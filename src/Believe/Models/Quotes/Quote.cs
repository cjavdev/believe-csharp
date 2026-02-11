using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Quotes;

/// <summary>
/// Full quote model with ID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Quote, QuoteFromRaw>))]
public sealed record class Quote : JsonModel
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
    /// ID of the character who said it
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
    /// Context in which the quote was said
    /// </summary>
    public required string Context
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("context");
        }
        init { this._rawData.Set("context", value); }
    }

    /// <summary>
    /// Type of moment when the quote was said
    /// </summary>
    public required ApiEnum<string, QuoteMoment> MomentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, QuoteMoment>>("moment_type");
        }
        init { this._rawData.Set("moment_type", value); }
    }

    /// <summary>
    /// The quote text
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Primary theme of the quote
    /// </summary>
    public required ApiEnum<string, QuoteTheme> Theme
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, QuoteTheme>>("theme");
        }
        init { this._rawData.Set("theme", value); }
    }

    /// <summary>
    /// Episode where the quote appears
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
    /// Whether this quote is humorous
    /// </summary>
    public bool? IsFunny
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_funny");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_funny", value);
        }
    }

    /// <summary>
    /// Whether this quote is inspirational
    /// </summary>
    public bool? IsInspirational
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_inspirational");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_inspirational", value);
        }
    }

    /// <summary>
    /// Popularity/virality score (0-100)
    /// </summary>
    public double? PopularityScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("popularity_score");
        }
        init { this._rawData.Set("popularity_score", value); }
    }

    /// <summary>
    /// Additional themes
    /// </summary>
    public IReadOnlyList<ApiEnum<string, QuoteTheme>>? SecondaryThemes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, QuoteTheme>>>(
                "secondary_themes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, QuoteTheme>>?>(
                "secondary_themes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of times shared on social media
    /// </summary>
    public long? TimesShared
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("times_shared");
        }
        init { this._rawData.Set("times_shared", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CharacterID;
        _ = this.Context;
        this.MomentType.Validate();
        _ = this.Text;
        this.Theme.Validate();
        _ = this.EpisodeID;
        _ = this.IsFunny;
        _ = this.IsInspirational;
        _ = this.PopularityScore;
        foreach (var item in this.SecondaryThemes ?? [])
        {
            item.Validate();
        }
        _ = this.TimesShared;
    }

    public Quote() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Quote(Quote quote)
        : base(quote) { }
#pragma warning restore CS8618

    public Quote(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Quote(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="QuoteFromRaw.FromRawUnchecked"/>
    public static Quote FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class QuoteFromRaw : IFromRawJson<Quote>
{
    /// <inheritdoc/>
    public Quote FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Quote.FromRawUnchecked(rawData);
}
