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
/// Add a new team member to a team.
///
/// <para>The request body is a **union type (oneOf)** - you must include the `member_type`
/// discriminator field: - `"member_type": "player"` - Creates a player (requires
/// position, jersey_number, etc.) - `"member_type": "coach"` - Creates a coach (requires
/// specialty, etc.) - `"member_type": "medical_staff"` - Creates medical staff (requires
/// medical specialty, etc.) - `"member_type": "equipment_manager"` - Creates equipment
/// manager (requires responsibilities, etc.)</para>
///
/// <para>The `character_id` field references an existing character from `/characters/{id}`.</para>
///
/// <para>**Example for creating a player:** ```json {   "member_type": "player",
///   "character_id": "sam-obisanya",   "team_id": "afc-richmond",   "years_with_team":
/// 2,   "position": "midfielder",   "jersey_number": 24,   "goals_scored": 12,
/// "assists": 15 } ```</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TeamMemberCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// A football player on the team.
    /// </summary>
    public required Member Member
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Member>("member");
        }
        init { this._rawBodyData.Set("member", value); }
    }

    public TeamMemberCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamMemberCreateParams(TeamMemberCreateParams teamMemberCreateParams)
        : base(teamMemberCreateParams)
    {
        this._rawBodyData = new(teamMemberCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TeamMemberCreateParams(
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
    TeamMemberCreateParams(
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
    public static TeamMemberCreateParams FromRawUnchecked(
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

    public virtual bool Equals(TeamMemberCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/team-members")
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
/// A football player on the team.
/// </summary>
[JsonConverter(typeof(MemberConverter))]
public record class Member : ModelBase
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

    public string CharacterID
    {
        get
        {
            return Match(
                player: (x) => x.CharacterID,
                coach: (x) => x.CharacterID,
                medicalStaff: (x) => x.CharacterID,
                equipmentManager: (x) => x.CharacterID
            );
        }
    }

    public string TeamID
    {
        get
        {
            return Match(
                player: (x) => x.TeamID,
                coach: (x) => x.TeamID,
                medicalStaff: (x) => x.TeamID,
                equipmentManager: (x) => x.TeamID
            );
        }
    }

    public long YearsWithTeam
    {
        get
        {
            return Match(
                player: (x) => x.YearsWithTeam,
                coach: (x) => x.YearsWithTeam,
                medicalStaff: (x) => x.YearsWithTeam,
                equipmentManager: (x) => x.YearsWithTeam
            );
        }
    }

    public Member(Player value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Member(Coach value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Member(MedicalStaff value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Member(EquipmentManager value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Member(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Player"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPlayer(out var value)) {
    ///     // `value` is of type `Player`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPlayer([NotNullWhen(true)] out Player? value)
    {
        value = this.Value as Player;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Coach"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCoach(out var value)) {
    ///     // `value` is of type `Coach`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCoach([NotNullWhen(true)] out Coach? value)
    {
        value = this.Value as Coach;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MedicalStaff"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMedicalStaff(out var value)) {
    ///     // `value` is of type `MedicalStaff`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMedicalStaff([NotNullWhen(true)] out MedicalStaff? value)
    {
        value = this.Value as MedicalStaff;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EquipmentManager"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEquipmentManager(out var value)) {
    ///     // `value` is of type `EquipmentManager`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEquipmentManager([NotNullWhen(true)] out EquipmentManager? value)
    {
        value = this.Value as EquipmentManager;
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
    ///     (Player value) =&gt; {...},
    ///     (Coach value) =&gt; {...},
    ///     (MedicalStaff value) =&gt; {...},
    ///     (EquipmentManager value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Player> player,
        Action<Coach> coach,
        Action<MedicalStaff> medicalStaff,
        Action<EquipmentManager> equipmentManager
    )
    {
        switch (this.Value)
        {
            case Player value:
                player(value);
                break;
            case Coach value:
                coach(value);
                break;
            case MedicalStaff value:
                medicalStaff(value);
                break;
            case EquipmentManager value:
                equipmentManager(value);
                break;
            default:
                throw new BelieveInvalidDataException("Data did not match any variant of Member");
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
    ///     (Player value) =&gt; {...},
    ///     (Coach value) =&gt; {...},
    ///     (MedicalStaff value) =&gt; {...},
    ///     (EquipmentManager value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Player, T> player,
        Func<Coach, T> coach,
        Func<MedicalStaff, T> medicalStaff,
        Func<EquipmentManager, T> equipmentManager
    )
    {
        return this.Value switch
        {
            Player value => player(value),
            Coach value => coach(value),
            MedicalStaff value => medicalStaff(value),
            EquipmentManager value => equipmentManager(value),
            _ => throw new BelieveInvalidDataException("Data did not match any variant of Member"),
        };
    }

    public static implicit operator Member(Player value) => new(value);

    public static implicit operator Member(Coach value) => new(value);

    public static implicit operator Member(MedicalStaff value) => new(value);

    public static implicit operator Member(EquipmentManager value) => new(value);

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
            throw new BelieveInvalidDataException("Data did not match any variant of Member");
        }
        this.Switch(
            (player) => player.Validate(),
            (coach) => coach.Validate(),
            (medicalStaff) => medicalStaff.Validate(),
            (equipmentManager) => equipmentManager.Validate()
        );
    }

    public virtual bool Equals(Member? other) =>
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
            Player _ => 0,
            Coach _ => 1,
            MedicalStaff _ => 2,
            EquipmentManager _ => 3,
            _ => -1,
        };
    }
}

sealed class MemberConverter : JsonConverter<Member>
{
    public override Member? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? memberType;
        try
        {
            memberType = element.GetProperty("member_type").GetString();
        }
        catch
        {
            memberType = null;
        }

        switch (memberType)
        {
            case "player":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Player>(element, options);
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
            case "coach":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Coach>(element, options);
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
            case "medical_staff":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MedicalStaff>(element, options);
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
            case "equipment_manager":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<EquipmentManager>(
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
            default:
            {
                return new Member(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Member value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// A football player on the team.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Player, PlayerFromRaw>))]
public sealed record class Player : JsonModel
{
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
    /// Jersey/shirt number
    /// </summary>
    public required long JerseyNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("jersey_number");
        }
        init { this._rawData.Set("jersey_number", value); }
    }

    /// <summary>
    /// Playing position on the field
    /// </summary>
    public required ApiEnum<string, Position> Position
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Position>>("position");
        }
        init { this._rawData.Set("position", value); }
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
    /// Total assists for the team
    /// </summary>
    public long? Assists
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("assists");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("assists", value);
        }
    }

    /// <summary>
    /// Total goals scored for the team
    /// </summary>
    public long? GoalsScored
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("goals_scored");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("goals_scored", value);
        }
    }

    /// <summary>
    /// Whether this player is team captain
    /// </summary>
    public bool? IsCaptain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_captain");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_captain", value);
        }
    }

    /// <summary>
    /// Discriminator field indicating this is a player
    /// </summary>
    public ApiEnum<string, MemberType>? MemberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MemberType>>("member_type");
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

    /// <inheritdoc/>
    public override void Validate()
    {
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

    public Player() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Player(Player player)
        : base(player) { }
#pragma warning restore CS8618

    public Player(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Player(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlayerFromRaw.FromRawUnchecked"/>
    public static Player FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlayerFromRaw : IFromRawJson<Player>
{
    /// <inheritdoc/>
    public Player FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Player.FromRawUnchecked(rawData);
}

/// <summary>
/// Discriminator field indicating this is a player
/// </summary>
[JsonConverter(typeof(MemberTypeConverter))]
public enum MemberType
{
    Player,
}

sealed class MemberTypeConverter : JsonConverter<MemberType>
{
    public override MemberType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "player" => MemberType.Player,
            _ => (MemberType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MemberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MemberType.Player => "player",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A coach or coaching staff member.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Coach, CoachFromRaw>))]
public sealed record class Coach : JsonModel
{
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
    public ApiEnum<string, CoachMemberType>? MemberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CoachMemberType>>("member_type");
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
        _ = this.CharacterID;
        this.Specialty.Validate();
        _ = this.TeamID;
        _ = this.YearsWithTeam;
        _ = this.Certifications;
        this.MemberType?.Validate();
        _ = this.WinRate;
    }

    public Coach() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Coach(Coach coach)
        : base(coach) { }
#pragma warning restore CS8618

    public Coach(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Coach(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CoachFromRaw.FromRawUnchecked"/>
    public static Coach FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CoachFromRaw : IFromRawJson<Coach>
{
    /// <inheritdoc/>
    public Coach FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Coach.FromRawUnchecked(rawData);
}

/// <summary>
/// Discriminator field indicating this is a coach
/// </summary>
[JsonConverter(typeof(CoachMemberTypeConverter))]
public enum CoachMemberType
{
    Coach,
}

sealed class CoachMemberTypeConverter : JsonConverter<CoachMemberType>
{
    public override CoachMemberType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "coach" => CoachMemberType.Coach,
            _ => (CoachMemberType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CoachMemberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CoachMemberType.Coach => "coach",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Medical and wellness staff member.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MedicalStaff, MedicalStaffFromRaw>))]
public sealed record class MedicalStaff : JsonModel
{
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
    public ApiEnum<string, MedicalStaffMemberType>? MemberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MedicalStaffMemberType>>(
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
        _ = this.CharacterID;
        this.Specialty.Validate();
        _ = this.TeamID;
        _ = this.YearsWithTeam;
        _ = this.LicenseNumber;
        this.MemberType?.Validate();
        _ = this.Qualifications;
    }

    public MedicalStaff() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MedicalStaff(MedicalStaff medicalStaff)
        : base(medicalStaff) { }
#pragma warning restore CS8618

    public MedicalStaff(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MedicalStaff(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MedicalStaffFromRaw.FromRawUnchecked"/>
    public static MedicalStaff FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MedicalStaffFromRaw : IFromRawJson<MedicalStaff>
{
    /// <inheritdoc/>
    public MedicalStaff FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MedicalStaff.FromRawUnchecked(rawData);
}

/// <summary>
/// Discriminator field indicating this is medical staff
/// </summary>
[JsonConverter(typeof(MedicalStaffMemberTypeConverter))]
public enum MedicalStaffMemberType
{
    MedicalStaff,
}

sealed class MedicalStaffMemberTypeConverter : JsonConverter<MedicalStaffMemberType>
{
    public override MedicalStaffMemberType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "medical_staff" => MedicalStaffMemberType.MedicalStaff,
            _ => (MedicalStaffMemberType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MedicalStaffMemberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MedicalStaffMemberType.MedicalStaff => "medical_staff",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Equipment and kit management staff.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EquipmentManager, EquipmentManagerFromRaw>))]
public sealed record class EquipmentManager : JsonModel
{
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
    /// Whether this is the head equipment manager
    /// </summary>
    public bool? IsHeadKitman
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_head_kitman");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_head_kitman", value);
        }
    }

    /// <summary>
    /// Discriminator field indicating this is an equipment manager
    /// </summary>
    public ApiEnum<string, EquipmentManagerMemberType>? MemberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EquipmentManagerMemberType>>(
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
    /// List of responsibilities
    /// </summary>
    public IReadOnlyList<string>? Responsibilities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("responsibilities");
        }
        init
        {
            if (value == null)
            {
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
        _ = this.CharacterID;
        _ = this.TeamID;
        _ = this.YearsWithTeam;
        _ = this.IsHeadKitman;
        this.MemberType?.Validate();
        _ = this.Responsibilities;
    }

    public EquipmentManager() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EquipmentManager(EquipmentManager equipmentManager)
        : base(equipmentManager) { }
#pragma warning restore CS8618

    public EquipmentManager(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EquipmentManager(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EquipmentManagerFromRaw.FromRawUnchecked"/>
    public static EquipmentManager FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EquipmentManagerFromRaw : IFromRawJson<EquipmentManager>
{
    /// <inheritdoc/>
    public EquipmentManager FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EquipmentManager.FromRawUnchecked(rawData);
}

/// <summary>
/// Discriminator field indicating this is an equipment manager
/// </summary>
[JsonConverter(typeof(EquipmentManagerMemberTypeConverter))]
public enum EquipmentManagerMemberType
{
    EquipmentManager,
}

sealed class EquipmentManagerMemberTypeConverter : JsonConverter<EquipmentManagerMemberType>
{
    public override EquipmentManagerMemberType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "equipment_manager" => EquipmentManagerMemberType.EquipmentManager,
            _ => (EquipmentManagerMemberType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EquipmentManagerMemberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EquipmentManagerMemberType.EquipmentManager => "equipment_manager",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
