using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;
using Believe.Exceptions;

namespace Believe.Models.Believe;

/// <summary>
/// Submit your situation and receive Ted Lasso-style motivational guidance.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BelieveSubmitParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Describe your situation
    /// </summary>
    public required string Situation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("situation");
        }
        init { this._rawBodyData.Set("situation", value); }
    }

    /// <summary>
    /// Type of situation
    /// </summary>
    public required ApiEnum<string, SituationType> SituationType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, SituationType>>(
                "situation_type"
            );
        }
        init { this._rawBodyData.Set("situation_type", value); }
    }

    /// <summary>
    /// Additional context
    /// </summary>
    public string? Context
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("context");
        }
        init { this._rawBodyData.Set("context", value); }
    }

    /// <summary>
    /// How intense is the response needed (1=gentle, 10=full Ted)
    /// </summary>
    public long? Intensity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("intensity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("intensity", value);
        }
    }

    public BelieveSubmitParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BelieveSubmitParams(BelieveSubmitParams believeSubmitParams)
        : base(believeSubmitParams)
    {
        this._rawBodyData = new(believeSubmitParams._rawBodyData);
    }
#pragma warning restore CS8618

    public BelieveSubmitParams(
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
    BelieveSubmitParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static BelieveSubmitParams FromRawUnchecked(
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
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(BelieveSubmitParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/believe")
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
/// Type of situation
/// </summary>
[JsonConverter(typeof(SituationTypeConverter))]
public enum SituationType
{
    WorkChallenge,
    PersonalSetback,
    TeamConflict,
    SelfDoubt,
    BigDecision,
    Failure,
    NewBeginning,
    Relationship,
}

sealed class SituationTypeConverter : JsonConverter<SituationType>
{
    public override SituationType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "work_challenge" => SituationType.WorkChallenge,
            "personal_setback" => SituationType.PersonalSetback,
            "team_conflict" => SituationType.TeamConflict,
            "self_doubt" => SituationType.SelfDoubt,
            "big_decision" => SituationType.BigDecision,
            "failure" => SituationType.Failure,
            "new_beginning" => SituationType.NewBeginning,
            "relationship" => SituationType.Relationship,
            _ => (SituationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SituationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SituationType.WorkChallenge => "work_challenge",
                SituationType.PersonalSetback => "personal_setback",
                SituationType.TeamConflict => "team_conflict",
                SituationType.SelfDoubt => "self_doubt",
                SituationType.BigDecision => "big_decision",
                SituationType.Failure => "failure",
                SituationType.NewBeginning => "new_beginning",
                SituationType.Relationship => "relationship",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
