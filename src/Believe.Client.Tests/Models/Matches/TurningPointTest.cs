using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Models.Matches;

namespace Believe.Client.Tests.Models.Matches;

public class TurningPointTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TurningPoint
        {
            Description = "description",
            EmotionalImpact = "Galvanized the team's fighting spirit",
            Minute = 0,
            CharacterInvolved = "jamie-tartt",
        };

        string expectedDescription = "description";
        string expectedEmotionalImpact = "Galvanized the team's fighting spirit";
        long expectedMinute = 0;
        string expectedCharacterInvolved = "jamie-tartt";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEmotionalImpact, model.EmotionalImpact);
        Assert.Equal(expectedMinute, model.Minute);
        Assert.Equal(expectedCharacterInvolved, model.CharacterInvolved);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TurningPoint
        {
            Description = "description",
            EmotionalImpact = "Galvanized the team's fighting spirit",
            Minute = 0,
            CharacterInvolved = "jamie-tartt",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TurningPoint>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TurningPoint
        {
            Description = "description",
            EmotionalImpact = "Galvanized the team's fighting spirit",
            Minute = 0,
            CharacterInvolved = "jamie-tartt",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TurningPoint>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedEmotionalImpact = "Galvanized the team's fighting spirit";
        long expectedMinute = 0;
        string expectedCharacterInvolved = "jamie-tartt";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEmotionalImpact, deserialized.EmotionalImpact);
        Assert.Equal(expectedMinute, deserialized.Minute);
        Assert.Equal(expectedCharacterInvolved, deserialized.CharacterInvolved);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TurningPoint
        {
            Description = "description",
            EmotionalImpact = "Galvanized the team's fighting spirit",
            Minute = 0,
            CharacterInvolved = "jamie-tartt",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TurningPoint
        {
            Description = "description",
            EmotionalImpact = "Galvanized the team's fighting spirit",
            Minute = 0,
        };

        Assert.Null(model.CharacterInvolved);
        Assert.False(model.RawData.ContainsKey("character_involved"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TurningPoint
        {
            Description = "description",
            EmotionalImpact = "Galvanized the team's fighting spirit",
            Minute = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TurningPoint
        {
            Description = "description",
            EmotionalImpact = "Galvanized the team's fighting spirit",
            Minute = 0,

            CharacterInvolved = null,
        };

        Assert.Null(model.CharacterInvolved);
        Assert.True(model.RawData.ContainsKey("character_involved"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TurningPoint
        {
            Description = "description",
            EmotionalImpact = "Galvanized the team's fighting spirit",
            Minute = 0,

            CharacterInvolved = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TurningPoint
        {
            Description = "description",
            EmotionalImpact = "Galvanized the team's fighting spirit",
            Minute = 0,
            CharacterInvolved = "jamie-tartt",
        };

        TurningPoint copied = new(model);

        Assert.Equal(model, copied);
    }
}
