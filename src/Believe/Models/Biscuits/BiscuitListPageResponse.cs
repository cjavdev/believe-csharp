using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Biscuits;

[JsonConverter(typeof(JsonModelConverter<BiscuitListPageResponse, BiscuitListPageResponseFromRaw>))]
public sealed record class BiscuitListPageResponse : JsonModel
{
    public required IReadOnlyList<Biscuit> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Biscuit>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Biscuit>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether there are more items after this page.
    /// </summary>
    public required bool HasMore {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "has_more"
            );
        }
        init { this._rawData.Set("has_more", value); }
    }

    public required long Limit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "limit"
            );
        }
        init { this._rawData.Set("limit", value); }
    }

    /// <summary>
    /// Current page number (1-indexed, for display purposes).
    /// </summary>
    public required long Page {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page"
            );
        }
        init { this._rawData.Set("page", value); }
    }

    /// <summary>
    /// Total number of pages.
    /// </summary>
    public required long Pages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "pages"
            );
        }
        init { this._rawData.Set("pages", value); }
    }

    public required long Skip {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "skip"
            );
        }
        init { this._rawData.Set("skip", value); }
    }

    public required long Total {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total"
            );
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.Limit;
        _ = this.Page;
        _ = this.Pages;
        _ = this.Skip;
        _ = this.Total;
    }

    public BiscuitListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BiscuitListPageResponse (
        BiscuitListPageResponse biscuitListPageResponse
    ) : base(biscuitListPageResponse)
    {  }
    #pragma warning restore CS8618

    public BiscuitListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BiscuitListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BiscuitListPageResponseFromRaw.FromRawUnchecked"/>
    public static BiscuitListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BiscuitListPageResponseFromRaw : IFromRawJson<BiscuitListPageResponse>
{
    /// <inheritdoc/>
    public BiscuitListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BiscuitListPageResponse.FromRawUnchecked(rawData);
}