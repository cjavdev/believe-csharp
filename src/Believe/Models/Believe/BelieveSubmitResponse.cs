using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Believe;

/// <summary>
/// Response from the Believe Engine.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BelieveSubmitResponse, BelieveSubmitResponseFromRaw>))]
public sealed record class BelieveSubmitResponse : JsonModel
{
    /// <summary>
    /// Suggested action to take
    /// </summary>
    public required string ActionSuggestion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "action_suggestion"
            );
        }
        init { this._rawData.Set("action_suggestion", value); }
    }

    /// <summary>
    /// Your current believe-o-meter score
    /// </summary>
    public required long BelieveScore {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "believe_score"
            );
        }
        init { this._rawData.Set("believe_score", value); }
    }

    /// <summary>
    /// A reminder to have a goldfish memory when needed
    /// </summary>
    public required string GoldfishWisdom {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "goldfish_wisdom"
            );
        }
        init { this._rawData.Set("goldfish_wisdom", value); }
    }

    /// <summary>
    /// A relevant Ted Lasso quote
    /// </summary>
    public required string RelevantQuote {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "relevant_quote"
            );
        }
        init { this._rawData.Set("relevant_quote", value); }
    }

    /// <summary>
    /// Ted's motivational response
    /// </summary>
    public required string TedResponse {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "ted_response"
            );
        }
        init { this._rawData.Set("ted_response", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActionSuggestion;
        _ = this.BelieveScore;
        _ = this.GoldfishWisdom;
        _ = this.RelevantQuote;
        _ = this.TedResponse;
    }

    public BelieveSubmitResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BelieveSubmitResponse (
        BelieveSubmitResponse believeSubmitResponse
    ) : base(believeSubmitResponse)
    {  }
    #pragma warning restore CS8618

    public BelieveSubmitResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BelieveSubmitResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BelieveSubmitResponseFromRaw.FromRawUnchecked"/>
    public static BelieveSubmitResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BelieveSubmitResponseFromRaw : IFromRawJson<BelieveSubmitResponse>
{
    /// <inheritdoc/>
    public BelieveSubmitResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BelieveSubmitResponse.FromRawUnchecked(rawData);
}