using System.Collections.Generic;
using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Models.Quotes;

namespace Believe.Client.Tests.Models.Quotes;

public class PaginatedResponseQuoteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaginatedResponseQuote
        {
            Data =
            [
                new()
                {
                    ID = "quote-001",
                    CharacterID = "ted-lasso",
                    Context =
                        "Ted playing darts against Rupert in the pub, explaining his philosophy",
                    MomentType = QuoteMoment.Pub,
                    Text = "Be curious, not judgmental.",
                    Theme = QuoteTheme.Curiosity,
                    EpisodeID = "s01e08",
                    IsFunny = false,
                    IsInspirational = true,
                    PopularityScore = 95.5,
                    Season = 1,
                    SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
                    TimesShared = 150000,
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        List<Quote> expectedData =
        [
            new()
            {
                ID = "quote-001",
                CharacterID = "ted-lasso",
                Context = "Ted playing darts against Rupert in the pub, explaining his philosophy",
                MomentType = QuoteMoment.Pub,
                Text = "Be curious, not judgmental.",
                Theme = QuoteTheme.Curiosity,
                EpisodeID = "s01e08",
                IsFunny = false,
                IsInspirational = true,
                PopularityScore = 95.5,
                Season = 1,
                SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
                TimesShared = 150000,
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
        var model = new PaginatedResponseQuote
        {
            Data =
            [
                new()
                {
                    ID = "quote-001",
                    CharacterID = "ted-lasso",
                    Context =
                        "Ted playing darts against Rupert in the pub, explaining his philosophy",
                    MomentType = QuoteMoment.Pub,
                    Text = "Be curious, not judgmental.",
                    Theme = QuoteTheme.Curiosity,
                    EpisodeID = "s01e08",
                    IsFunny = false,
                    IsInspirational = true,
                    PopularityScore = 95.5,
                    Season = 1,
                    SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
                    TimesShared = 150000,
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
        var deserialized = JsonSerializer.Deserialize<PaginatedResponseQuote>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaginatedResponseQuote
        {
            Data =
            [
                new()
                {
                    ID = "quote-001",
                    CharacterID = "ted-lasso",
                    Context =
                        "Ted playing darts against Rupert in the pub, explaining his philosophy",
                    MomentType = QuoteMoment.Pub,
                    Text = "Be curious, not judgmental.",
                    Theme = QuoteTheme.Curiosity,
                    EpisodeID = "s01e08",
                    IsFunny = false,
                    IsInspirational = true,
                    PopularityScore = 95.5,
                    Season = 1,
                    SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
                    TimesShared = 150000,
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
        var deserialized = JsonSerializer.Deserialize<PaginatedResponseQuote>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Quote> expectedData =
        [
            new()
            {
                ID = "quote-001",
                CharacterID = "ted-lasso",
                Context = "Ted playing darts against Rupert in the pub, explaining his philosophy",
                MomentType = QuoteMoment.Pub,
                Text = "Be curious, not judgmental.",
                Theme = QuoteTheme.Curiosity,
                EpisodeID = "s01e08",
                IsFunny = false,
                IsInspirational = true,
                PopularityScore = 95.5,
                Season = 1,
                SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
                TimesShared = 150000,
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
        var model = new PaginatedResponseQuote
        {
            Data =
            [
                new()
                {
                    ID = "quote-001",
                    CharacterID = "ted-lasso",
                    Context =
                        "Ted playing darts against Rupert in the pub, explaining his philosophy",
                    MomentType = QuoteMoment.Pub,
                    Text = "Be curious, not judgmental.",
                    Theme = QuoteTheme.Curiosity,
                    EpisodeID = "s01e08",
                    IsFunny = false,
                    IsInspirational = true,
                    PopularityScore = 95.5,
                    Season = 1,
                    SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
                    TimesShared = 150000,
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
        var model = new PaginatedResponseQuote
        {
            Data =
            [
                new()
                {
                    ID = "quote-001",
                    CharacterID = "ted-lasso",
                    Context =
                        "Ted playing darts against Rupert in the pub, explaining his philosophy",
                    MomentType = QuoteMoment.Pub,
                    Text = "Be curious, not judgmental.",
                    Theme = QuoteTheme.Curiosity,
                    EpisodeID = "s01e08",
                    IsFunny = false,
                    IsInspirational = true,
                    PopularityScore = 95.5,
                    Season = 1,
                    SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
                    TimesShared = 150000,
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        PaginatedResponseQuote copied = new(model);

        Assert.Equal(model, copied);
    }
}
