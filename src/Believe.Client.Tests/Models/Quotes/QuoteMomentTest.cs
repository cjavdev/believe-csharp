using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Exceptions;
using Believe.Client.Models.Quotes;

namespace Believe.Client.Tests.Models.Quotes;

public class QuoteMomentTest : TestBase
{
    [Theory]
    [InlineData(QuoteMoment.HalftimeSpeech)]
    [InlineData(QuoteMoment.PressConference)]
    [InlineData(QuoteMoment.LockerRoom)]
    [InlineData(QuoteMoment.Training)]
    [InlineData(QuoteMoment.BiscuitsWithBoss)]
    [InlineData(QuoteMoment.Pub)]
    [InlineData(QuoteMoment.OneOnOne)]
    [InlineData(QuoteMoment.Celebration)]
    [InlineData(QuoteMoment.Crisis)]
    [InlineData(QuoteMoment.Casual)]
    [InlineData(QuoteMoment.Confrontation)]
    public void Validation_Works(QuoteMoment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, QuoteMoment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, QuoteMoment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(QuoteMoment.HalftimeSpeech)]
    [InlineData(QuoteMoment.PressConference)]
    [InlineData(QuoteMoment.LockerRoom)]
    [InlineData(QuoteMoment.Training)]
    [InlineData(QuoteMoment.BiscuitsWithBoss)]
    [InlineData(QuoteMoment.Pub)]
    [InlineData(QuoteMoment.OneOnOne)]
    [InlineData(QuoteMoment.Celebration)]
    [InlineData(QuoteMoment.Crisis)]
    [InlineData(QuoteMoment.Casual)]
    [InlineData(QuoteMoment.Confrontation)]
    public void SerializationRoundtrip_Works(QuoteMoment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, QuoteMoment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, QuoteMoment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, QuoteMoment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, QuoteMoment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
