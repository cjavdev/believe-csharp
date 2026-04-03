using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;
using Believe.Exceptions;

namespace Believe.Models.TeamMembers;

/// <summary>
/// Full equipment manager model with ID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TeamMemberEquipmentManager, TeamMemberEquipmentManagerFromRaw>))]
public sealed record class TeamMemberEquipmentManager : JsonModel
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
    /// Whether this is the head equipment manager
    /// </summary>
    public bool? IsHeadKitman {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_head_kitman"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_head_kitman", value);
        }
    }

    /// <summary>
    /// Discriminator field indicating this is an equipment manager
    /// </summary>
    public ApiEnum<string, TeamMemberEquipmentManagerMemberType>? MemberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TeamMemberEquipmentManagerMemberType>>(
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

    /// <summary>
    /// List of responsibilities
    /// </summary>
    public IReadOnlyList<string>? Responsibilities {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "responsibilities"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "responsibilities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CharacterID;
        _ = this.TeamID;
        _ = this.YearsWithTeam;
        _ = this.IsHeadKitman;
        this.MemberType?.Validate();
        _ = this.Responsibilities;
    }

    public TeamMemberEquipmentManager ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamMemberEquipmentManager (
        TeamMemberEquipmentManager teamMemberEquipmentManager
    ) : base(teamMemberEquipmentManager)
    {  }
    #pragma warning restore CS8618

    public TeamMemberEquipmentManager (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TeamMemberEquipmentManager (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TeamMemberEquipmentManagerFromRaw.FromRawUnchecked"/>
    public static TeamMemberEquipmentManager FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TeamMemberEquipmentManagerFromRaw : IFromRawJson<TeamMemberEquipmentManager>
{
    /// <inheritdoc/>
    public TeamMemberEquipmentManager FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TeamMemberEquipmentManager.FromRawUnchecked(rawData);
}

/// <summary>
/// Discriminator field indicating this is an equipment manager
/// </summary>
[JsonConverter(typeof(TeamMemberEquipmentManagerMemberTypeConverter))]
public enum TeamMemberEquipmentManagerMemberType
{
    EquipmentManager
}sealed class TeamMemberEquipmentManagerMemberTypeConverter : JsonConverter<TeamMemberEquipmentManagerMemberType>
{
    public override TeamMemberEquipmentManagerMemberType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equipment_manager"=>TeamMemberEquipmentManagerMemberType.EquipmentManager,
            _ =>(TeamMemberEquipmentManagerMemberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TeamMemberEquipmentManagerMemberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TeamMemberEquipmentManagerMemberType.EquipmentManager=>"equipment_manager",
            _ => throw new BelieveInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}