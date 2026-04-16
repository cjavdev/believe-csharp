using System;
using System.Collections.Generic;
using Believe.Core;
using Believe.Models.Quotes;

namespace Believe.Tests.Models.Quotes;

public class QuoteCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new QuoteCreateParams
        {
            CharacterID = "ted-lasso",
            Context = "Ted's first team meeting, revealing his coaching philosophy",
            MomentType = QuoteMoment.LockerRoom,
            Text = "I believe in believe.",
            Theme = QuoteTheme.Belief,
            EpisodeID = "s01e01",
            IsFunny = false,
            IsInspirational = true,
            PopularityScore = 98.5,
            SecondaryThemes = [QuoteTheme.Leadership, QuoteTheme.Teamwork],
            TimesShared = 250000,
        };

        string expectedCharacterID = "ted-lasso";
        string expectedContext = "Ted's first team meeting, revealing his coaching philosophy";
        ApiEnum<string, QuoteMoment> expectedMomentType = QuoteMoment.LockerRoom;
        string expectedText = "I believe in believe.";
        ApiEnum<string, QuoteTheme> expectedTheme = QuoteTheme.Belief;
        string expectedEpisodeID = "s01e01";
        bool expectedIsFunny = false;
        bool expectedIsInspirational = true;
        double expectedPopularityScore = 98.5;
        List<ApiEnum<string, QuoteTheme>> expectedSecondaryThemes =
        [
            QuoteTheme.Leadership,
            QuoteTheme.Teamwork,
        ];
        long expectedTimesShared = 250000;

        Assert.Equal(expectedCharacterID, parameters.CharacterID);
        Assert.Equal(expectedContext, parameters.Context);
        Assert.Equal(expectedMomentType, parameters.MomentType);
        Assert.Equal(expectedText, parameters.Text);
        Assert.Equal(expectedTheme, parameters.Theme);
        Assert.Equal(expectedEpisodeID, parameters.EpisodeID);
        Assert.Equal(expectedIsFunny, parameters.IsFunny);
        Assert.Equal(expectedIsInspirational, parameters.IsInspirational);
        Assert.Equal(expectedPopularityScore, parameters.PopularityScore);
        Assert.NotNull(parameters.SecondaryThemes);
        Assert.Equal(expectedSecondaryThemes.Count, parameters.SecondaryThemes.Count);
        for (int i = 0; i < expectedSecondaryThemes.Count; i++)
        {
            Assert.Equal(expectedSecondaryThemes[i], parameters.SecondaryThemes[i]);
        }
        Assert.Equal(expectedTimesShared, parameters.TimesShared);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new QuoteCreateParams
        {
            CharacterID = "ted-lasso",
            Context = "Ted's first team meeting, revealing his coaching philosophy",
            MomentType = QuoteMoment.LockerRoom,
            Text = "I believe in believe.",
            Theme = QuoteTheme.Belief,
            EpisodeID = "s01e01",
            PopularityScore = 98.5,
            TimesShared = 250000,
        };

        Assert.Null(parameters.IsFunny);
        Assert.False(parameters.RawBodyData.ContainsKey("is_funny"));
        Assert.Null(parameters.IsInspirational);
        Assert.False(parameters.RawBodyData.ContainsKey("is_inspirational"));
        Assert.Null(parameters.SecondaryThemes);
        Assert.False(parameters.RawBodyData.ContainsKey("secondary_themes"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new QuoteCreateParams
        {
            CharacterID = "ted-lasso",
            Context = "Ted's first team meeting, revealing his coaching philosophy",
            MomentType = QuoteMoment.LockerRoom,
            Text = "I believe in believe.",
            Theme = QuoteTheme.Belief,
            EpisodeID = "s01e01",
            PopularityScore = 98.5,
            TimesShared = 250000,

            // Null should be interpreted as omitted for these properties
            IsFunny = null,
            IsInspirational = null,
            SecondaryThemes = null,
        };

        Assert.Null(parameters.IsFunny);
        Assert.False(parameters.RawBodyData.ContainsKey("is_funny"));
        Assert.Null(parameters.IsInspirational);
        Assert.False(parameters.RawBodyData.ContainsKey("is_inspirational"));
        Assert.Null(parameters.SecondaryThemes);
        Assert.False(parameters.RawBodyData.ContainsKey("secondary_themes"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new QuoteCreateParams
        {
            CharacterID = "ted-lasso",
            Context = "Ted's first team meeting, revealing his coaching philosophy",
            MomentType = QuoteMoment.LockerRoom,
            Text = "I believe in believe.",
            Theme = QuoteTheme.Belief,
            IsFunny = false,
            IsInspirational = true,
            SecondaryThemes = [QuoteTheme.Leadership, QuoteTheme.Teamwork],
        };

        Assert.Null(parameters.EpisodeID);
        Assert.False(parameters.RawBodyData.ContainsKey("episode_id"));
        Assert.Null(parameters.PopularityScore);
        Assert.False(parameters.RawBodyData.ContainsKey("popularity_score"));
        Assert.Null(parameters.TimesShared);
        Assert.False(parameters.RawBodyData.ContainsKey("times_shared"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new QuoteCreateParams
        {
            CharacterID = "ted-lasso",
            Context = "Ted's first team meeting, revealing his coaching philosophy",
            MomentType = QuoteMoment.LockerRoom,
            Text = "I believe in believe.",
            Theme = QuoteTheme.Belief,
            IsFunny = false,
            IsInspirational = true,
            SecondaryThemes = [QuoteTheme.Leadership, QuoteTheme.Teamwork],

            EpisodeID = null,
            PopularityScore = null,
            TimesShared = null,
        };

        Assert.Null(parameters.EpisodeID);
        Assert.True(parameters.RawBodyData.ContainsKey("episode_id"));
        Assert.Null(parameters.PopularityScore);
        Assert.True(parameters.RawBodyData.ContainsKey("popularity_score"));
        Assert.Null(parameters.TimesShared);
        Assert.True(parameters.RawBodyData.ContainsKey("times_shared"));
    }

    [Fact]
    public void Url_Works()
    {
        QuoteCreateParams parameters = new()
        {
            CharacterID = "ted-lasso",
            Context = "Ted's first team meeting, revealing his coaching philosophy",
            MomentType = QuoteMoment.LockerRoom,
            Text = "I believe in believe.",
            Theme = QuoteTheme.Belief,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://believe.cjav.dev/quotes"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new QuoteCreateParams
        {
            CharacterID = "ted-lasso",
            Context = "Ted's first team meeting, revealing his coaching philosophy",
            MomentType = QuoteMoment.LockerRoom,
            Text = "I believe in believe.",
            Theme = QuoteTheme.Belief,
            EpisodeID = "s01e01",
            IsFunny = false,
            IsInspirational = true,
            PopularityScore = 98.5,
            SecondaryThemes = [QuoteTheme.Leadership, QuoteTheme.Teamwork],
            TimesShared = 250000,
        };

        QuoteCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
