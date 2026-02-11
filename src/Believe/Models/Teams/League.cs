using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Exceptions;

namespace Believe.Models.Teams;

/// <summary>
/// Football leagues.
/// </summary>
[JsonConverter(typeof(LeagueConverter))]
public enum League
{
    PremierLeague,
    Championship,
    LeagueOne,
    LeagueTwo,
    LaLiga,
    SerieA,
    Bundesliga,
    Ligue1,
}

sealed class LeagueConverter : JsonConverter<League>
{
    public override League Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Premier League" => League.PremierLeague,
            "Championship" => League.Championship,
            "League One" => League.LeagueOne,
            "League Two" => League.LeagueTwo,
            "La Liga" => League.LaLiga,
            "Serie A" => League.SerieA,
            "Bundesliga" => League.Bundesliga,
            "Ligue 1" => League.Ligue1,
            _ => (League)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, League value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                League.PremierLeague => "Premier League",
                League.Championship => "Championship",
                League.LeagueOne => "League One",
                League.LeagueTwo => "League Two",
                League.LaLiga => "La Liga",
                League.SerieA => "Serie A",
                League.Bundesliga => "Bundesliga",
                League.Ligue1 => "Ligue 1",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
