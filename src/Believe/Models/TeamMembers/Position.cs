using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Exceptions;

namespace Believe.Models.TeamMembers;

/// <summary>
/// Football positions for players.
/// </summary>
[JsonConverter(typeof(PositionConverter))]
public enum Position
{
    Goalkeeper,
    Defender,
    Midfielder,
    Forward,
}

sealed class PositionConverter : JsonConverter<Position>
{
    public override Position Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "goalkeeper" => Position.Goalkeeper,
            "defender" => Position.Defender,
            "midfielder" => Position.Midfielder,
            "forward" => Position.Forward,
            _ => (Position)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Position value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Position.Goalkeeper => "goalkeeper",
                Position.Defender => "defender",
                Position.Midfielder => "midfielder",
                Position.Forward => "forward",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
