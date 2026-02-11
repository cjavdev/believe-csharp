using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Characters;

/// <summary>
/// Character development arc.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GrowthArc, GrowthArcFromRaw>))]
public sealed record class GrowthArc : JsonModel
{
    /// <summary>
    /// Key breakthrough moment
    /// </summary>
    public required string Breakthrough
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("breakthrough");
        }
        init { this._rawData.Set("breakthrough", value); }
    }

    /// <summary>
    /// Main challenge faced
    /// </summary>
    public required string Challenge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("challenge");
        }
        init { this._rawData.Set("challenge", value); }
    }

    /// <summary>
    /// Where the character ends up
    /// </summary>
    public required string EndingPoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ending_point");
        }
        init { this._rawData.Set("ending_point", value); }
    }

    /// <summary>
    /// Season number
    /// </summary>
    public required long Season
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("season");
        }
        init { this._rawData.Set("season", value); }
    }

    /// <summary>
    /// Where the character starts emotionally
    /// </summary>
    public required string StartingPoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("starting_point");
        }
        init { this._rawData.Set("starting_point", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Breakthrough;
        _ = this.Challenge;
        _ = this.EndingPoint;
        _ = this.Season;
        _ = this.StartingPoint;
    }

    public GrowthArc() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GrowthArc(GrowthArc growthArc)
        : base(growthArc) { }
#pragma warning restore CS8618

    public GrowthArc(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GrowthArc(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GrowthArcFromRaw.FromRawUnchecked"/>
    public static GrowthArc FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GrowthArcFromRaw : IFromRawJson<GrowthArc>
{
    /// <inheritdoc/>
    public GrowthArc FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GrowthArc.FromRawUnchecked(rawData);
}
