using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Characters;

/// <summary>
/// Emotional intelligence statistics for a character.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmotionalStats, EmotionalStatsFromRaw>))]
public sealed record class EmotionalStats : JsonModel
{
    /// <summary>
    /// Level of curiosity over judgment (0-100)
    /// </summary>
    public required long Curiosity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("curiosity");
        }
        init { this._rawData.Set("curiosity", value); }
    }

    /// <summary>
    /// Capacity for empathy (0-100)
    /// </summary>
    public required long Empathy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("empathy");
        }
        init { this._rawData.Set("empathy", value); }
    }

    /// <summary>
    /// Level of optimism (0-100)
    /// </summary>
    public required long Optimism
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("optimism");
        }
        init { this._rawData.Set("optimism", value); }
    }

    /// <summary>
    /// Bounce-back ability (0-100)
    /// </summary>
    public required long Resilience
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("resilience");
        }
        init { this._rawData.Set("resilience", value); }
    }

    /// <summary>
    /// Willingness to be vulnerable (0-100)
    /// </summary>
    public required long Vulnerability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("vulnerability");
        }
        init { this._rawData.Set("vulnerability", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Curiosity;
        _ = this.Empathy;
        _ = this.Optimism;
        _ = this.Resilience;
        _ = this.Vulnerability;
    }

    public EmotionalStats() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmotionalStats(EmotionalStats emotionalStats)
        : base(emotionalStats) { }
#pragma warning restore CS8618

    public EmotionalStats(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmotionalStats(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmotionalStatsFromRaw.FromRawUnchecked"/>
    public static EmotionalStats FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmotionalStatsFromRaw : IFromRawJson<EmotionalStats>
{
    /// <inheritdoc/>
    public EmotionalStats FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EmotionalStats.FromRawUnchecked(rawData);
}
