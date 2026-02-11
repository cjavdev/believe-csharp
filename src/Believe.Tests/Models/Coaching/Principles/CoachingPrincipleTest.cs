using System.Text.Json;
using Believe.Core;
using Believe.Models.Coaching.Principles;

namespace Believe.Tests.Models.Coaching.Principles;

public class CoachingPrincipleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CoachingPrinciple
        {
            ID = "be-curious",
            Application =
                "When someone frustrates you, ask questions before making assumptions. Seek to understand their perspective and motivations.",
            ExampleFromShow =
                "Ted uses this principle during the dart game with Rupert, explaining how people underestimated him his whole life because they judged before being curious.",
            Explanation =
                "Approach people and situations with genuine curiosity rather than preconceived judgments. Everyone has a story worth understanding.",
            Principle = "Be curious, not judgmental",
            TedQuote = "Be curious, not judgmental. - Walt Whitman... I think.",
        };

        string expectedID = "be-curious";
        string expectedApplication =
            "When someone frustrates you, ask questions before making assumptions. Seek to understand their perspective and motivations.";
        string expectedExampleFromShow =
            "Ted uses this principle during the dart game with Rupert, explaining how people underestimated him his whole life because they judged before being curious.";
        string expectedExplanation =
            "Approach people and situations with genuine curiosity rather than preconceived judgments. Everyone has a story worth understanding.";
        string expectedPrinciple = "Be curious, not judgmental";
        string expectedTedQuote = "Be curious, not judgmental. - Walt Whitman... I think.";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedApplication, model.Application);
        Assert.Equal(expectedExampleFromShow, model.ExampleFromShow);
        Assert.Equal(expectedExplanation, model.Explanation);
        Assert.Equal(expectedPrinciple, model.Principle);
        Assert.Equal(expectedTedQuote, model.TedQuote);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CoachingPrinciple
        {
            ID = "be-curious",
            Application =
                "When someone frustrates you, ask questions before making assumptions. Seek to understand their perspective and motivations.",
            ExampleFromShow =
                "Ted uses this principle during the dart game with Rupert, explaining how people underestimated him his whole life because they judged before being curious.",
            Explanation =
                "Approach people and situations with genuine curiosity rather than preconceived judgments. Everyone has a story worth understanding.",
            Principle = "Be curious, not judgmental",
            TedQuote = "Be curious, not judgmental. - Walt Whitman... I think.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CoachingPrinciple>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CoachingPrinciple
        {
            ID = "be-curious",
            Application =
                "When someone frustrates you, ask questions before making assumptions. Seek to understand their perspective and motivations.",
            ExampleFromShow =
                "Ted uses this principle during the dart game with Rupert, explaining how people underestimated him his whole life because they judged before being curious.",
            Explanation =
                "Approach people and situations with genuine curiosity rather than preconceived judgments. Everyone has a story worth understanding.",
            Principle = "Be curious, not judgmental",
            TedQuote = "Be curious, not judgmental. - Walt Whitman... I think.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CoachingPrinciple>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "be-curious";
        string expectedApplication =
            "When someone frustrates you, ask questions before making assumptions. Seek to understand their perspective and motivations.";
        string expectedExampleFromShow =
            "Ted uses this principle during the dart game with Rupert, explaining how people underestimated him his whole life because they judged before being curious.";
        string expectedExplanation =
            "Approach people and situations with genuine curiosity rather than preconceived judgments. Everyone has a story worth understanding.";
        string expectedPrinciple = "Be curious, not judgmental";
        string expectedTedQuote = "Be curious, not judgmental. - Walt Whitman... I think.";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedApplication, deserialized.Application);
        Assert.Equal(expectedExampleFromShow, deserialized.ExampleFromShow);
        Assert.Equal(expectedExplanation, deserialized.Explanation);
        Assert.Equal(expectedPrinciple, deserialized.Principle);
        Assert.Equal(expectedTedQuote, deserialized.TedQuote);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CoachingPrinciple
        {
            ID = "be-curious",
            Application =
                "When someone frustrates you, ask questions before making assumptions. Seek to understand their perspective and motivations.",
            ExampleFromShow =
                "Ted uses this principle during the dart game with Rupert, explaining how people underestimated him his whole life because they judged before being curious.",
            Explanation =
                "Approach people and situations with genuine curiosity rather than preconceived judgments. Everyone has a story worth understanding.",
            Principle = "Be curious, not judgmental",
            TedQuote = "Be curious, not judgmental. - Walt Whitman... I think.",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CoachingPrinciple
        {
            ID = "be-curious",
            Application =
                "When someone frustrates you, ask questions before making assumptions. Seek to understand their perspective and motivations.",
            ExampleFromShow =
                "Ted uses this principle during the dart game with Rupert, explaining how people underestimated him his whole life because they judged before being curious.",
            Explanation =
                "Approach people and situations with genuine curiosity rather than preconceived judgments. Everyone has a story worth understanding.",
            Principle = "Be curious, not judgmental",
            TedQuote = "Be curious, not judgmental. - Walt Whitman... I think.",
        };

        CoachingPrinciple copied = new(model);

        Assert.Equal(model, copied);
    }
}
