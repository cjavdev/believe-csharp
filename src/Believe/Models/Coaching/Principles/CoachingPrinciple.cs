using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Coaching.Principles;

/// <summary>
/// A Ted Lasso coaching principle.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CoachingPrinciple, CoachingPrincipleFromRaw>))]
public sealed record class CoachingPrinciple : JsonModel
{
    /// <summary>
    /// Principle identifier
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// How to apply this principle
    /// </summary>
    public required string Application
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("application");
        }
        init { this._rawData.Set("application", value); }
    }

    /// <summary>
    /// Example from the show
    /// </summary>
    public required string ExampleFromShow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("example_from_show");
        }
        init { this._rawData.Set("example_from_show", value); }
    }

    /// <summary>
    /// What this principle means
    /// </summary>
    public required string Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
    }

    /// <summary>
    /// The coaching principle
    /// </summary>
    public required string Principle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("principle");
        }
        init { this._rawData.Set("principle", value); }
    }

    /// <summary>
    /// Related Ted quote
    /// </summary>
    public required string TedQuote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ted_quote");
        }
        init { this._rawData.Set("ted_quote", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Application;
        _ = this.ExampleFromShow;
        _ = this.Explanation;
        _ = this.Principle;
        _ = this.TedQuote;
    }

    public CoachingPrinciple() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CoachingPrinciple(CoachingPrinciple coachingPrinciple)
        : base(coachingPrinciple) { }
#pragma warning restore CS8618

    public CoachingPrinciple(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CoachingPrinciple(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CoachingPrincipleFromRaw.FromRawUnchecked"/>
    public static CoachingPrinciple FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CoachingPrincipleFromRaw : IFromRawJson<CoachingPrinciple>
{
    /// <inheritdoc/>
    public CoachingPrinciple FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CoachingPrinciple.FromRawUnchecked(rawData);
}
