using System.Text.Json;
using Believe.Core;
using Believe.Models.Characters;

namespace Believe.Tests.Models.Characters;

public class GrowthArcTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GrowthArc
        {
            Breakthrough = "breakthrough",
            Challenge = "challenge",
            EndingPoint = "ending_point",
            Season = 1,
            StartingPoint = "starting_point",
        };

        string expectedBreakthrough = "breakthrough";
        string expectedChallenge = "challenge";
        string expectedEndingPoint = "ending_point";
        long expectedSeason = 1;
        string expectedStartingPoint = "starting_point";

        Assert.Equal(expectedBreakthrough, model.Breakthrough);
        Assert.Equal(expectedChallenge, model.Challenge);
        Assert.Equal(expectedEndingPoint, model.EndingPoint);
        Assert.Equal(expectedSeason, model.Season);
        Assert.Equal(expectedStartingPoint, model.StartingPoint);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GrowthArc
        {
            Breakthrough = "breakthrough",
            Challenge = "challenge",
            EndingPoint = "ending_point",
            Season = 1,
            StartingPoint = "starting_point",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrowthArc>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GrowthArc
        {
            Breakthrough = "breakthrough",
            Challenge = "challenge",
            EndingPoint = "ending_point",
            Season = 1,
            StartingPoint = "starting_point",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrowthArc>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBreakthrough = "breakthrough";
        string expectedChallenge = "challenge";
        string expectedEndingPoint = "ending_point";
        long expectedSeason = 1;
        string expectedStartingPoint = "starting_point";

        Assert.Equal(expectedBreakthrough, deserialized.Breakthrough);
        Assert.Equal(expectedChallenge, deserialized.Challenge);
        Assert.Equal(expectedEndingPoint, deserialized.EndingPoint);
        Assert.Equal(expectedSeason, deserialized.Season);
        Assert.Equal(expectedStartingPoint, deserialized.StartingPoint);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GrowthArc
        {
            Breakthrough = "breakthrough",
            Challenge = "challenge",
            EndingPoint = "ending_point",
            Season = 1,
            StartingPoint = "starting_point",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GrowthArc
        {
            Breakthrough = "breakthrough",
            Challenge = "challenge",
            EndingPoint = "ending_point",
            Season = 1,
            StartingPoint = "starting_point",
        };

        GrowthArc copied = new(model);

        Assert.Equal(model, copied);
    }
}
