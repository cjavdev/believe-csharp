using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Teams;

namespace Believe.Tests.Models.Teams;

public class LeagueTest : TestBase
{
    [Theory][InlineData(League.PremierLeague)][InlineData(League.Championship)][InlineData(League.LeagueOne)][InlineData(League.LeagueTwo)][InlineData(League.LaLiga)][InlineData(League.SerieA)][InlineData(League.Bundesliga)][InlineData(League.Ligue1)]
    public void Validation_Works(League rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, League> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, League>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(League.PremierLeague)][InlineData(League.Championship)][InlineData(League.LeagueOne)][InlineData(League.LeagueTwo)][InlineData(League.LaLiga)][InlineData(League.SerieA)][InlineData(League.Bundesliga)][InlineData(League.Ligue1)]
    public void SerializationRoundtrip_Works(League rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, League> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, League>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, League>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, League>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}