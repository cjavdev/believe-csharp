using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Client.Core;
using Believe.Client.Exceptions;

namespace Believe.Client.Models.TeamMembers;

/// <summary>
/// Get a paginated list of all team members.
///
/// <para>This endpoint demonstrates **union types (oneOf)** in the response. Each
/// team member can be one of: Player, Coach, MedicalStaff, or EquipmentManager. The
/// `member_type` field acts as a discriminator to determine the shape of each object.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TeamMemberListParams : ParamsBase
{
    /// <summary>
    /// Maximum number of items to return (max: 100)
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Filter by member type
    /// </summary>
    public ApiEnum<string, TeamMemberListParamsMemberType>? MemberType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, TeamMemberListParamsMemberType>
            >("member_type");
        }
        init { this._rawQueryData.Set("member_type", value); }
    }

    /// <summary>
    /// Number of items to skip (offset)
    /// </summary>
    public long? Skip
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("skip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("skip", value);
        }
    }

    /// <summary>
    /// Filter by team ID
    /// </summary>
    public string? TeamID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("team_id");
        }
        init { this._rawQueryData.Set("team_id", value); }
    }

    public TeamMemberListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamMemberListParams(TeamMemberListParams teamMemberListParams)
        : base(teamMemberListParams) { }
#pragma warning restore CS8618

    public TeamMemberListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TeamMemberListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TeamMemberListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TeamMemberListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/team-members")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Filter by member type
/// </summary>
[JsonConverter(typeof(TeamMemberListParamsMemberTypeConverter))]
public enum TeamMemberListParamsMemberType
{
    Player,
    Coach,
    MedicalStaff,
    EquipmentManager,
}

sealed class TeamMemberListParamsMemberTypeConverter : JsonConverter<TeamMemberListParamsMemberType>
{
    public override TeamMemberListParamsMemberType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "player" => TeamMemberListParamsMemberType.Player,
            "coach" => TeamMemberListParamsMemberType.Coach,
            "medical_staff" => TeamMemberListParamsMemberType.MedicalStaff,
            "equipment_manager" => TeamMemberListParamsMemberType.EquipmentManager,
            _ => (TeamMemberListParamsMemberType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TeamMemberListParamsMemberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TeamMemberListParamsMemberType.Player => "player",
                TeamMemberListParamsMemberType.Coach => "coach",
                TeamMemberListParamsMemberType.MedicalStaff => "medical_staff",
                TeamMemberListParamsMemberType.EquipmentManager => "equipment_manager",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
