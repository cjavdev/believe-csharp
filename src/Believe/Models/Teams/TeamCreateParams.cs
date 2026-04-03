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

namespace Believe.Models.Teams;

/// <summary>
/// Add a new team to the league.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TeamCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Team culture/morale score (0-100)
    /// </summary>
    public required long CultureScore {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>(
                "culture_score"
            );
        }
        init { this._rawBodyData.Set("culture_score", value); }
    }

    /// <summary>
    /// Year the club was founded
    /// </summary>
    public required long FoundedYear {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>(
                "founded_year"
            );
        }
        init { this._rawBodyData.Set("founded_year", value); }
    }

    /// <summary>
    /// Current league
    /// </summary>
    public required ApiEnum<string, League> League {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, League>>(
                "league"
            );
        }
        init { this._rawBodyData.Set("league", value); }
    }

    /// <summary>
    /// Team name
    /// </summary>
    public required string Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Home stadium name
    /// </summary>
    public required string Stadium {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "stadium"
            );
        }
        init { this._rawBodyData.Set("stadium", value); }
    }

    /// <summary>
    /// Team's core values
    /// </summary>
    public required TeamValues Values {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<TeamValues>(
                "values"
            );
        }
        init { this._rawBodyData.Set("values", value); }
    }

    /// <summary>
    /// Annual budget in GBP
    /// </summary>
    public AnnualBudgetGbp? AnnualBudgetGbp {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<AnnualBudgetGbp>(
                "annual_budget_gbp"
            );
        }
        init { this._rawBodyData.Set("annual_budget_gbp", value); }
    }

    /// <summary>
    /// Average match attendance
    /// </summary>
    public double? AverageAttendance {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "average_attendance"
            );
        }
        init { this._rawBodyData.Set("average_attendance", value); }
    }

    /// <summary>
    /// Team contact email
    /// </summary>
    public string? ContactEmail {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "contact_email"
            );
        }
        init { this._rawBodyData.Set("contact_email", value); }
    }

    /// <summary>
    /// Whether the team is currently active
    /// </summary>
    public bool? IsActive {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "is_active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("is_active", value);
        }
    }

    /// <summary>
    /// Team nickname
    /// </summary>
    public string? Nickname {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "nickname"
            );
        }
        init { this._rawBodyData.Set("nickname", value); }
    }

    /// <summary>
    /// Primary team color (hex)
    /// </summary>
    public string? PrimaryColor {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "primary_color"
            );
        }
        init { this._rawBodyData.Set("primary_color", value); }
    }

    /// <summary>
    /// List of rival team IDs
    /// </summary>
    public IReadOnlyList<string>? RivalTeams {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "rival_teams"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "rival_teams",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Secondary team color (hex)
    /// </summary>
    public string? SecondaryColor {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "secondary_color"
            );
        }
        init { this._rawBodyData.Set("secondary_color", value); }
    }

    /// <summary>
    /// Geographic coordinates for a location.
    /// </summary>
    public GeoLocation? StadiumLocation {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<GeoLocation>(
                "stadium_location"
            );
        }
        init { this._rawBodyData.Set("stadium_location", value); }
    }

    /// <summary>
    /// Official team website
    /// </summary>
    public string? Website {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "website"
            );
        }
        init { this._rawBodyData.Set("website", value); }
    }

    /// <summary>
    /// Season win percentage
    /// </summary>
    public double? WinPercentage {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<double>(
                "win_percentage"
            );
        }
        init { this._rawBodyData.Set("win_percentage", value); }
    }

    public TeamCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TeamCreateParams (TeamCreateParams teamCreateParams) : base(
        teamCreateParams
    )
    { this._rawBodyData = new(teamCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public TeamCreateParams (
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
    TeamCreateParams (
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
    public static TeamCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(TeamCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/teams"
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

/// <summary>
/// Annual budget in GBP
/// </summary>
[JsonConverter(typeof(AnnualBudgetGbpConverter))]
public record class AnnualBudgetGbp : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public AnnualBudgetGbp (double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AnnualBudgetGbp (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AnnualBudgetGbp (JsonElement element)
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
                throw new BelieveInvalidDataException("Data did not match any variant of AnnualBudgetGbp");

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
            _ =>throw new BelieveInvalidDataException("Data did not match any variant of AnnualBudgetGbp")
        } ;
    }

    public static implicit operator AnnualBudgetGbp (
        double value
    )=> new(value) ;

    public static implicit operator AnnualBudgetGbp (
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
            throw new BelieveInvalidDataException("Data did not match any variant of AnnualBudgetGbp");
        }
    }

    public virtual bool Equals(AnnualBudgetGbp? other)
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

sealed class AnnualBudgetGbpConverter : JsonConverter<AnnualBudgetGbp?>
{
    public override AnnualBudgetGbp? Read(
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
        AnnualBudgetGbp? value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value?.Json, options); }
}