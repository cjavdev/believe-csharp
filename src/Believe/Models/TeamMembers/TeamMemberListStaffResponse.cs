using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;
using Believe.Exceptions;

namespace Believe.Models.TeamMembers;

/// <summary>
/// Full medical staff model with ID.
/// </summary>
[JsonConverter(typeof(TeamMemberListStaffResponseConverter))]
public record class TeamMemberListStaffResponse : ModelBase
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

    public string ID
    {
        get { return Match(medicalStaff: (x) => x.ID, equipmentManager: (x) => x.ID); }
    }

    public string CharacterID
    {
        get
        {
            return Match(
                medicalStaff: (x) => x.CharacterID,
                equipmentManager: (x) => x.CharacterID
            );
        }
    }

    public string TeamID
    {
        get { return Match(medicalStaff: (x) => x.TeamID, equipmentManager: (x) => x.TeamID); }
    }

    public long YearsWithTeam
    {
        get
        {
            return Match(
                medicalStaff: (x) => x.YearsWithTeam,
                equipmentManager: (x) => x.YearsWithTeam
            );
        }
    }

    public TeamMemberListStaffResponse(TeamMemberMedicalStaff value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TeamMemberListStaffResponse(
        TeamMemberEquipmentManager value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TeamMemberListStaffResponse(JsonElement element)
    {
        this._element = element;
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
    public bool TryPickMedicalStaff([NotNullWhen(true)] out TeamMemberMedicalStaff? value)
    {
        value = this.Value as TeamMemberMedicalStaff;
        return value != null;
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
    public bool TryPickEquipmentManager([NotNullWhen(true)] out TeamMemberEquipmentManager? value)
    {
        value = this.Value as TeamMemberEquipmentManager;
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
    ///     (TeamMemberMedicalStaff value) =&gt; {...},
    ///     (TeamMemberEquipmentManager value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<TeamMemberMedicalStaff> medicalStaff,
        Action<TeamMemberEquipmentManager> equipmentManager
    )
    {
        switch (this.Value)
        {
            case TeamMemberMedicalStaff value:
                medicalStaff(value);
                break;
            case TeamMemberEquipmentManager value:
                equipmentManager(value);
                break;
            default:
                throw new BelieveInvalidDataException(
                    "Data did not match any variant of TeamMemberListStaffResponse"
                );
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
    ///     (TeamMemberMedicalStaff value) =&gt; {...},
    ///     (TeamMemberEquipmentManager value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<TeamMemberMedicalStaff, T> medicalStaff,
        Func<TeamMemberEquipmentManager, T> equipmentManager
    )
    {
        return this.Value switch
        {
            TeamMemberMedicalStaff value => medicalStaff(value),
            TeamMemberEquipmentManager value => equipmentManager(value),
            _ => throw new BelieveInvalidDataException(
                "Data did not match any variant of TeamMemberListStaffResponse"
            ),
        };
    }

    public static implicit operator TeamMemberListStaffResponse(TeamMemberMedicalStaff value) =>
        new(value);

    public static implicit operator TeamMemberListStaffResponse(TeamMemberEquipmentManager value) =>
        new(value);

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
            throw new BelieveInvalidDataException(
                "Data did not match any variant of TeamMemberListStaffResponse"
            );
        }
        this.Switch(
            (medicalStaff) => medicalStaff.Validate(),
            (equipmentManager) => equipmentManager.Validate()
        );
    }

    public virtual bool Equals(TeamMemberListStaffResponse? other) =>
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
            TeamMemberMedicalStaff _ => 0,
            TeamMemberEquipmentManager _ => 1,
            _ => -1,
        };
    }
}

sealed class TeamMemberListStaffResponseConverter : JsonConverter<TeamMemberListStaffResponse>
{
    public override TeamMemberListStaffResponse? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<TeamMemberMedicalStaff>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<TeamMemberEquipmentManager>(
                element,
                options
            );
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

    public override void Write(
        Utf8JsonWriter writer,
        TeamMemberListStaffResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
