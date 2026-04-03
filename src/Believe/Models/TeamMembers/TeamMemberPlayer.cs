using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;
using Believe.Exceptions;

namespace Believe.Models.TeamMembers;

/// <summary>
/// Full player model with ID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TeamMemberPlayer, TeamMemberPlayerFromRaw>))]
public sealed record class TeamMemberPlayer : JsonModel
{
    /// <summary>
    /// Unique identifier for this team membership
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// ID of the character (references /characters/{id})
    /// </summary>
    public required string CharacterID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "character_id"
            );
        }
        init { this._rawData.Set("character_id", value); }
    }

    /// <summary>
    /// Jersey/shirt number
    /// </summary>
    public required long JerseyNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "jersey_number"
            );
        }
        init { this._rawData.Set("jersey_number", value); }
    }

    /// <summary>
    /// Playing position on the field
    /// </summary>
    public required ApiEnum<string, Position> Position {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Position>>(
                "position"
            );
        }
        init { this._rawData.Set("position", value); }
    }

    /// <summary>
    /// ID of the team they belong to
    /// </summary>
    public required string TeamID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "team_id"
            );
        }
        init { this._rawData.Set("team_id", value); }
    }

    /// <summary>
    /// Number of years with the current team
    /// </summary>
    public required long YearsWithTeam {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "years_with_team"
            );
        }
        init { this._rawData.Set("years_with_team", value); }
    }

    /// <summary>
    /// Total assists for the team
    /// </summary>
    public long? Assists {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "assists"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("assists", value);
        }
    }

    /// <summary>
    /// Total goals scored for the team
    /// </summary>
    public long? GoalsScored {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "goals_scored"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("goals_scored", value);
        }
    }

    /// <summary>
    /// Whether this player is team captain
    /// </summary>
    public bool? IsCaptain {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_captain"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_captain", value);
        }
    }

    /// <summary>
    /// Discriminator field indicating this is a player
    /// </summary>
    public ApiEnum<string, TeamMemberPlayerMemberType>? MemberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TeamMemberPlayerMemberType>>(
                "member_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("member_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CharacterID;
        _ = this.JerseyNumber;
        this.Position.Validate();
        _ = this.TeamID;
        _ = this.YearsWithTeam;
        _ = this.Assists;
        _ = this.GoalsScored;
        _ = this.IsCaptain;
        this.MemberType?.Validate();
    }

    public TeamMemberPlayer ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamMemberPlayer (TeamMemberPlayer teamMemberPlayer) : base(
        teamMemberPlayer
    )
    {  }
    #pragma warning restore CS8618

    public TeamMemberPlayer (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TeamMemberPlayer (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TeamMemberPlayerFromRaw.FromRawUnchecked"/>
    public static TeamMemberPlayer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TeamMemberPlayerFromRaw : IFromRawJson<TeamMemberPlayer>
{
    /// <inheritdoc/>
    public TeamMemberPlayer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TeamMemberPlayer.FromRawUnchecked(rawData);
}

/// <summary>
/// Discriminator field indicating this is a player
/// </summary>
[JsonConverter(typeof(TeamMemberPlayerMemberTypeConverter))]
public enum TeamMemberPlayerMemberType
{
    Player
}sealed class TeamMemberPlayerMemberTypeConverter : JsonConverter<TeamMemberPlayerMemberType>
{
    public override TeamMemberPlayerMemberType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "player"=>TeamMemberPlayerMemberType.Player,
            _ =>(TeamMemberPlayerMemberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TeamMemberPlayerMemberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TeamMemberPlayerMemberType.Player=>"player",
            _ => throw new BelieveInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}