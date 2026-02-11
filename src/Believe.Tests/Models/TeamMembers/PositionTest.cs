using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.TeamMembers;

namespace Believe.Tests.Models.TeamMembers;

public class PositionTest : TestBase
{
    [Theory]
    [InlineData(Position.Goalkeeper)]
    [InlineData(Position.Defender)]
    [InlineData(Position.Midfielder)]
    [InlineData(Position.Forward)]
    public void Validation_Works(Position rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Position> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Position>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Position.Goalkeeper)]
    [InlineData(Position.Defender)]
    [InlineData(Position.Midfielder)]
    [InlineData(Position.Forward)]
    public void SerializationRoundtrip_Works(Position rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Position> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Position>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Position>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Position>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
