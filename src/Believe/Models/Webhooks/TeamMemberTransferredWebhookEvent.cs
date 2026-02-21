using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;
using Believe.Exceptions;

namespace Believe.Models.Webhooks;

/// <summary>
/// Webhook event sent when a team member (player, coach, staff) transfers between teams.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TeamMemberTransferredWebhookEvent,
        TeamMemberTransferredWebhookEventFromRaw
    >)
)]
public sealed record class TeamMemberTransferredWebhookEvent : JsonModel
{
    /// <summary>
    /// When the event was created
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Data payload for a team member transfer event.
    /// </summary>
    public required TeamMemberTransferredWebhookEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TeamMemberTransferredWebhookEventData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Unique identifier for this event
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_id");
        }
        init { this._rawData.Set("event_id", value); }
    }

    /// <summary>
    /// The type of webhook event
    /// </summary>
    public required ApiEnum<string, TeamMemberTransferredWebhookEventEventType> EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TeamMemberTransferredWebhookEventEventType>
            >("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        this.Data.Validate();
        _ = this.EventID;
        this.EventType.Validate();
    }

    public TeamMemberTransferredWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamMemberTransferredWebhookEvent(
        TeamMemberTransferredWebhookEvent teamMemberTransferredWebhookEvent
    )
        : base(teamMemberTransferredWebhookEvent) { }
#pragma warning restore CS8618

    public TeamMemberTransferredWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TeamMemberTransferredWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TeamMemberTransferredWebhookEventFromRaw.FromRawUnchecked"/>
    public static TeamMemberTransferredWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TeamMemberTransferredWebhookEventFromRaw : IFromRawJson<TeamMemberTransferredWebhookEvent>
{
    /// <inheritdoc/>
    public TeamMemberTransferredWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TeamMemberTransferredWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Data payload for a team member transfer event.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        TeamMemberTransferredWebhookEventData,
        TeamMemberTransferredWebhookEventDataFromRaw
    >)
)]
public sealed record class TeamMemberTransferredWebhookEventData : JsonModel
{
    /// <summary>
    /// ID of the character (links to /characters)
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
    /// Name of the character
    /// </summary>
    public required string CharacterName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("character_name");
        }
        init { this._rawData.Set("character_name", value); }
    }

    /// <summary>
    /// Type of team member
    /// </summary>
    public required ApiEnum<string, TeamMemberTransferredWebhookEventDataMemberType> MemberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TeamMemberTransferredWebhookEventDataMemberType>
            >("member_type");
        }
        init { this._rawData.Set("member_type", value); }
    }

    /// <summary>
    /// ID of the team involved
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
    /// ID of the team member
    /// </summary>
    public required string TeamMemberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("team_member_id");
        }
        init { this._rawData.Set("team_member_id", value); }
    }

    /// <summary>
    /// Name of the team involved
    /// </summary>
    public required string TeamName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("team_name");
        }
        init { this._rawData.Set("team_name", value); }
    }

    /// <summary>
    /// Ted's reaction to the transfer
    /// </summary>
    public required string TedReaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ted_reaction");
        }
        init { this._rawData.Set("ted_reaction", value); }
    }

    /// <summary>
    /// Whether the member joined or departed
    /// </summary>
    public required ApiEnum<string, TeamMemberTransferredWebhookEventDataTransferType> TransferType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TeamMemberTransferredWebhookEventDataTransferType>
            >("transfer_type");
        }
        init { this._rawData.Set("transfer_type", value); }
    }

    /// <summary>
    /// Previous team ID (for joins from another team)
    /// </summary>
    public string? PreviousTeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("previous_team_id");
        }
        init { this._rawData.Set("previous_team_id", value); }
    }

    /// <summary>
    /// Previous team name (for joins from another team)
    /// </summary>
    public string? PreviousTeamName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("previous_team_name");
        }
        init { this._rawData.Set("previous_team_name", value); }
    }

    /// <summary>
    /// Transfer fee in GBP (for players)
    /// </summary>
    public string? TransferFeeGbp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transfer_fee_gbp");
        }
        init { this._rawData.Set("transfer_fee_gbp", value); }
    }

    /// <summary>
    /// Years spent with previous team
    /// </summary>
    public long? YearsWithPreviousTeam
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("years_with_previous_team");
        }
        init { this._rawData.Set("years_with_previous_team", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CharacterID;
        _ = this.CharacterName;
        this.MemberType.Validate();
        _ = this.TeamID;
        _ = this.TeamMemberID;
        _ = this.TeamName;
        _ = this.TedReaction;
        this.TransferType.Validate();
        _ = this.PreviousTeamID;
        _ = this.PreviousTeamName;
        _ = this.TransferFeeGbp;
        _ = this.YearsWithPreviousTeam;
    }

    public TeamMemberTransferredWebhookEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamMemberTransferredWebhookEventData(
        TeamMemberTransferredWebhookEventData teamMemberTransferredWebhookEventData
    )
        : base(teamMemberTransferredWebhookEventData) { }
#pragma warning restore CS8618

    public TeamMemberTransferredWebhookEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TeamMemberTransferredWebhookEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TeamMemberTransferredWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static TeamMemberTransferredWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TeamMemberTransferredWebhookEventDataFromRaw
    : IFromRawJson<TeamMemberTransferredWebhookEventData>
{
    /// <inheritdoc/>
    public TeamMemberTransferredWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TeamMemberTransferredWebhookEventData.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of team member
/// </summary>
[JsonConverter(typeof(TeamMemberTransferredWebhookEventDataMemberTypeConverter))]
public enum TeamMemberTransferredWebhookEventDataMemberType
{
    Player,
    Coach,
    MedicalStaff,
    EquipmentManager,
}

sealed class TeamMemberTransferredWebhookEventDataMemberTypeConverter
    : JsonConverter<TeamMemberTransferredWebhookEventDataMemberType>
{
    public override TeamMemberTransferredWebhookEventDataMemberType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "player" => TeamMemberTransferredWebhookEventDataMemberType.Player,
            "coach" => TeamMemberTransferredWebhookEventDataMemberType.Coach,
            "medical_staff" => TeamMemberTransferredWebhookEventDataMemberType.MedicalStaff,
            "equipment_manager" => TeamMemberTransferredWebhookEventDataMemberType.EquipmentManager,
            _ => (TeamMemberTransferredWebhookEventDataMemberType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TeamMemberTransferredWebhookEventDataMemberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TeamMemberTransferredWebhookEventDataMemberType.Player => "player",
                TeamMemberTransferredWebhookEventDataMemberType.Coach => "coach",
                TeamMemberTransferredWebhookEventDataMemberType.MedicalStaff => "medical_staff",
                TeamMemberTransferredWebhookEventDataMemberType.EquipmentManager =>
                    "equipment_manager",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the member joined or departed
/// </summary>
[JsonConverter(typeof(TeamMemberTransferredWebhookEventDataTransferTypeConverter))]
public enum TeamMemberTransferredWebhookEventDataTransferType
{
    Joined,
    Departed,
}

sealed class TeamMemberTransferredWebhookEventDataTransferTypeConverter
    : JsonConverter<TeamMemberTransferredWebhookEventDataTransferType>
{
    public override TeamMemberTransferredWebhookEventDataTransferType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "joined" => TeamMemberTransferredWebhookEventDataTransferType.Joined,
            "departed" => TeamMemberTransferredWebhookEventDataTransferType.Departed,
            _ => (TeamMemberTransferredWebhookEventDataTransferType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TeamMemberTransferredWebhookEventDataTransferType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TeamMemberTransferredWebhookEventDataTransferType.Joined => "joined",
                TeamMemberTransferredWebhookEventDataTransferType.Departed => "departed",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of webhook event
/// </summary>
[JsonConverter(typeof(TeamMemberTransferredWebhookEventEventTypeConverter))]
public enum TeamMemberTransferredWebhookEventEventType
{
    TeamMemberTransferred,
}

sealed class TeamMemberTransferredWebhookEventEventTypeConverter
    : JsonConverter<TeamMemberTransferredWebhookEventEventType>
{
    public override TeamMemberTransferredWebhookEventEventType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "team_member.transferred" =>
                TeamMemberTransferredWebhookEventEventType.TeamMemberTransferred,
            _ => (TeamMemberTransferredWebhookEventEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TeamMemberTransferredWebhookEventEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TeamMemberTransferredWebhookEventEventType.TeamMemberTransferred =>
                    "team_member.transferred",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
