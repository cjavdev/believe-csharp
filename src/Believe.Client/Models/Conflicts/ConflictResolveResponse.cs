using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Client.Core;

namespace Believe.Client.Models.Conflicts;

/// <summary>
/// Conflict resolution response.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConflictResolveResponse, ConflictResolveResponseFromRaw>))]
public sealed record class ConflictResolveResponse : JsonModel
{
    /// <summary>
    /// A folksy metaphor to remember
    /// </summary>
    public required string BarbecueSauceWisdom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("barbecue_sauce_wisdom");
        }
        init { this._rawData.Set("barbecue_sauce_wisdom", value); }
    }

    /// <summary>
    /// Understanding the root cause
    /// </summary>
    public required string Diagnosis
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("diagnosis");
        }
        init { this._rawData.Set("diagnosis", value); }
    }

    /// <summary>
    /// Advice from the Diamond Dogs support groups
    /// </summary>
    public required string DiamondDogsAdvice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("diamond_dogs_advice");
        }
        init { this._rawData.Set("diamond_dogs_advice", value); }
    }

    /// <summary>
    /// What resolution could look like if successful
    /// </summary>
    public required string PotentialOutcome
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("potential_outcome");
        }
        init { this._rawData.Set("potential_outcome", value); }
    }

    /// <summary>
    /// Concrete steps to resolve the conflict
    /// </summary>
    public required IReadOnlyList<string> StepsToResolution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("steps_to_resolution");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "steps_to_resolution",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// How Ted would handle this
    /// </summary>
    public required string TedApproach
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ted_approach");
        }
        init { this._rawData.Set("ted_approach", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BarbecueSauceWisdom;
        _ = this.Diagnosis;
        _ = this.DiamondDogsAdvice;
        _ = this.PotentialOutcome;
        _ = this.StepsToResolution;
        _ = this.TedApproach;
    }

    public ConflictResolveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConflictResolveResponse(ConflictResolveResponse conflictResolveResponse)
        : base(conflictResolveResponse) { }
#pragma warning restore CS8618

    public ConflictResolveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConflictResolveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConflictResolveResponseFromRaw.FromRawUnchecked"/>
    public static ConflictResolveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConflictResolveResponseFromRaw : IFromRawJson<ConflictResolveResponse>
{
    /// <inheritdoc/>
    public ConflictResolveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConflictResolveResponse.FromRawUnchecked(rawData);
}
