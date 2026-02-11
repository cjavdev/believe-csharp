using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Quotes;

namespace Believe.Tests.Models.Quotes;

public class QuoteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Quote
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
            SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
            TimesShared = 150000,
        };

        string expectedID = "quote-001";
        string expectedCharacterID = "ted-lasso";
        string expectedContext =
            "Ted playing darts against Rupert in the pub, explaining his philosophy";
        ApiEnum<string, QuoteMoment> expectedMomentType = QuoteMoment.Pub;
        string expectedText = "Be curious, not judgmental.";
        ApiEnum<string, QuoteTheme> expectedTheme = QuoteTheme.Curiosity;
        string expectedEpisodeID = "s01e08";
        bool expectedIsFunny = false;
        bool expectedIsInspirational = true;
        double expectedPopularityScore = 95.5;
        List<ApiEnum<string, QuoteTheme>> expectedSecondaryThemes =
        [
            QuoteTheme.Wisdom,
            QuoteTheme.Kindness,
        ];
        long expectedTimesShared = 150000;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCharacterID, model.CharacterID);
        Assert.Equal(expectedContext, model.Context);
        Assert.Equal(expectedMomentType, model.MomentType);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTheme, model.Theme);
        Assert.Equal(expectedEpisodeID, model.EpisodeID);
        Assert.Equal(expectedIsFunny, model.IsFunny);
        Assert.Equal(expectedIsInspirational, model.IsInspirational);
        Assert.Equal(expectedPopularityScore, model.PopularityScore);
        Assert.NotNull(model.SecondaryThemes);
        Assert.Equal(expectedSecondaryThemes.Count, model.SecondaryThemes.Count);
        for (int i = 0; i < expectedSecondaryThemes.Count; i++)
        {
            Assert.Equal(expectedSecondaryThemes[i], model.SecondaryThemes[i]);
        }
        Assert.Equal(expectedTimesShared, model.TimesShared);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Quote
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
            SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
            TimesShared = 150000,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Quote>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Quote
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
            SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
            TimesShared = 150000,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Quote>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "quote-001";
        string expectedCharacterID = "ted-lasso";
        string expectedContext =
            "Ted playing darts against Rupert in the pub, explaining his philosophy";
        ApiEnum<string, QuoteMoment> expectedMomentType = QuoteMoment.Pub;
        string expectedText = "Be curious, not judgmental.";
        ApiEnum<string, QuoteTheme> expectedTheme = QuoteTheme.Curiosity;
        string expectedEpisodeID = "s01e08";
        bool expectedIsFunny = false;
        bool expectedIsInspirational = true;
        double expectedPopularityScore = 95.5;
        List<ApiEnum<string, QuoteTheme>> expectedSecondaryThemes =
        [
            QuoteTheme.Wisdom,
            QuoteTheme.Kindness,
        ];
        long expectedTimesShared = 150000;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCharacterID, deserialized.CharacterID);
        Assert.Equal(expectedContext, deserialized.Context);
        Assert.Equal(expectedMomentType, deserialized.MomentType);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedTheme, deserialized.Theme);
        Assert.Equal(expectedEpisodeID, deserialized.EpisodeID);
        Assert.Equal(expectedIsFunny, deserialized.IsFunny);
        Assert.Equal(expectedIsInspirational, deserialized.IsInspirational);
        Assert.Equal(expectedPopularityScore, deserialized.PopularityScore);
        Assert.NotNull(deserialized.SecondaryThemes);
        Assert.Equal(expectedSecondaryThemes.Count, deserialized.SecondaryThemes.Count);
        for (int i = 0; i < expectedSecondaryThemes.Count; i++)
        {
            Assert.Equal(expectedSecondaryThemes[i], deserialized.SecondaryThemes[i]);
        }
        Assert.Equal(expectedTimesShared, deserialized.TimesShared);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Quote
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
            SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
            TimesShared = 150000,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Quote
        {
            ID = "quote-001",
            CharacterID = "ted-lasso",
            Context = "Ted playing darts against Rupert in the pub, explaining his philosophy",
            MomentType = QuoteMoment.Pub,
            Text = "Be curious, not judgmental.",
            Theme = QuoteTheme.Curiosity,
            EpisodeID = "s01e08",
            PopularityScore = 95.5,
            TimesShared = 150000,
        };

        Assert.Null(model.IsFunny);
        Assert.False(model.RawData.ContainsKey("is_funny"));
        Assert.Null(model.IsInspirational);
        Assert.False(model.RawData.ContainsKey("is_inspirational"));
        Assert.Null(model.SecondaryThemes);
        Assert.False(model.RawData.ContainsKey("secondary_themes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Quote
        {
            ID = "quote-001",
            CharacterID = "ted-lasso",
            Context = "Ted playing darts against Rupert in the pub, explaining his philosophy",
            MomentType = QuoteMoment.Pub,
            Text = "Be curious, not judgmental.",
            Theme = QuoteTheme.Curiosity,
            EpisodeID = "s01e08",
            PopularityScore = 95.5,
            TimesShared = 150000,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Quote
        {
            ID = "quote-001",
            CharacterID = "ted-lasso",
            Context = "Ted playing darts against Rupert in the pub, explaining his philosophy",
            MomentType = QuoteMoment.Pub,
            Text = "Be curious, not judgmental.",
            Theme = QuoteTheme.Curiosity,
            EpisodeID = "s01e08",
            PopularityScore = 95.5,
            TimesShared = 150000,

            // Null should be interpreted as omitted for these properties
            IsFunny = null,
            IsInspirational = null,
            SecondaryThemes = null,
        };

        Assert.Null(model.IsFunny);
        Assert.False(model.RawData.ContainsKey("is_funny"));
        Assert.Null(model.IsInspirational);
        Assert.False(model.RawData.ContainsKey("is_inspirational"));
        Assert.Null(model.SecondaryThemes);
        Assert.False(model.RawData.ContainsKey("secondary_themes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Quote
        {
            ID = "quote-001",
            CharacterID = "ted-lasso",
            Context = "Ted playing darts against Rupert in the pub, explaining his philosophy",
            MomentType = QuoteMoment.Pub,
            Text = "Be curious, not judgmental.",
            Theme = QuoteTheme.Curiosity,
            EpisodeID = "s01e08",
            PopularityScore = 95.5,
            TimesShared = 150000,

            // Null should be interpreted as omitted for these properties
            IsFunny = null,
            IsInspirational = null,
            SecondaryThemes = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Quote
        {
            ID = "quote-001",
            CharacterID = "ted-lasso",
            Context = "Ted playing darts against Rupert in the pub, explaining his philosophy",
            MomentType = QuoteMoment.Pub,
            Text = "Be curious, not judgmental.",
            Theme = QuoteTheme.Curiosity,
            IsFunny = false,
            IsInspirational = true,
            SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
        };

        Assert.Null(model.EpisodeID);
        Assert.False(model.RawData.ContainsKey("episode_id"));
        Assert.Null(model.PopularityScore);
        Assert.False(model.RawData.ContainsKey("popularity_score"));
        Assert.Null(model.TimesShared);
        Assert.False(model.RawData.ContainsKey("times_shared"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Quote
        {
            ID = "quote-001",
            CharacterID = "ted-lasso",
            Context = "Ted playing darts against Rupert in the pub, explaining his philosophy",
            MomentType = QuoteMoment.Pub,
            Text = "Be curious, not judgmental.",
            Theme = QuoteTheme.Curiosity,
            IsFunny = false,
            IsInspirational = true,
            SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Quote
        {
            ID = "quote-001",
            CharacterID = "ted-lasso",
            Context = "Ted playing darts against Rupert in the pub, explaining his philosophy",
            MomentType = QuoteMoment.Pub,
            Text = "Be curious, not judgmental.",
            Theme = QuoteTheme.Curiosity,
            IsFunny = false,
            IsInspirational = true,
            SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],

            EpisodeID = null,
            PopularityScore = null,
            TimesShared = null,
        };

        Assert.Null(model.EpisodeID);
        Assert.True(model.RawData.ContainsKey("episode_id"));
        Assert.Null(model.PopularityScore);
        Assert.True(model.RawData.ContainsKey("popularity_score"));
        Assert.Null(model.TimesShared);
        Assert.True(model.RawData.ContainsKey("times_shared"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Quote
        {
            ID = "quote-001",
            CharacterID = "ted-lasso",
            Context = "Ted playing darts against Rupert in the pub, explaining his philosophy",
            MomentType = QuoteMoment.Pub,
            Text = "Be curious, not judgmental.",
            Theme = QuoteTheme.Curiosity,
            IsFunny = false,
            IsInspirational = true,
            SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],

            EpisodeID = null,
            PopularityScore = null,
            TimesShared = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Quote
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
            SecondaryThemes = [QuoteTheme.Wisdom, QuoteTheme.Kindness],
            TimesShared = 150000,
        };

        Quote copied = new(model);

        Assert.Equal(model, copied);
    }
}
