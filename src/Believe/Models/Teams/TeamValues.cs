using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Teams;

/// <summary>
/// Core values that define a team's culture.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TeamValues, TeamValuesFromRaw>))]
public sealed record class TeamValues : JsonModel
{
    /// <summary>
    /// The team's primary guiding value
    /// </summary>
    public required string PrimaryValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "primary_value"
            );
        }
        init { this._rawData.Set("primary_value", value); }
    }

    /// <summary>
    /// Supporting values
    /// </summary>
    public required IReadOnlyList<string> SecondaryValues {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "secondary_values"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "secondary_values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Team's motivational motto
    /// </summary>
    public required string TeamMotto {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "team_motto"
            );
        }
        init { this._rawData.Set("team_motto", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PrimaryValue;
        _ = this.SecondaryValues;
        _ = this.TeamMotto;
    }

    public TeamValues ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamValues (TeamValues teamValues) : base(teamValues)
    {  }
    #pragma warning restore CS8618

    public TeamValues (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TeamValues (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TeamValuesFromRaw.FromRawUnchecked"/>
    public static TeamValues FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TeamValuesFromRaw : IFromRawJson<TeamValues>
{
    /// <inheritdoc/>
    public TeamValues FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TeamValues.FromRawUnchecked(rawData);
}