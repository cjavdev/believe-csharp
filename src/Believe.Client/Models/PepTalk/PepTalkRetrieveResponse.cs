using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Client.Core;

namespace Believe.Client.Models.PepTalk;

/// <summary>
/// A complete pep talk response.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PepTalkRetrieveResponse, PepTalkRetrieveResponseFromRaw>))]
public sealed record class PepTalkRetrieveResponse : JsonModel
{
    /// <summary>
    /// Individual chunks of the pep talk
    /// </summary>
    public required IReadOnlyList<Chunk> Chunks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Chunk>>("chunks");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Chunk>>(
                "chunks",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The full pep talk text
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Chunks)
        {
            item.Validate();
        }
        _ = this.Text;
    }

    public PepTalkRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PepTalkRetrieveResponse(PepTalkRetrieveResponse pepTalkRetrieveResponse)
        : base(pepTalkRetrieveResponse) { }
#pragma warning restore CS8618

    public PepTalkRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PepTalkRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PepTalkRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static PepTalkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PepTalkRetrieveResponseFromRaw : IFromRawJson<PepTalkRetrieveResponse>
{
    /// <inheritdoc/>
    public PepTalkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PepTalkRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A chunk of a streaming pep talk from Ted.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Chunk, ChunkFromRaw>))]
public sealed record class Chunk : JsonModel
{
    /// <summary>
    /// Chunk sequence number
    /// </summary>
    public required long ChunkID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("chunk_id");
        }
        init { this._rawData.Set("chunk_id", value); }
    }

    /// <summary>
    /// Is this the final chunk
    /// </summary>
    public required bool IsFinal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_final");
        }
        init { this._rawData.Set("is_final", value); }
    }

    /// <summary>
    /// The text of this chunk
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// The emotional purpose of this chunk (e.g., greeting, acknowledgment, wisdom,
    /// affirmation, encouragement)
    /// </summary>
    public string? EmotionalBeat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("emotional_beat");
        }
        init { this._rawData.Set("emotional_beat", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChunkID;
        _ = this.IsFinal;
        _ = this.Text;
        _ = this.EmotionalBeat;
    }

    public Chunk() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Chunk(Chunk chunk)
        : base(chunk) { }
#pragma warning restore CS8618

    public Chunk(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Chunk(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChunkFromRaw.FromRawUnchecked"/>
    public static Chunk FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChunkFromRaw : IFromRawJson<Chunk>
{
    /// <inheritdoc/>
    public Chunk FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Chunk.FromRawUnchecked(rawData);
}
