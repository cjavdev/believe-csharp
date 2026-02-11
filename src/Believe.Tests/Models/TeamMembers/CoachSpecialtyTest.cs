using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.TeamMembers;

namespace Believe.Tests.Models.TeamMembers;

public class CoachSpecialtyTest : TestBase
{
    [Theory]
    [InlineData(CoachSpecialty.HeadCoach)]
    [InlineData(CoachSpecialty.AssistantCoach)]
    [InlineData(CoachSpecialty.GoalkeepingCoach)]
    [InlineData(CoachSpecialty.FitnessCoach)]
    [InlineData(CoachSpecialty.TacticalAnalyst)]
    public void Validation_Works(CoachSpecialty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CoachSpecialty> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CoachSpecialty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CoachSpecialty.HeadCoach)]
    [InlineData(CoachSpecialty.AssistantCoach)]
    [InlineData(CoachSpecialty.GoalkeepingCoach)]
    [InlineData(CoachSpecialty.FitnessCoach)]
    [InlineData(CoachSpecialty.TacticalAnalyst)]
    public void SerializationRoundtrip_Works(CoachSpecialty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CoachSpecialty> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CoachSpecialty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CoachSpecialty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CoachSpecialty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
