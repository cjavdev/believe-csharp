using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Press;

/// <summary>
/// Ted's press conference response.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PressSimulateResponse, PressSimulateResponseFromRaw>))]
public sealed record class PressSimulateResponse : JsonModel
{
    /// <summary>
    /// The actual wisdom beneath the humor
    /// </summary>
    public required string ActualWisdom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("actual_wisdom");
        }
        init { this._rawData.Set("actual_wisdom", value); }
    }

    /// <summary>
    /// How Ted would dodge a follow-up
    /// </summary>
    public required string FollowUpDodge
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("follow_up_dodge");
        }
        init { this._rawData.Set("follow_up_dodge", value); }
    }

    /// <summary>
    /// How reporters would react
    /// </summary>
    public required string ReporterReaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reporter_reaction");
        }
        init { this._rawData.Set("reporter_reaction", value); }
    }

    /// <summary>
    /// Ted's press conference answer
    /// </summary>
    public required string Response
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("response");
        }
        init { this._rawData.Set("response", value); }
    }

    /// <summary>
    /// Humorous deflection if appropriate
    /// </summary>
    public string? DeflectionHumor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("deflection_humor");
        }
        init { this._rawData.Set("deflection_humor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActualWisdom;
        _ = this.FollowUpDodge;
        _ = this.ReporterReaction;
        _ = this.Response;
        _ = this.DeflectionHumor;
    }

    public PressSimulateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PressSimulateResponse(PressSimulateResponse pressSimulateResponse)
        : base(pressSimulateResponse) { }
#pragma warning restore CS8618

    public PressSimulateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PressSimulateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PressSimulateResponseFromRaw.FromRawUnchecked"/>
    public static PressSimulateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PressSimulateResponseFromRaw : IFromRawJson<PressSimulateResponse>
{
    /// <inheritdoc/>
    public PressSimulateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PressSimulateResponse.FromRawUnchecked(rawData);
}
