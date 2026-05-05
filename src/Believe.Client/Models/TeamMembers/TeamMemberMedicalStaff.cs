using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Client.Core;
using Believe.Client.Exceptions;

namespace Believe.Client.Models.TeamMembers;

/// <summary>
/// Full medical staff model with ID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TeamMemberMedicalStaff, TeamMemberMedicalStaffFromRaw>))]
public sealed record class TeamMemberMedicalStaff : JsonModel
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
    /// Medical specialty
    /// </summary>
    public required ApiEnum<string, MedicalSpecialty> Specialty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MedicalSpecialty>>("specialty");
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
    /// Professional license number
    /// </summary>
    public string? LicenseNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_number");
        }
        init { this._rawData.Set("license_number", value); }
    }

    /// <summary>
    /// Discriminator field indicating this is medical staff
    /// </summary>
    public ApiEnum<string, TeamMemberMedicalStaffMemberType>? MemberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, TeamMemberMedicalStaffMemberType>
            >("member_type");
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
    /// Medical qualifications and degrees
    /// </summary>
    public IReadOnlyList<string>? Qualifications
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("qualifications");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "qualifications",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CharacterID;
        this.Specialty.Validate();
        _ = this.TeamID;
        _ = this.YearsWithTeam;
        _ = this.LicenseNumber;
        this.MemberType?.Validate();
        _ = this.Qualifications;
    }

    public TeamMemberMedicalStaff() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamMemberMedicalStaff(TeamMemberMedicalStaff teamMemberMedicalStaff)
        : base(teamMemberMedicalStaff) { }
#pragma warning restore CS8618

    public TeamMemberMedicalStaff(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TeamMemberMedicalStaff(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TeamMemberMedicalStaffFromRaw.FromRawUnchecked"/>
    public static TeamMemberMedicalStaff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TeamMemberMedicalStaffFromRaw : IFromRawJson<TeamMemberMedicalStaff>
{
    /// <inheritdoc/>
    public TeamMemberMedicalStaff FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TeamMemberMedicalStaff.FromRawUnchecked(rawData);
}

/// <summary>
/// Discriminator field indicating this is medical staff
/// </summary>
[JsonConverter(typeof(TeamMemberMedicalStaffMemberTypeConverter))]
public enum TeamMemberMedicalStaffMemberType
{
    MedicalStaff,
}

sealed class TeamMemberMedicalStaffMemberTypeConverter
    : JsonConverter<TeamMemberMedicalStaffMemberType>
{
    public override TeamMemberMedicalStaffMemberType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "medical_staff" => TeamMemberMedicalStaffMemberType.MedicalStaff,
            _ => (TeamMemberMedicalStaffMemberType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TeamMemberMedicalStaffMemberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TeamMemberMedicalStaffMemberType.MedicalStaff => "medical_staff",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
