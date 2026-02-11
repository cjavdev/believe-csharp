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
/// Full coach model with ID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TeamMemberCoach, TeamMemberCoachFromRaw>))]
public sealed record class TeamMemberCoach : JsonModel
{
    /// <summary>
    /// Unique identifier for this team membership
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// ID of the character (references /characters/{id})
    /// </summary>
    public required string CharacterID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("character_id");
        }
        init { this._rawData.Set("character_id", value); }
    }

    /// <summary>
    /// Coaching specialty/role
    /// </summary>
    public required ApiEnum<string, CoachSpecialty> Specialty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CoachSpecialty>>("specialty");
        }
        init { this._rawData.Set("specialty", value); }
    }

    /// <summary>
    /// ID of the team they belong to
    /// </summary>
    public required string TeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("team_id");
        }
        init { this._rawData.Set("team_id", value); }
    }

    /// <summary>
    /// Number of years with the current team
    /// </summary>
    public required long YearsWithTeam
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("years_with_team");
        }
        init { this._rawData.Set("years_with_team", value); }
    }

    /// <summary>
    /// Coaching certifications and licenses
    /// </summary>
    public IReadOnlyList<string>? Certifications
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("certifications");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "certifications",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Discriminator field indicating this is a coach
    /// </summary>
    public ApiEnum<string, TeamMemberCoachMemberType>? MemberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TeamMemberCoachMemberType>>(
                "member_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("member_type", value);
        }
    }

    /// <summary>
    /// Career win rate (0.0 to 1.0)
    /// </summary>
    public double? WinRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("win_rate");
        }
        init { this._rawData.Set("win_rate", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CharacterID;
        this.Specialty.Validate();
        _ = this.TeamID;
        _ = this.YearsWithTeam;
        _ = this.Certifications;
        this.MemberType?.Validate();
        _ = this.WinRate;
    }

    public TeamMemberCoach() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamMemberCoach(TeamMemberCoach teamMemberCoach)
        : base(teamMemberCoach) { }
#pragma warning restore CS8618

    public TeamMemberCoach(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TeamMemberCoach(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TeamMemberCoachFromRaw.FromRawUnchecked"/>
    public static TeamMemberCoach FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TeamMemberCoachFromRaw : IFromRawJson<TeamMemberCoach>
{
    /// <inheritdoc/>
    public TeamMemberCoach FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TeamMemberCoach.FromRawUnchecked(rawData);
}

/// <summary>
/// Discriminator field indicating this is a coach
/// </summary>
[JsonConverter(typeof(TeamMemberCoachMemberTypeConverter))]
public enum TeamMemberCoachMemberType
{
    Coach,
}

sealed class TeamMemberCoachMemberTypeConverter : JsonConverter<TeamMemberCoachMemberType>
{
    public override TeamMemberCoachMemberType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "coach" => TeamMemberCoachMemberType.Coach,
            _ => (TeamMemberCoachMemberType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TeamMemberCoachMemberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TeamMemberCoachMemberType.Coach => "coach",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
