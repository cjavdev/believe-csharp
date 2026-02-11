using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Matches;

/// <summary>
/// A pivotal moment in a match.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TurningPoint, TurningPointFromRaw>))]
public sealed record class TurningPoint : JsonModel
{
    /// <summary>
    /// What happened
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// How this affected the team emotionally
    /// </summary>
    public required string EmotionalImpact
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("emotional_impact");
        }
        init { this._rawData.Set("emotional_impact", value); }
    }

    /// <summary>
    /// Minute of the match
    /// </summary>
    public required long Minute
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("minute");
        }
        init { this._rawData.Set("minute", value); }
    }

    /// <summary>
    /// Character ID who was central to this moment
    /// </summary>
    public string? CharacterInvolved
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("character_involved");
        }
        init { this._rawData.Set("character_involved", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.EmotionalImpact;
        _ = this.Minute;
        _ = this.CharacterInvolved;
    }

    public TurningPoint() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TurningPoint(TurningPoint turningPoint)
        : base(turningPoint) { }
#pragma warning restore CS8618

    public TurningPoint(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TurningPoint(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TurningPointFromRaw.FromRawUnchecked"/>
    public static TurningPoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TurningPointFromRaw : IFromRawJson<TurningPoint>
{
    /// <inheritdoc/>
    public TurningPoint FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TurningPoint.FromRawUnchecked(rawData);
}
