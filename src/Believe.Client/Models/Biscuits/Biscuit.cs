using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Client.Core;
using Believe.Client.Exceptions;
using System = System;

namespace Believe.Client.Models.Biscuits;

/// <summary>
/// A biscuit from Ted.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Biscuit, BiscuitFromRaw>))]
public sealed record class Biscuit : JsonModel
{
    /// <summary>
    /// Biscuit identifier
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
    /// Message that comes with the biscuit
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// What this biscuit pairs well with
    /// </summary>
    public required string PairsWellWith
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("pairs_well_with");
        }
        init { this._rawData.Set("pairs_well_with", value); }
    }

    /// <summary>
    /// A handwritten note from Ted
    /// </summary>
    public required string TedNote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ted_note");
        }
        init { this._rawData.Set("ted_note", value); }
    }

    /// <summary>
    /// Type of biscuit
    /// </summary>
    public required ApiEnum<string, global::Believe.Client.Models.Biscuits.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Believe.Client.Models.Biscuits.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// How warm and fresh (1-10)
    /// </summary>
    public required long WarmthLevel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("warmth_level");
        }
        init { this._rawData.Set("warmth_level", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Message;
        _ = this.PairsWellWith;
        _ = this.TedNote;
        this.Type.Validate();
        _ = this.WarmthLevel;
    }

    public Biscuit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Biscuit(Biscuit biscuit)
        : base(biscuit) { }
#pragma warning restore CS8618

    public Biscuit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Biscuit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BiscuitFromRaw.FromRawUnchecked"/>
    public static Biscuit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BiscuitFromRaw : IFromRawJson<Biscuit>
{
    /// <inheritdoc/>
    public Biscuit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Biscuit.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of biscuit
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Classic,
    Shortbread,
    ChocolateChip,
    OatmealRaisin,
    Snickerdoodle,
    LemonDrizzle,
}

sealed class TypeConverter : JsonConverter<global::Believe.Client.Models.Biscuits.Type>
{
    public override global::Believe.Client.Models.Biscuits.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "classic" => global::Believe.Client.Models.Biscuits.Type.Classic,
            "shortbread" => global::Believe.Client.Models.Biscuits.Type.Shortbread,
            "chocolate_chip" => global::Believe.Client.Models.Biscuits.Type.ChocolateChip,
            "oatmeal_raisin" => global::Believe.Client.Models.Biscuits.Type.OatmealRaisin,
            "snickerdoodle" => global::Believe.Client.Models.Biscuits.Type.Snickerdoodle,
            "lemon_drizzle" => global::Believe.Client.Models.Biscuits.Type.LemonDrizzle,
            _ => (global::Believe.Client.Models.Biscuits.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Believe.Client.Models.Biscuits.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Believe.Client.Models.Biscuits.Type.Classic => "classic",
                global::Believe.Client.Models.Biscuits.Type.Shortbread => "shortbread",
                global::Believe.Client.Models.Biscuits.Type.ChocolateChip => "chocolate_chip",
                global::Believe.Client.Models.Biscuits.Type.OatmealRaisin => "oatmeal_raisin",
                global::Believe.Client.Models.Biscuits.Type.Snickerdoodle => "snickerdoodle",
                global::Believe.Client.Models.Biscuits.Type.LemonDrizzle => "lemon_drizzle",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
