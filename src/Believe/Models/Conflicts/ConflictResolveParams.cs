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

namespace Believe.Models.Conflicts;

/// <summary>
/// Get Ted Lasso-style advice for resolving conflicts.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConflictResolveParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Type of conflict
    /// </summary>
    public required ApiEnum<string, ConflictType> ConflictType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, ConflictType>>(
                "conflict_type"
            );
        }
        init { this._rawBodyData.Set("conflict_type", value); }
    }

    /// <summary>
    /// Describe the conflict
    /// </summary>
    public required string Description {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Who is involved in the conflict
    /// </summary>
    public required IReadOnlyList<string> PartiesInvolved {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>(
                "parties_involved"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "parties_involved",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// What you've already tried
    /// </summary>
    public IReadOnlyList<string>? AttemptsMade {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "attempts_made"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "attempts_made",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ConflictResolveParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConflictResolveParams (
        ConflictResolveParams conflictResolveParams
    ) : base(conflictResolveParams)
    { this._rawBodyData = new(conflictResolveParams._rawBodyData); }
    #pragma warning restore CS8618

    public ConflictResolveParams (
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
    ConflictResolveParams (
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
    public static ConflictResolveParams FromRawUnchecked(
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

    public virtual bool Equals(ConflictResolveParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/conflicts/resolve"
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
/// Type of conflict
/// </summary>
[JsonConverter(typeof(ConflictTypeConverter))]
public enum ConflictType
{
    Interpersonal, TeamDynamics, Leadership, Ego, Miscommunication, Competition
}

sealed class ConflictTypeConverter : JsonConverter<ConflictType>
{
    public override ConflictType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "interpersonal"=>ConflictType.Interpersonal,
            "team_dynamics"=>ConflictType.TeamDynamics,
            "leadership"=>ConflictType.Leadership,
            "ego"=>ConflictType.Ego,
            "miscommunication"=>ConflictType.Miscommunication,
            "competition"=>ConflictType.Competition,
            _ =>(ConflictType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ConflictType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConflictType.Interpersonal=>"interpersonal",
            ConflictType.TeamDynamics=>"team_dynamics",
            ConflictType.Leadership=>"leadership",
            ConflictType.Ego=>"ego",
            ConflictType.Miscommunication=>"miscommunication",
            ConflictType.Competition=>"competition",
            _ => throw new BelieveInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}