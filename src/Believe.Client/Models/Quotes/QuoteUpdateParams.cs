using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Believe.Client.Core;

namespace Believe.Client.Models.Quotes;

/// <summary>
/// Update specific fields of an existing quote.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class QuoteUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? QuoteID { get; init; }

    public string? CharacterID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("character_id");
        }
        init { this._rawBodyData.Set("character_id", value); }
    }

    public string? Context
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("context");
        }
        init { this._rawBodyData.Set("context", value); }
    }

    public string? EpisodeID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("episode_id");
        }
        init { this._rawBodyData.Set("episode_id", value); }
    }

    public bool? IsFunny
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("is_funny");
        }
        init { this._rawBodyData.Set("is_funny", value); }
    }

    public bool? IsInspirational
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("is_inspirational");
        }
        init { this._rawBodyData.Set("is_inspirational", value); }
    }

    /// <summary>
    /// Types of moments when quotes occur.
    /// </summary>
    public ApiEnum<string, QuoteMoment>? MomentType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, QuoteMoment>>("moment_type");
        }
        init { this._rawBodyData.Set("moment_type", value); }
    }

    public double? PopularityScore
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>("popularity_score");
        }
        init { this._rawBodyData.Set("popularity_score", value); }
    }

    public long? Season
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("season");
        }
        init { this._rawBodyData.Set("season", value); }
    }

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
            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, QuoteTheme>>?>(
                "secondary_themes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Text
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("text");
        }
        init { this._rawBodyData.Set("text", value); }
    }

    /// <summary>
    /// Themes that quotes can be categorized under.
    /// </summary>
    public ApiEnum<string, QuoteTheme>? Theme
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, QuoteTheme>>("theme");
        }
        init { this._rawBodyData.Set("theme", value); }
    }

    public long? TimesShared
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("times_shared");
        }
        init { this._rawBodyData.Set("times_shared", value); }
    }

    public QuoteUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public QuoteUpdateParams(QuoteUpdateParams quoteUpdateParams)
        : base(quoteUpdateParams)
    {
        this.QuoteID = quoteUpdateParams.QuoteID;

        this._rawBodyData = new(quoteUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public QuoteUpdateParams(
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
    QuoteUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string quoteID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.QuoteID = quoteID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static QuoteUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string quoteID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            quoteID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["QuoteID"] = JsonSerializer.SerializeToElement(this.QuoteID),
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

    public virtual bool Equals(QuoteUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.QuoteID?.Equals(other.QuoteID) ?? other.QuoteID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/quotes/{0}", this.QuoteID)
        )
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
