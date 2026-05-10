using System.Collections.Generic;
using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Models.Teams;

namespace Believe.Client.Tests.Models.Teams;

public class TeamValuesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TeamValues
        {
            PrimaryValue = "Believe",
            SecondaryValues = ["Family", "Resilience", "Joy"],
            TeamMotto = "Football is life!",
        };

        string expectedPrimaryValue = "Believe";
        List<string> expectedSecondaryValues = ["Family", "Resilience", "Joy"];
        string expectedTeamMotto = "Football is life!";

        Assert.Equal(expectedPrimaryValue, model.PrimaryValue);
        Assert.Equal(expectedSecondaryValues.Count, model.SecondaryValues.Count);
        for (int i = 0; i < expectedSecondaryValues.Count; i++)
        {
            Assert.Equal(expectedSecondaryValues[i], model.SecondaryValues[i]);
        }
        Assert.Equal(expectedTeamMotto, model.TeamMotto);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TeamValues
        {
            PrimaryValue = "Believe",
            SecondaryValues = ["Family", "Resilience", "Joy"],
            TeamMotto = "Football is life!",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamValues>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TeamValues
        {
            PrimaryValue = "Believe",
            SecondaryValues = ["Family", "Resilience", "Joy"],
            TeamMotto = "Football is life!",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamValues>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPrimaryValue = "Believe";
        List<string> expectedSecondaryValues = ["Family", "Resilience", "Joy"];
        string expectedTeamMotto = "Football is life!";

        Assert.Equal(expectedPrimaryValue, deserialized.PrimaryValue);
        Assert.Equal(expectedSecondaryValues.Count, deserialized.SecondaryValues.Count);
        for (int i = 0; i < expectedSecondaryValues.Count; i++)
        {
            Assert.Equal(expectedSecondaryValues[i], deserialized.SecondaryValues[i]);
        }
        Assert.Equal(expectedTeamMotto, deserialized.TeamMotto);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TeamValues
        {
            PrimaryValue = "Believe",
            SecondaryValues = ["Family", "Resilience", "Joy"],
            TeamMotto = "Football is life!",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TeamValues
        {
            PrimaryValue = "Believe",
            SecondaryValues = ["Family", "Resilience", "Joy"],
            TeamMotto = "Football is life!",
        };

        TeamValues copied = new(model);

        Assert.Equal(model, copied);
    }
}
