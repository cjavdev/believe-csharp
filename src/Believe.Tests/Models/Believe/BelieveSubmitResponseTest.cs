using System.Text.Json;
using Believe.Core;
using Believe.Models.Believe;

namespace Believe.Tests.Models.Believe;

public class BelieveSubmitResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BelieveSubmitResponse
        {
            ActionSuggestion =
                "Schedule a one-on-one with your manager to understand what growth areas they'd like to see, and ask them to be your partner in getting you ready for the next opportunity.",
            BelieveScore = 78,
            GoldfishWisdom =
                "Remember, a goldfish has a 10-second memory. Feel this disappointment, then let it swim on by. Tomorrow's a new tank, friend.",
            RelevantQuote = "I believe in believe.",
            TedResponse =
                "Well shoot, partner, I know that stings like a bee that just watched Field of Dreams. But here's the thing about getting passed over - it don't mean you're not good enough, it just means your moment ain't arrived yet. And let me tell you, when it does? It's gonna be sweeter than my Aunt Mildred's pecan pie.",
        };

        string expectedActionSuggestion =
            "Schedule a one-on-one with your manager to understand what growth areas they'd like to see, and ask them to be your partner in getting you ready for the next opportunity.";
        long expectedBelieveScore = 78;
        string expectedGoldfishWisdom =
            "Remember, a goldfish has a 10-second memory. Feel this disappointment, then let it swim on by. Tomorrow's a new tank, friend.";
        string expectedRelevantQuote = "I believe in believe.";
        string expectedTedResponse =
            "Well shoot, partner, I know that stings like a bee that just watched Field of Dreams. But here's the thing about getting passed over - it don't mean you're not good enough, it just means your moment ain't arrived yet. And let me tell you, when it does? It's gonna be sweeter than my Aunt Mildred's pecan pie.";

        Assert.Equal(expectedActionSuggestion, model.ActionSuggestion);
        Assert.Equal(expectedBelieveScore, model.BelieveScore);
        Assert.Equal(expectedGoldfishWisdom, model.GoldfishWisdom);
        Assert.Equal(expectedRelevantQuote, model.RelevantQuote);
        Assert.Equal(expectedTedResponse, model.TedResponse);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BelieveSubmitResponse
        {
            ActionSuggestion =
                "Schedule a one-on-one with your manager to understand what growth areas they'd like to see, and ask them to be your partner in getting you ready for the next opportunity.",
            BelieveScore = 78,
            GoldfishWisdom =
                "Remember, a goldfish has a 10-second memory. Feel this disappointment, then let it swim on by. Tomorrow's a new tank, friend.",
            RelevantQuote = "I believe in believe.",
            TedResponse =
                "Well shoot, partner, I know that stings like a bee that just watched Field of Dreams. But here's the thing about getting passed over - it don't mean you're not good enough, it just means your moment ain't arrived yet. And let me tell you, when it does? It's gonna be sweeter than my Aunt Mildred's pecan pie.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BelieveSubmitResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BelieveSubmitResponse
        {
            ActionSuggestion =
                "Schedule a one-on-one with your manager to understand what growth areas they'd like to see, and ask them to be your partner in getting you ready for the next opportunity.",
            BelieveScore = 78,
            GoldfishWisdom =
                "Remember, a goldfish has a 10-second memory. Feel this disappointment, then let it swim on by. Tomorrow's a new tank, friend.",
            RelevantQuote = "I believe in believe.",
            TedResponse =
                "Well shoot, partner, I know that stings like a bee that just watched Field of Dreams. But here's the thing about getting passed over - it don't mean you're not good enough, it just means your moment ain't arrived yet. And let me tell you, when it does? It's gonna be sweeter than my Aunt Mildred's pecan pie.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BelieveSubmitResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedActionSuggestion =
            "Schedule a one-on-one with your manager to understand what growth areas they'd like to see, and ask them to be your partner in getting you ready for the next opportunity.";
        long expectedBelieveScore = 78;
        string expectedGoldfishWisdom =
            "Remember, a goldfish has a 10-second memory. Feel this disappointment, then let it swim on by. Tomorrow's a new tank, friend.";
        string expectedRelevantQuote = "I believe in believe.";
        string expectedTedResponse =
            "Well shoot, partner, I know that stings like a bee that just watched Field of Dreams. But here's the thing about getting passed over - it don't mean you're not good enough, it just means your moment ain't arrived yet. And let me tell you, when it does? It's gonna be sweeter than my Aunt Mildred's pecan pie.";

        Assert.Equal(expectedActionSuggestion, deserialized.ActionSuggestion);
        Assert.Equal(expectedBelieveScore, deserialized.BelieveScore);
        Assert.Equal(expectedGoldfishWisdom, deserialized.GoldfishWisdom);
        Assert.Equal(expectedRelevantQuote, deserialized.RelevantQuote);
        Assert.Equal(expectedTedResponse, deserialized.TedResponse);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BelieveSubmitResponse
        {
            ActionSuggestion =
                "Schedule a one-on-one with your manager to understand what growth areas they'd like to see, and ask them to be your partner in getting you ready for the next opportunity.",
            BelieveScore = 78,
            GoldfishWisdom =
                "Remember, a goldfish has a 10-second memory. Feel this disappointment, then let it swim on by. Tomorrow's a new tank, friend.",
            RelevantQuote = "I believe in believe.",
            TedResponse =
                "Well shoot, partner, I know that stings like a bee that just watched Field of Dreams. But here's the thing about getting passed over - it don't mean you're not good enough, it just means your moment ain't arrived yet. And let me tell you, when it does? It's gonna be sweeter than my Aunt Mildred's pecan pie.",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BelieveSubmitResponse
        {
            ActionSuggestion =
                "Schedule a one-on-one with your manager to understand what growth areas they'd like to see, and ask them to be your partner in getting you ready for the next opportunity.",
            BelieveScore = 78,
            GoldfishWisdom =
                "Remember, a goldfish has a 10-second memory. Feel this disappointment, then let it swim on by. Tomorrow's a new tank, friend.",
            RelevantQuote = "I believe in believe.",
            TedResponse =
                "Well shoot, partner, I know that stings like a bee that just watched Field of Dreams. But here's the thing about getting passed over - it don't mean you're not good enough, it just means your moment ain't arrived yet. And let me tell you, when it does? It's gonna be sweeter than my Aunt Mildred's pecan pie.",
        };

        BelieveSubmitResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
