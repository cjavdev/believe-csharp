using System;
using System.Collections.Generic;
using Believe.Core;
using Believe.Models.Quotes;

namespace Believe.Tests.Models.Quotes;

public class QuoteUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new QuoteUpdateParams
        {
            QuoteID = "quote_id",
            CharacterID = "character_id",
            Context = "context",
            EpisodeID = "episode_id",
            IsFunny = true,
            IsInspirational = true,
            MomentType = QuoteMoment.HalftimeSpeech,
            PopularityScore = 0,
            SecondaryThemes = [QuoteTheme.Belief],
            Text = "x",
            Theme = QuoteTheme.Belief,
            TimesShared = 0,
        };

        string expectedQuoteID = "quote_id";
        string expectedCharacterID = "character_id";
        string expectedContext = "context";
        string expectedEpisodeID = "episode_id";
        bool expectedIsFunny = true;
        bool expectedIsInspirational = true;
        ApiEnum<string, QuoteMoment> expectedMomentType = QuoteMoment.HalftimeSpeech;
        double expectedPopularityScore = 0;
        List<ApiEnum<string, QuoteTheme>> expectedSecondaryThemes = [QuoteTheme.Belief];
        string expectedText = "x";
        ApiEnum<string, QuoteTheme> expectedTheme = QuoteTheme.Belief;
        long expectedTimesShared = 0;

        Assert.Equal(expectedQuoteID, parameters.QuoteID);
        Assert.Equal(expectedCharacterID, parameters.CharacterID);
        Assert.Equal(expectedContext, parameters.Context);
        Assert.Equal(expectedEpisodeID, parameters.EpisodeID);
        Assert.Equal(expectedIsFunny, parameters.IsFunny);
        Assert.Equal(expectedIsInspirational, parameters.IsInspirational);
        Assert.Equal(expectedMomentType, parameters.MomentType);
        Assert.Equal(expectedPopularityScore, parameters.PopularityScore);
        Assert.NotNull(parameters.SecondaryThemes);
        Assert.Equal(expectedSecondaryThemes.Count, parameters.SecondaryThemes.Count);
        for (int i = 0; i < expectedSecondaryThemes.Count; i++)
        {
            Assert.Equal(expectedSecondaryThemes[i], parameters.SecondaryThemes[i]);
        }
        Assert.Equal(expectedText, parameters.Text);
        Assert.Equal(expectedTheme, parameters.Theme);
        Assert.Equal(expectedTimesShared, parameters.TimesShared);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new QuoteUpdateParams { QuoteID = "quote_id" };

        Assert.Null(parameters.CharacterID);
        Assert.False(parameters.RawBodyData.ContainsKey("character_id"));
        Assert.Null(parameters.Context);
        Assert.False(parameters.RawBodyData.ContainsKey("context"));
        Assert.Null(parameters.EpisodeID);
        Assert.False(parameters.RawBodyData.ContainsKey("episode_id"));
        Assert.Null(parameters.IsFunny);
        Assert.False(parameters.RawBodyData.ContainsKey("is_funny"));
        Assert.Null(parameters.IsInspirational);
        Assert.False(parameters.RawBodyData.ContainsKey("is_inspirational"));
        Assert.Null(parameters.MomentType);
        Assert.False(parameters.RawBodyData.ContainsKey("moment_type"));
        Assert.Null(parameters.PopularityScore);
        Assert.False(parameters.RawBodyData.ContainsKey("popularity_score"));
        Assert.Null(parameters.SecondaryThemes);
        Assert.False(parameters.RawBodyData.ContainsKey("secondary_themes"));
        Assert.Null(parameters.Text);
        Assert.False(parameters.RawBodyData.ContainsKey("text"));
        Assert.Null(parameters.Theme);
        Assert.False(parameters.RawBodyData.ContainsKey("theme"));
        Assert.Null(parameters.TimesShared);
        Assert.False(parameters.RawBodyData.ContainsKey("times_shared"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new QuoteUpdateParams
        {
            QuoteID = "quote_id",

            CharacterID = null,
            Context = null,
            EpisodeID = null,
            IsFunny = null,
            IsInspirational = null,
            MomentType = null,
            PopularityScore = null,
            SecondaryThemes = null,
            Text = null,
            Theme = null,
            TimesShared = null,
        };

        Assert.Null(parameters.CharacterID);
        Assert.True(parameters.RawBodyData.ContainsKey("character_id"));
        Assert.Null(parameters.Context);
        Assert.True(parameters.RawBodyData.ContainsKey("context"));
        Assert.Null(parameters.EpisodeID);
        Assert.True(parameters.RawBodyData.ContainsKey("episode_id"));
        Assert.Null(parameters.IsFunny);
        Assert.True(parameters.RawBodyData.ContainsKey("is_funny"));
        Assert.Null(parameters.IsInspirational);
        Assert.True(parameters.RawBodyData.ContainsKey("is_inspirational"));
        Assert.Null(parameters.MomentType);
        Assert.True(parameters.RawBodyData.ContainsKey("moment_type"));
        Assert.Null(parameters.PopularityScore);
        Assert.True(parameters.RawBodyData.ContainsKey("popularity_score"));
        Assert.Null(parameters.SecondaryThemes);
        Assert.True(parameters.RawBodyData.ContainsKey("secondary_themes"));
        Assert.Null(parameters.Text);
        Assert.True(parameters.RawBodyData.ContainsKey("text"));
        Assert.Null(parameters.Theme);
        Assert.True(parameters.RawBodyData.ContainsKey("theme"));
        Assert.Null(parameters.TimesShared);
        Assert.True(parameters.RawBodyData.ContainsKey("times_shared"));
    }

    [Fact]
    public void Url_Works()
    {
        QuoteUpdateParams parameters = new() { QuoteID = "quote_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://believe.cjav.dev/quotes/quote_id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new QuoteUpdateParams
        {
            QuoteID = "quote_id",
            CharacterID = "character_id",
            Context = "context",
            EpisodeID = "episode_id",
            IsFunny = true,
            IsInspirational = true,
            MomentType = QuoteMoment.HalftimeSpeech,
            PopularityScore = 0,
            SecondaryThemes = [QuoteTheme.Belief],
            Text = "x",
            Theme = QuoteTheme.Belief,
            TimesShared = 0,
        };

        QuoteUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
