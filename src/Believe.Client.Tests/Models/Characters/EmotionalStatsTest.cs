using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Models.Characters;

namespace Believe.Client.Tests.Models.Characters;

public class EmotionalStatsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmotionalStats
        {
            Curiosity = 99,
            Empathy = 100,
            Optimism = 95,
            Resilience = 90,
            Vulnerability = 80,
        };

        long expectedCuriosity = 99;
        long expectedEmpathy = 100;
        long expectedOptimism = 95;
        long expectedResilience = 90;
        long expectedVulnerability = 80;

        Assert.Equal(expectedCuriosity, model.Curiosity);
        Assert.Equal(expectedEmpathy, model.Empathy);
        Assert.Equal(expectedOptimism, model.Optimism);
        Assert.Equal(expectedResilience, model.Resilience);
        Assert.Equal(expectedVulnerability, model.Vulnerability);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmotionalStats
        {
            Curiosity = 99,
            Empathy = 100,
            Optimism = 95,
            Resilience = 90,
            Vulnerability = 80,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmotionalStats>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmotionalStats
        {
            Curiosity = 99,
            Empathy = 100,
            Optimism = 95,
            Resilience = 90,
            Vulnerability = 80,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmotionalStats>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCuriosity = 99;
        long expectedEmpathy = 100;
        long expectedOptimism = 95;
        long expectedResilience = 90;
        long expectedVulnerability = 80;

        Assert.Equal(expectedCuriosity, deserialized.Curiosity);
        Assert.Equal(expectedEmpathy, deserialized.Empathy);
        Assert.Equal(expectedOptimism, deserialized.Optimism);
        Assert.Equal(expectedResilience, deserialized.Resilience);
        Assert.Equal(expectedVulnerability, deserialized.Vulnerability);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmotionalStats
        {
            Curiosity = 99,
            Empathy = 100,
            Optimism = 95,
            Resilience = 90,
            Vulnerability = 80,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EmotionalStats
        {
            Curiosity = 99,
            Empathy = 100,
            Optimism = 95,
            Resilience = 90,
            Vulnerability = 80,
        };

        EmotionalStats copied = new(model);

        Assert.Equal(model, copied);
    }
}
