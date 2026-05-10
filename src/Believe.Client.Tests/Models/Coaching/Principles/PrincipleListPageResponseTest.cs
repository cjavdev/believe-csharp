using System.Collections.Generic;
using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Models.Coaching.Principles;

namespace Believe.Client.Tests.Models.Coaching.Principles;

public class PrincipleListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PrincipleListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        List<CoachingPrinciple> expectedData =
        [
            new()
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
            },
        ];
        bool expectedHasMore = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedPages = 0;
        long expectedSkip = 0;
        long expectedTotal = 0;

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedPages, model.Pages);
        Assert.Equal(expectedSkip, model.Skip);
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PrincipleListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PrincipleListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PrincipleListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PrincipleListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CoachingPrinciple> expectedData =
        [
            new()
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
            },
        ];
        bool expectedHasMore = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedPages = 0;
        long expectedSkip = 0;
        long expectedTotal = 0;

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedPages, deserialized.Pages);
        Assert.Equal(expectedSkip, deserialized.Skip);
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PrincipleListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PrincipleListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        PrincipleListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
