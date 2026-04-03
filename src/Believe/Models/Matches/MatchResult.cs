using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Exceptions;

namespace Believe.Models.Matches;

/// <summary>
/// Match result types.
/// </summary>
[JsonConverter(typeof(MatchResultConverter))]
public enum MatchResult
{
    Win, Loss, Draw, Pending
}

sealed class MatchResultConverter : JsonConverter<MatchResult>
{
    public override MatchResult Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "win"=>MatchResult.Win,
            "loss"=>MatchResult.Loss,
            "draw"=>MatchResult.Draw,
            "pending"=>MatchResult.Pending,
            _ =>(MatchResult)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, MatchResult value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MatchResult.Win=>"win",
            MatchResult.Loss=>"loss",
            MatchResult.Draw=>"draw",
            MatchResult.Pending=>"pending",
            _ => throw new BelieveInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}