using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Client.Exceptions;

namespace Believe.Client.Models.Matches;

/// <summary>
/// Types of matches.
/// </summary>
[JsonConverter(typeof(MatchTypeConverter))]
public enum MatchType
{
    League,
    Cup,
    Friendly,
    Playoff,
    Final,
}

sealed class MatchTypeConverter : JsonConverter<MatchType>
{
    public override MatchType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "league" => MatchType.League,
            "cup" => MatchType.Cup,
            "friendly" => MatchType.Friendly,
            "playoff" => MatchType.Playoff,
            "final" => MatchType.Final,
            _ => (MatchType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MatchType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MatchType.League => "league",
                MatchType.Cup => "cup",
                MatchType.Friendly => "friendly",
                MatchType.Playoff => "playoff",
                MatchType.Final => "final",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
