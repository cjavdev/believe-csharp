using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Matches;

namespace Believe.Tests.Models.Matches;

public class MatchTypeTest : TestBase
{
    [Theory][InlineData(MatchType.League)][InlineData(MatchType.Cup)][InlineData(MatchType.Friendly)][InlineData(MatchType.Playoff)][InlineData(MatchType.Final)]
    public void Validation_Works(MatchType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MatchType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(MatchType.League)][InlineData(MatchType.Cup)][InlineData(MatchType.Friendly)][InlineData(MatchType.Playoff)][InlineData(MatchType.Final)]
    public void SerializationRoundtrip_Works(MatchType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MatchType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MatchType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MatchType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}