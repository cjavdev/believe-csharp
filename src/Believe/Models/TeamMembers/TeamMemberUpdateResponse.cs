using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;
using Believe.Exceptions;

namespace Believe.Models.TeamMembers;

/// <summary>
/// Full player model with ID.
/// </summary>
[JsonConverter(typeof(TeamMemberUpdateResponseConverter))]
public record class TeamMemberUpdateResponse : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string ID {
        get {
            return Match(player: ( x )=>x.ID,
            coach: ( x )=>x.ID,
            medicalStaff: ( x )=>x.ID,
            equipmentManager: ( x )=>x.ID);
        }
    }

    public string CharacterID {
        get {
            return Match(player: ( x )=>x.CharacterID,
            coach: ( x )=>x.CharacterID,
            medicalStaff: ( x )=>x.CharacterID,
            equipmentManager: ( x )=>x.CharacterID);
        }
    }

    public string TeamID {
        get {
            return Match(player: ( x )=>x.TeamID,
            coach: ( x )=>x.TeamID,
            medicalStaff: ( x )=>x.TeamID,
            equipmentManager: ( x )=>x.TeamID);
        }
    }

    public long YearsWithTeam {
        get {
            return Match(player: ( x )=>x.YearsWithTeam,
            coach: ( x )=>x.YearsWithTeam,
            medicalStaff: ( x )=>x.YearsWithTeam,
            equipmentManager: ( x )=>x.YearsWithTeam);
        }
    }

    public TeamMemberUpdateResponse (
        TeamMemberPlayer value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TeamMemberUpdateResponse (
        TeamMemberCoach value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TeamMemberUpdateResponse (
        TeamMemberMedicalStaff value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TeamMemberUpdateResponse (
        TeamMemberEquipmentManager value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TeamMemberUpdateResponse (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TeamMemberPlayer"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickPlayer(out var value)) {
///     // `value` is of type `TeamMemberPlayer`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickPlayer([NotNullWhen(true)] out TeamMemberPlayer? value)
    {
        value =this.Value as TeamMemberPlayer ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TeamMemberCoach"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCoach(out var value)) {
///     // `value` is of type `TeamMemberCoach`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCoach([NotNullWhen(true)] out TeamMemberCoach? value)
    {
        value =this.Value as TeamMemberCoach ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TeamMemberMedicalStaff"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickMedicalStaff(out var value)) {
///     // `value` is of type `TeamMemberMedicalStaff`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickMedicalStaff(
        [NotNullWhen(true)] out TeamMemberMedicalStaff? value
    )
    {
        value =this.Value as TeamMemberMedicalStaff ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TeamMemberEquipmentManager"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickEquipmentManager(out var value)) {
///     // `value` is of type `TeamMemberEquipmentManager`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickEquipmentManager(
        [NotNullWhen(true)] out TeamMemberEquipmentManager? value
    )
    {
        value =this.Value as TeamMemberEquipmentManager ;
        return value != null ;
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
///     (TeamMemberPlayer value) =&gt; {...},
///     (TeamMemberCoach value) =&gt; {...},
///     (TeamMemberMedicalStaff value) =&gt; {...},
///     (TeamMemberEquipmentManager value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        Action<TeamMemberPlayer> player,
        Action<TeamMemberCoach> coach,
        Action<TeamMemberMedicalStaff> medicalStaff,
        Action<TeamMemberEquipmentManager> equipmentManager
    )
    {
        switch (this.Value)
        {
            case TeamMemberPlayer value:
                player(value);
                break;
            case TeamMemberCoach value:
                coach(value);
                break;
            case TeamMemberMedicalStaff value:
                medicalStaff(value);
                break;
            case TeamMemberEquipmentManager value:
                equipmentManager(value);
                break;
            default:
                throw new BelieveInvalidDataException("Data did not match any variant of TeamMemberUpdateResponse");

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
///     (TeamMemberPlayer value) =&gt; {...},
///     (TeamMemberCoach value) =&gt; {...},
///     (TeamMemberMedicalStaff value) =&gt; {...},
///     (TeamMemberEquipmentManager value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        Func<TeamMemberPlayer, T> player,
        Func<TeamMemberCoach, T> coach,
        Func<TeamMemberMedicalStaff, T> medicalStaff,
        Func<TeamMemberEquipmentManager, T> equipmentManager
    )
    {
        return this.Value switch
        {
            TeamMemberPlayer value=>player(value),
            TeamMemberCoach value=>coach(value),
            TeamMemberMedicalStaff value=>medicalStaff(value),
            TeamMemberEquipmentManager value=>equipmentManager(value),
            _ =>throw new BelieveInvalidDataException("Data did not match any variant of TeamMemberUpdateResponse")
        } ;
    }

    public static implicit operator TeamMemberUpdateResponse (
        TeamMemberPlayer value
    )=> new(value) ;

    public static implicit operator TeamMemberUpdateResponse (
        TeamMemberCoach value
    )=> new(value) ;

    public static implicit operator TeamMemberUpdateResponse (
        TeamMemberMedicalStaff value
    )=> new(value) ;

    public static implicit operator TeamMemberUpdateResponse (
        TeamMemberEquipmentManager value
    )=> new(value) ;

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
            throw new BelieveInvalidDataException("Data did not match any variant of TeamMemberUpdateResponse");
        }
        this.Switch((player) => player.Validate(),
        (coach) => coach.Validate(),
        (medicalStaff) => medicalStaff.Validate(),
        (equipmentManager) => equipmentManager.Validate());
    }

    public virtual bool Equals(TeamMemberUpdateResponse? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            TeamMemberPlayer _=>0,
            TeamMemberCoach _=>1,
            TeamMemberMedicalStaff _=>2,
            TeamMemberEquipmentManager _=>3,
            _ =>-1
        } ;
    }
}

sealed class TeamMemberUpdateResponseConverter : JsonConverter<TeamMemberUpdateResponse>
{
    public override TeamMemberUpdateResponse? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? memberType;
        try {
            memberType = element.GetProperty("member_type").GetString();
        } catch {
            memberType = null;
        }

        switch (memberType)
        {
            case "player":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TeamMemberPlayer>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "coach":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TeamMemberCoach>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "medical_staff":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TeamMemberMedicalStaff>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "equipment_manager":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TeamMemberEquipmentManager>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }default:
                { return new TeamMemberUpdateResponse(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        TeamMemberUpdateResponse value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}