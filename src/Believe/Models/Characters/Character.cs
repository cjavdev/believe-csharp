using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Characters;

/// <summary>
/// Full character model with ID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Character, CharacterFromRaw>))]
public sealed record class Character : JsonModel
{
    /// <summary>
    /// Unique identifier
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
    /// Character background and history
    /// </summary>
    public required string Background {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "background"
            );
        }
        init { this._rawData.Set("background", value); }
    }

    /// <summary>
    /// Emotional intelligence stats
    /// </summary>
    public required EmotionalStats EmotionalStats {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmotionalStats>(
                "emotional_stats"
            );
        }
        init { this._rawData.Set("emotional_stats", value); }
    }

    /// <summary>
    /// Character's full name
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Key personality traits
    /// </summary>
    public required IReadOnlyList<string> PersonalityTraits {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "personality_traits"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "personality_traits",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Character's role
    /// </summary>
    public required ApiEnum<string, CharacterRole> Role {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CharacterRole>>(
                "role"
            );
        }
        init { this._rawData.Set("role", value); }
    }

    /// <summary>
    /// Character's date of birth
    /// </summary>
    public string? DateOfBirth {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "date_of_birth"
            );
        }
        init { this._rawData.Set("date_of_birth", value); }
    }

    /// <summary>
    /// Character's email address
    /// </summary>
    public string? Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Character development across seasons
    /// </summary>
    public IReadOnlyList<GrowthArc>? GrowthArcs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<GrowthArc>>(
                "growth_arcs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<GrowthArc>?>(
                "growth_arcs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Height in meters
    /// </summary>
    public double? HeightMeters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "height_meters"
            );
        }
        init { this._rawData.Set("height_meters", value); }
    }

    /// <summary>
    /// URL to character's profile image
    /// </summary>
    public string? ProfileImageUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "profile_image_url"
            );
        }
        init { this._rawData.Set("profile_image_url", value); }
    }

    /// <summary>
    /// Annual salary in GBP
    /// </summary>
    public string? SalaryGbp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "salary_gbp"
            );
        }
        init { this._rawData.Set("salary_gbp", value); }
    }

    /// <summary>
    /// Memorable quotes from this character
    /// </summary>
    public IReadOnlyList<string>? SignatureQuotes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "signature_quotes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "signature_quotes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ID of the team they belong to
    /// </summary>
    public string? TeamID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "team_id"
            );
        }
        init { this._rawData.Set("team_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Background;
        this.EmotionalStats.Validate();
        _ = this.Name;
        _ = this.PersonalityTraits;
        this.Role.Validate();
        _ = this.DateOfBirth;
        _ = this.Email;
        foreach (var item in this.GrowthArcs ?? [])
        {
            item.Validate();
        }
        _ = this.HeightMeters;
        _ = this.ProfileImageUrl;
        _ = this.SalaryGbp;
        _ = this.SignatureQuotes;
        _ = this.TeamID;
    }

    public Character ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Character (Character character) : base(character)
    {  }
    #pragma warning restore CS8618

    public Character (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Character (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CharacterFromRaw.FromRawUnchecked"/>
    public static Character FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CharacterFromRaw : IFromRawJson<Character>
{
    /// <inheritdoc/>
    public Character FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Character.FromRawUnchecked(rawData);
}