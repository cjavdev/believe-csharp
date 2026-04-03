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

namespace Believe.Models.Characters;

/// <summary>
/// Update specific fields of an existing character.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CharacterUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CharacterID { get; init; }

    public string? Background {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "background"
            );
        }
        init { this._rawBodyData.Set("background", value); }
    }

    public string? DateOfBirth {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "date_of_birth"
            );
        }
        init { this._rawBodyData.Set("date_of_birth", value); }
    }

    public string? Email {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "email"
            );
        }
        init { this._rawBodyData.Set("email", value); }
    }

    /// <summary>
    /// Emotional intelligence statistics for a character.
    /// </summary>
    public EmotionalStats? EmotionalStats {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<EmotionalStats>(
                "emotional_stats"
            );
        }
        init { this._rawBodyData.Set("emotional_stats", value); }
    }

    public IReadOnlyList<GrowthArc>? GrowthArcs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<GrowthArc>>(
                "growth_arcs"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<GrowthArc>?>(
                "growth_arcs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public double? HeightMeters {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "height_meters"
            );
        }
        init { this._rawBodyData.Set("height_meters", value); }
    }

    public string? Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "name"
            );
        }
        init { this._rawBodyData.Set("name", value); }
    }

    public IReadOnlyList<string>? PersonalityTraits {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "personality_traits"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "personality_traits",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? ProfileImageUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "profile_image_url"
            );
        }
        init { this._rawBodyData.Set("profile_image_url", value); }
    }

    /// <summary>
    /// Roles characters can have.
    /// </summary>
    public ApiEnum<string, CharacterRole>? Role {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, CharacterRole>>(
                "role"
            );
        }
        init { this._rawBodyData.Set("role", value); }
    }

    public CharacterUpdateParamsSalaryGbp? SalaryGbp {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CharacterUpdateParamsSalaryGbp>(
                "salary_gbp"
            );
        }
        init { this._rawBodyData.Set("salary_gbp", value); }
    }

    public IReadOnlyList<string>? SignatureQuotes {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "signature_quotes"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "signature_quotes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? TeamID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "team_id"
            );
        }
        init { this._rawBodyData.Set("team_id", value); }
    }

    public CharacterUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CharacterUpdateParams (
        CharacterUpdateParams characterUpdateParams
    ) : base(characterUpdateParams)
    {
        this.CharacterID = characterUpdateParams.CharacterID;

        this._rawBodyData = new(characterUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public CharacterUpdateParams (
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
    CharacterUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string characterID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CharacterID = characterID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CharacterUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string characterID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            characterID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["CharacterID"] = JsonSerializer.SerializeToElement(this.CharacterID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(CharacterUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CharacterID?.Equals(other.CharacterID) ?? other.CharacterID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/characters/{0}",
            this.CharacterID)
        )
        {
            Query = this.QueryString(options)
        }.Uri ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
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

[JsonConverter(typeof(CharacterUpdateParamsSalaryGbpConverter))]
public record class CharacterUpdateParamsSalaryGbp : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public CharacterUpdateParamsSalaryGbp (
        double value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CharacterUpdateParamsSalaryGbp (
        string value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CharacterUpdateParamsSalaryGbp (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="double"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDouble(out var value)) {
///     // `value` is of type `double`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value =this.Value as double? ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
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
///     (double value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new BelieveInvalidDataException("Data did not match any variant of CharacterUpdateParamsSalaryGbp");

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
///     (double value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value=>@double(value),
            string value=>@string(value),
            _ =>throw new BelieveInvalidDataException("Data did not match any variant of CharacterUpdateParamsSalaryGbp")
        } ;
    }

    public static implicit operator CharacterUpdateParamsSalaryGbp (
        double value
    )=> new(value) ;

    public static implicit operator CharacterUpdateParamsSalaryGbp (
        string value
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
            throw new BelieveInvalidDataException("Data did not match any variant of CharacterUpdateParamsSalaryGbp");
        }
    }

    public virtual bool Equals(CharacterUpdateParamsSalaryGbp? other)
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
        { double _=>0, string _=>1, _ =>-1 } ;
    }
}

sealed class CharacterUpdateParamsSalaryGbpConverter : JsonConverter<CharacterUpdateParamsSalaryGbp?>
{
    public override CharacterUpdateParamsSalaryGbp? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e)when( e is JsonException || e is BelieveInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (Exception e)when( e is JsonException || e is BelieveInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CharacterUpdateParamsSalaryGbp? value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value?.Json, options); }
}