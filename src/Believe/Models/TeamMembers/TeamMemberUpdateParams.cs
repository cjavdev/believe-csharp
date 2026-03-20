using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;
using Believe.Exceptions;

namespace Believe.Models.TeamMembers;

/// <summary>
/// Update specific fields of an existing team member. Fields vary by member type.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TeamMemberUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? MemberID { get; init; }

    /// <summary>
    /// Update model for players.
    /// </summary>
    public required Updates Updates
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Updates>("updates");
        }
        init { this._rawBodyData.Set("updates", value); }
    }

    public TeamMemberUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamMemberUpdateParams(TeamMemberUpdateParams teamMemberUpdateParams)
        : base(teamMemberUpdateParams)
    {
        this.MemberID = teamMemberUpdateParams.MemberID;

        this._rawBodyData = new(teamMemberUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TeamMemberUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TeamMemberUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TeamMemberUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["MemberID"] = JsonSerializer.SerializeToElement(this.MemberID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TeamMemberUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.MemberID?.Equals(other.MemberID) ?? other.MemberID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/team-members/{0}", this.MemberID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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
/// Update model for players.
/// </summary>
[JsonConverter(typeof(UpdatesConverter))]
public record class Updates : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? TeamID
    {
        get
        {
            return Match<string?>(
                playerUpdate: (x) => x.TeamID,
                coachUpdate: (x) => x.TeamID,
                medicalStaffUpdate: (x) => x.TeamID,
                equipmentManagerUpdate: (x) => x.TeamID
            );
        }
    }

    public long? YearsWithTeam
    {
        get
        {
            return Match<long?>(
                playerUpdate: (x) => x.YearsWithTeam,
                coachUpdate: (x) => x.YearsWithTeam,
                medicalStaffUpdate: (x) => x.YearsWithTeam,
                equipmentManagerUpdate: (x) => x.YearsWithTeam
            );
        }
    }

    public Updates(PlayerUpdate value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Updates(CoachUpdate value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Updates(MedicalStaffUpdate value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Updates(EquipmentManagerUpdate value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Updates(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PlayerUpdate"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPlayerUpdate(out var value)) {
    ///     // `value` is of type `PlayerUpdate`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPlayerUpdate([NotNullWhen(true)] out PlayerUpdate? value)
    {
        value = this.Value as PlayerUpdate;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CoachUpdate"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCoachUpdate(out var value)) {
    ///     // `value` is of type `CoachUpdate`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCoachUpdate([NotNullWhen(true)] out CoachUpdate? value)
    {
        value = this.Value as CoachUpdate;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MedicalStaffUpdate"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMedicalStaffUpdate(out var value)) {
    ///     // `value` is of type `MedicalStaffUpdate`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMedicalStaffUpdate([NotNullWhen(true)] out MedicalStaffUpdate? value)
    {
        value = this.Value as MedicalStaffUpdate;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EquipmentManagerUpdate"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEquipmentManagerUpdate(out var value)) {
    ///     // `value` is of type `EquipmentManagerUpdate`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEquipmentManagerUpdate([NotNullWhen(true)] out EquipmentManagerUpdate? value)
    {
        value = this.Value as EquipmentManagerUpdate;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="BelieveInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (PlayerUpdate value) =&gt; {...},
    ///     (CoachUpdate value) =&gt; {...},
    ///     (MedicalStaffUpdate value) =&gt; {...},
    ///     (EquipmentManagerUpdate value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<PlayerUpdate> playerUpdate,
        Action<CoachUpdate> coachUpdate,
        Action<MedicalStaffUpdate> medicalStaffUpdate,
        Action<EquipmentManagerUpdate> equipmentManagerUpdate
    )
    {
        switch (this.Value)
        {
            case PlayerUpdate value:
                playerUpdate(value);
                break;
            case CoachUpdate value:
                coachUpdate(value);
                break;
            case MedicalStaffUpdate value:
                medicalStaffUpdate(value);
                break;
            case EquipmentManagerUpdate value:
                equipmentManagerUpdate(value);
                break;
            default:
                throw new BelieveInvalidDataException("Data did not match any variant of Updates");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="BelieveInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (PlayerUpdate value) =&gt; {...},
    ///     (CoachUpdate value) =&gt; {...},
    ///     (MedicalStaffUpdate value) =&gt; {...},
    ///     (EquipmentManagerUpdate value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<PlayerUpdate, T> playerUpdate,
        Func<CoachUpdate, T> coachUpdate,
        Func<MedicalStaffUpdate, T> medicalStaffUpdate,
        Func<EquipmentManagerUpdate, T> equipmentManagerUpdate
    )
    {
        return this.Value switch
        {
            PlayerUpdate value => playerUpdate(value),
            CoachUpdate value => coachUpdate(value),
            MedicalStaffUpdate value => medicalStaffUpdate(value),
            EquipmentManagerUpdate value => equipmentManagerUpdate(value),
            _ => throw new BelieveInvalidDataException("Data did not match any variant of Updates"),
        };
    }

    public static implicit operator Updates(PlayerUpdate value) => new(value);

    public static implicit operator Updates(CoachUpdate value) => new(value);

    public static implicit operator Updates(MedicalStaffUpdate value) => new(value);

    public static implicit operator Updates(EquipmentManagerUpdate value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="BelieveInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new BelieveInvalidDataException("Data did not match any variant of Updates");
        }
        this.Switch(
            (playerUpdate) => playerUpdate.Validate(),
            (coachUpdate) => coachUpdate.Validate(),
            (medicalStaffUpdate) => medicalStaffUpdate.Validate(),
            (equipmentManagerUpdate) => equipmentManagerUpdate.Validate()
        );
    }

    public virtual bool Equals(Updates? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            PlayerUpdate _ => 0,
            CoachUpdate _ => 1,
            MedicalStaffUpdate _ => 2,
            EquipmentManagerUpdate _ => 3,
            _ => -1,
        };
    }
}

sealed class UpdatesConverter : JsonConverter<Updates>
{
    public override Updates? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<PlayerUpdate>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is BelieveInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CoachUpdate>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is BelieveInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<MedicalStaffUpdate>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is BelieveInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<EquipmentManagerUpdate>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is BelieveInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Updates value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Update model for players.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PlayerUpdate, PlayerUpdateFromRaw>))]
public sealed record class PlayerUpdate : JsonModel
{
    public long? Assists
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("assists");
        }
        init { this._rawData.Set("assists", value); }
    }

    public long? GoalsScored
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("goals_scored");
        }
        init { this._rawData.Set("goals_scored", value); }
    }

    public bool? IsCaptain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_captain");
        }
        init { this._rawData.Set("is_captain", value); }
    }

    public long? JerseyNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("jersey_number");
        }
        init { this._rawData.Set("jersey_number", value); }
    }

    /// <summary>
    /// Football positions for players.
    /// </summary>
    public ApiEnum<string, Position>? Position
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Position>>("position");
        }
        init { this._rawData.Set("position", value); }
    }

    public string? TeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("team_id");
        }
        init { this._rawData.Set("team_id", value); }
    }

    public long? YearsWithTeam
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("years_with_team");
        }
        init { this._rawData.Set("years_with_team", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Assists;
        _ = this.GoalsScored;
        _ = this.IsCaptain;
        _ = this.JerseyNumber;
        this.Position?.Validate();
        _ = this.TeamID;
        _ = this.YearsWithTeam;
    }

    public PlayerUpdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlayerUpdate(PlayerUpdate playerUpdate)
        : base(playerUpdate) { }
#pragma warning restore CS8618

    public PlayerUpdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerUpdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlayerUpdateFromRaw.FromRawUnchecked"/>
    public static PlayerUpdate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlayerUpdateFromRaw : IFromRawJson<PlayerUpdate>
{
    /// <inheritdoc/>
    public PlayerUpdate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlayerUpdate.FromRawUnchecked(rawData);
}

/// <summary>
/// Update model for coaches.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CoachUpdate, CoachUpdateFromRaw>))]
public sealed record class CoachUpdate : JsonModel
{
    public IReadOnlyList<string>? Certifications
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("certifications");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "certifications",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Coaching specialties.
    /// </summary>
    public ApiEnum<string, CoachSpecialty>? Specialty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CoachSpecialty>>("specialty");
        }
        init { this._rawData.Set("specialty", value); }
    }

    public string? TeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("team_id");
        }
        init { this._rawData.Set("team_id", value); }
    }

    public double? WinRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("win_rate");
        }
        init { this._rawData.Set("win_rate", value); }
    }

    public long? YearsWithTeam
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("years_with_team");
        }
        init { this._rawData.Set("years_with_team", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Certifications;
        this.Specialty?.Validate();
        _ = this.TeamID;
        _ = this.WinRate;
        _ = this.YearsWithTeam;
    }

    public CoachUpdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CoachUpdate(CoachUpdate coachUpdate)
        : base(coachUpdate) { }
#pragma warning restore CS8618

    public CoachUpdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CoachUpdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CoachUpdateFromRaw.FromRawUnchecked"/>
    public static CoachUpdate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CoachUpdateFromRaw : IFromRawJson<CoachUpdate>
{
    /// <inheritdoc/>
    public CoachUpdate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CoachUpdate.FromRawUnchecked(rawData);
}

/// <summary>
/// Update model for medical staff.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MedicalStaffUpdate, MedicalStaffUpdateFromRaw>))]
public sealed record class MedicalStaffUpdate : JsonModel
{
    public string? LicenseNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_number");
        }
        init { this._rawData.Set("license_number", value); }
    }

    public IReadOnlyList<string>? Qualifications
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("qualifications");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "qualifications",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Medical staff specialties.
    /// </summary>
    public ApiEnum<string, MedicalSpecialty>? Specialty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MedicalSpecialty>>("specialty");
        }
        init { this._rawData.Set("specialty", value); }
    }

    public string? TeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("team_id");
        }
        init { this._rawData.Set("team_id", value); }
    }

    public long? YearsWithTeam
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("years_with_team");
        }
        init { this._rawData.Set("years_with_team", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LicenseNumber;
        _ = this.Qualifications;
        this.Specialty?.Validate();
        _ = this.TeamID;
        _ = this.YearsWithTeam;
    }

    public MedicalStaffUpdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MedicalStaffUpdate(MedicalStaffUpdate medicalStaffUpdate)
        : base(medicalStaffUpdate) { }
#pragma warning restore CS8618

    public MedicalStaffUpdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MedicalStaffUpdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MedicalStaffUpdateFromRaw.FromRawUnchecked"/>
    public static MedicalStaffUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MedicalStaffUpdateFromRaw : IFromRawJson<MedicalStaffUpdate>
{
    /// <inheritdoc/>
    public MedicalStaffUpdate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MedicalStaffUpdate.FromRawUnchecked(rawData);
}

/// <summary>
/// Update model for equipment managers.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EquipmentManagerUpdate, EquipmentManagerUpdateFromRaw>))]
public sealed record class EquipmentManagerUpdate : JsonModel
{
    public bool? IsHeadKitman
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_head_kitman");
        }
        init { this._rawData.Set("is_head_kitman", value); }
    }

    public IReadOnlyList<string>? Responsibilities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("responsibilities");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "responsibilities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? TeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("team_id");
        }
        init { this._rawData.Set("team_id", value); }
    }

    public long? YearsWithTeam
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("years_with_team");
        }
        init { this._rawData.Set("years_with_team", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsHeadKitman;
        _ = this.Responsibilities;
        _ = this.TeamID;
        _ = this.YearsWithTeam;
    }

    public EquipmentManagerUpdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EquipmentManagerUpdate(EquipmentManagerUpdate equipmentManagerUpdate)
        : base(equipmentManagerUpdate) { }
#pragma warning restore CS8618

    public EquipmentManagerUpdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EquipmentManagerUpdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EquipmentManagerUpdateFromRaw.FromRawUnchecked"/>
    public static EquipmentManagerUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EquipmentManagerUpdateFromRaw : IFromRawJson<EquipmentManagerUpdate>
{
    /// <inheritdoc/>
    public EquipmentManagerUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EquipmentManagerUpdate.FromRawUnchecked(rawData);
}
