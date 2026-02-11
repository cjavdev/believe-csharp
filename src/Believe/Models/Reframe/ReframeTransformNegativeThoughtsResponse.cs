using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Reframe;

/// <summary>
/// Reframed perspective response.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ReframeTransformNegativeThoughtsResponse,
        ReframeTransformNegativeThoughtsResponseFromRaw
    >)
)]
public sealed record class ReframeTransformNegativeThoughtsResponse : JsonModel
{
    /// <summary>
    /// A daily affirmation to practice
    /// </summary>
    public required string DailyAffirmation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("daily_affirmation");
        }
        init { this._rawData.Set("daily_affirmation", value); }
    }

    /// <summary>
    /// The original negative thought
    /// </summary>
    public required string OriginalThought
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("original_thought");
        }
        init { this._rawData.Set("original_thought", value); }
    }

    /// <summary>
    /// The thought reframed positively
    /// </summary>
    public required string ReframedThought
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reframed_thought");
        }
        init { this._rawData.Set("reframed_thought", value); }
    }

    /// <summary>
    /// Ted's take on this thought
    /// </summary>
    public required string TedPerspective
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ted_perspective");
        }
        init { this._rawData.Set("ted_perspective", value); }
    }

    /// <summary>
    /// Dr. Sharon's therapeutic insight
    /// </summary>
    public string? DrSharonInsight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dr_sharon_insight");
        }
        init { this._rawData.Set("dr_sharon_insight", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DailyAffirmation;
        _ = this.OriginalThought;
        _ = this.ReframedThought;
        _ = this.TedPerspective;
        _ = this.DrSharonInsight;
    }

    public ReframeTransformNegativeThoughtsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReframeTransformNegativeThoughtsResponse(
        ReframeTransformNegativeThoughtsResponse reframeTransformNegativeThoughtsResponse
    )
        : base(reframeTransformNegativeThoughtsResponse) { }
#pragma warning restore CS8618

    public ReframeTransformNegativeThoughtsResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReframeTransformNegativeThoughtsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReframeTransformNegativeThoughtsResponseFromRaw.FromRawUnchecked"/>
    public static ReframeTransformNegativeThoughtsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReframeTransformNegativeThoughtsResponseFromRaw
    : IFromRawJson<ReframeTransformNegativeThoughtsResponse>
{
    /// <inheritdoc/>
    public ReframeTransformNegativeThoughtsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ReframeTransformNegativeThoughtsResponse.FromRawUnchecked(rawData);
}
