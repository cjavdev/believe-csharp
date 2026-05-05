using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Client.Core;

namespace Believe.Client.Models.Coaching.Principles;

[JsonConverter(
    typeof(JsonModelConverter<PrincipleListPageResponse, PrincipleListPageResponseFromRaw>)
)]
public sealed record class PrincipleListPageResponse : JsonModel
{
    public required IReadOnlyList<CoachingPrinciple> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CoachingPrinciple>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CoachingPrinciple>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether there are more items after this page.
    /// </summary>
    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_more");
        }
        init { this._rawData.Set("has_more", value); }
    }

    public required long Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    /// <summary>
    /// Current page number (1-indexed, for display purposes).
    /// </summary>
    public required long Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page");
        }
        init { this._rawData.Set("page", value); }
    }

    /// <summary>
    /// Total number of pages.
    /// </summary>
    public required long Pages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("pages");
        }
        init { this._rawData.Set("pages", value); }
    }

    public required long Skip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("skip");
        }
        init { this._rawData.Set("skip", value); }
    }

    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
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

    public PrincipleListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PrincipleListPageResponse(PrincipleListPageResponse principleListPageResponse)
        : base(principleListPageResponse) { }
#pragma warning restore CS8618

    public PrincipleListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PrincipleListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PrincipleListPageResponseFromRaw.FromRawUnchecked"/>
    public static PrincipleListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PrincipleListPageResponseFromRaw : IFromRawJson<PrincipleListPageResponse>
{
    /// <inheritdoc/>
    public PrincipleListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PrincipleListPageResponse.FromRawUnchecked(rawData);
}
