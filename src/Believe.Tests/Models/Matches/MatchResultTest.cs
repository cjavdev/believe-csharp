using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Matches;

namespace Believe.Tests.Models.Matches;

public class MatchResultTest : TestBase
{
    [Theory][InlineData(MatchResult.Win)][InlineData(MatchResult.Loss)][InlineData(MatchResult.Draw)][InlineData(MatchResult.Pending)]
    public void Validation_Works(MatchResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MatchResult>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(MatchResult.Win)][InlineData(MatchResult.Loss)][InlineData(MatchResult.Draw)][InlineData(MatchResult.Pending)]
    public void SerializationRoundtrip_Works(MatchResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MatchResult>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MatchResult>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MatchResult>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}