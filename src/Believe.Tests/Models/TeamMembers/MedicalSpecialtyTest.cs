using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.TeamMembers;

namespace Believe.Tests.Models.TeamMembers;

public class MedicalSpecialtyTest : TestBase
{
    [Theory]
    [InlineData(MedicalSpecialty.TeamDoctor)]
    [InlineData(MedicalSpecialty.Physiotherapist)]
    [InlineData(MedicalSpecialty.SportsPsychologist)]
    [InlineData(MedicalSpecialty.Nutritionist)]
    [InlineData(MedicalSpecialty.MassageTherapist)]
    public void Validation_Works(MedicalSpecialty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MedicalSpecialty> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MedicalSpecialty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MedicalSpecialty.TeamDoctor)]
    [InlineData(MedicalSpecialty.Physiotherapist)]
    [InlineData(MedicalSpecialty.SportsPsychologist)]
    [InlineData(MedicalSpecialty.Nutritionist)]
    [InlineData(MedicalSpecialty.MassageTherapist)]
    public void SerializationRoundtrip_Works(MedicalSpecialty rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MedicalSpecialty> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MedicalSpecialty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MedicalSpecialty>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MedicalSpecialty>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
