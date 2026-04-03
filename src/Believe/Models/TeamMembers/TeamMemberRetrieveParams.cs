using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Believe.Core;

namespace Believe.Models.TeamMembers;

/// <summary>
/// Retrieve detailed information about a specific team member.
///
/// <para>The response is a **union type (oneOf)** - the actual shape depends on the
/// member's type: - **player**: Includes position, jersey_number, goals_scored,
/// assists, is_captain - **coach**: Includes specialty, certifications, win_rate
/// - **medical_staff**: Includes specialty, qualifications, license_number - **equipment_manager**:
/// Includes responsibilities, is_head_kitman</para>
///
/// <para>Use `character_id` to fetch full character details from `/characters/{character_id}`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TeamMemberRetrieveParams : ParamsBase
{
    public string? MemberID { get; init; }

    public TeamMemberRetrieveParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamMemberRetrieveParams (
        TeamMemberRetrieveParams teamMemberRetrieveParams
    ) : base(teamMemberRetrieveParams)
    { this.MemberID = teamMemberRetrieveParams.MemberID; }
    #pragma warning restore CS8618

    public TeamMemberRetrieveParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TeamMemberRetrieveParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string memberID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.MemberID = memberID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TeamMemberRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string memberID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            memberID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["MemberID"] = JsonSerializer.SerializeToElement(this.MemberID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(TeamMemberRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.MemberID?.Equals(other.MemberID) ?? other.MemberID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/team-members/{0}",
            this.MemberID)
        )
        {
            Query = this.QueryString(options)
        }.Uri ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}