using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Client.Core;

namespace Believe.Client.Models.TeamMembers;

[JsonConverter(
    typeof(JsonModelConverter<
        TeamMemberListCoachesPageResponse,
        TeamMemberListCoachesPageResponseFromRaw
    >)
)]
public sealed record class TeamMemberListCoachesPageResponse : JsonModel
{
    public required IReadOnlyList<TeamMemberCoach> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TeamMemberCoach>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TeamMemberCoach>>(
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

    public TeamMemberListCoachesPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamMemberListCoachesPageResponse(
        TeamMemberListCoachesPageResponse teamMemberListCoachesPageResponse
    )
        : base(teamMemberListCoachesPageResponse) { }
#pragma warning restore CS8618

    public TeamMemberListCoachesPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TeamMemberListCoachesPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TeamMemberListCoachesPageResponseFromRaw.FromRawUnchecked"/>
    public static TeamMemberListCoachesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TeamMemberListCoachesPageResponseFromRaw : IFromRawJson<TeamMemberListCoachesPageResponse>
{
    /// <inheritdoc/>
    public TeamMemberListCoachesPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TeamMemberListCoachesPageResponse.FromRawUnchecked(rawData);
}
