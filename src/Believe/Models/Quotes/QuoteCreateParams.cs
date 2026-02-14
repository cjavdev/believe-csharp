using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Believe.Core;

namespace Believe.Models.Quotes;

/// <summary>
/// Add a new memorable quote to the collection.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class QuoteCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// ID of the character who said it
    /// </summary>
    public required string CharacterID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("character_id");
        }
        init { this._rawBodyData.Set("character_id", value); }
    }

    /// <summary>
    /// Context in which the quote was said
    /// </summary>
    public required string Context
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("context");
        }
        init { this._rawBodyData.Set("context", value); }
    }

    /// <summary>
    /// Type of moment when the quote was said
    /// </summary>
    public required ApiEnum<string, QuoteMoment> MomentType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, QuoteMoment>>("moment_type");
        }
        init { this._rawBodyData.Set("moment_type", value); }
    }

    /// <summary>
    /// The quote text
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("text");
        }
        init { this._rawBodyData.Set("text", value); }
    }

    /// <summary>
    /// Primary theme of the quote
    /// </summary>
    public required ApiEnum<string, QuoteTheme> Theme
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, QuoteTheme>>("theme");
        }
        init { this._rawBodyData.Set("theme", value); }
    }

    /// <summary>
    /// Episode where the quote appears
    /// </summary>
    public string? EpisodeID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("episode_id");
        }
        init { this._rawBodyData.Set("episode_id", value); }
    }

    /// <summary>
    /// Whether this quote is humorous
    /// </summary>
    public bool? IsFunny
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("is_funny");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("is_funny", value);
        }
    }

    /// <summary>
    /// Whether this quote is inspirational
    /// </summary>
    public bool? IsInspirational
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("is_inspirational");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("is_inspirational", value);
        }
    }

    /// <summary>
    /// Popularity/virality score (0-100)
    /// </summary>
    public double? PopularityScore
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("popularity_score");
        }
        init { this._rawBodyData.Set("popularity_score", value); }
    }

    /// <summary>
    /// Additional themes
    /// </summary>
    public IReadOnlyList<ApiEnum<string, QuoteTheme>>? SecondaryThemes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ApiEnum<string, QuoteTheme>>>(
                "secondary_themes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, QuoteTheme>>?>(
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("times_shared");
        }
        init { this._rawBodyData.Set("times_shared", value); }
    }

    public QuoteCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public QuoteCreateParams(QuoteCreateParams quoteCreateParams)
        : base(quoteCreateParams)
    {
        this._rawBodyData = new(quoteCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public QuoteCreateParams(
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
    QuoteCreateParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static QuoteCreateParams FromRawUnchecked(
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

    public virtual bool Equals(QuoteCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/quotes")
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
