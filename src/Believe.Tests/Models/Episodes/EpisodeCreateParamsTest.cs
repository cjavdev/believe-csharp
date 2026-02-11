using System;
using System.Collections.Generic;
using Believe.Models.Episodes;

namespace Believe.Tests.Models.Episodes;

public class EpisodeCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EpisodeCreateParams
        {
            AirDate = "2020-10-02",
            CharacterFocus = ["ted-lasso", "coach-beard", "higgins", "nate"],
            Director = "MJ Delaney",
            EpisodeNumber = 8,
            MainTheme = "The power of vulnerability and male friendship",
            RuntimeMinutes = 29,
            Season = 1,
            Synopsis =
                "Ted creates a support group for the coaching staff while Rebecca faces a difficult decision about her future.",
            TedWisdom = "There's two buttons I never like to hit: that's panic and snooze.",
            Title = "The Diamond Dogs",
            Writer = "Jason Sudeikis, Brendan Hunt, Joe Kelly",
            BiscuitsWithBossMoment = "Ted and Rebecca have an honest conversation about trust.",
            MemorableMoments =
            [
                "First Diamond Dogs meeting",
                "The famous dart scene with Rupert",
                "Be curious, not judgmental speech",
            ],
            UsViewersMillions = 1.42,
            ViewerRating = 9.1,
        };

        string expectedAirDate = "2020-10-02";
        List<string> expectedCharacterFocus = ["ted-lasso", "coach-beard", "higgins", "nate"];
        string expectedDirector = "MJ Delaney";
        long expectedEpisodeNumber = 8;
        string expectedMainTheme = "The power of vulnerability and male friendship";
        long expectedRuntimeMinutes = 29;
        long expectedSeason = 1;
        string expectedSynopsis =
            "Ted creates a support group for the coaching staff while Rebecca faces a difficult decision about her future.";
        string expectedTedWisdom =
            "There's two buttons I never like to hit: that's panic and snooze.";
        string expectedTitle = "The Diamond Dogs";
        string expectedWriter = "Jason Sudeikis, Brendan Hunt, Joe Kelly";
        string expectedBiscuitsWithBossMoment =
            "Ted and Rebecca have an honest conversation about trust.";
        List<string> expectedMemorableMoments =
        [
            "First Diamond Dogs meeting",
            "The famous dart scene with Rupert",
            "Be curious, not judgmental speech",
        ];
        double expectedUsViewersMillions = 1.42;
        double expectedViewerRating = 9.1;

        Assert.Equal(expectedAirDate, parameters.AirDate);
        Assert.Equal(expectedCharacterFocus.Count, parameters.CharacterFocus.Count);
        for (int i = 0; i < expectedCharacterFocus.Count; i++)
        {
            Assert.Equal(expectedCharacterFocus[i], parameters.CharacterFocus[i]);
        }
        Assert.Equal(expectedDirector, parameters.Director);
        Assert.Equal(expectedEpisodeNumber, parameters.EpisodeNumber);
        Assert.Equal(expectedMainTheme, parameters.MainTheme);
        Assert.Equal(expectedRuntimeMinutes, parameters.RuntimeMinutes);
        Assert.Equal(expectedSeason, parameters.Season);
        Assert.Equal(expectedSynopsis, parameters.Synopsis);
        Assert.Equal(expectedTedWisdom, parameters.TedWisdom);
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedWriter, parameters.Writer);
        Assert.Equal(expectedBiscuitsWithBossMoment, parameters.BiscuitsWithBossMoment);
        Assert.NotNull(parameters.MemorableMoments);
        Assert.Equal(expectedMemorableMoments.Count, parameters.MemorableMoments.Count);
        for (int i = 0; i < expectedMemorableMoments.Count; i++)
        {
            Assert.Equal(expectedMemorableMoments[i], parameters.MemorableMoments[i]);
        }
        Assert.Equal(expectedUsViewersMillions, parameters.UsViewersMillions);
        Assert.Equal(expectedViewerRating, parameters.ViewerRating);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EpisodeCreateParams
        {
            AirDate = "2020-10-02",
            CharacterFocus = ["ted-lasso", "coach-beard", "higgins", "nate"],
            Director = "MJ Delaney",
            EpisodeNumber = 8,
            MainTheme = "The power of vulnerability and male friendship",
            RuntimeMinutes = 29,
            Season = 1,
            Synopsis =
                "Ted creates a support group for the coaching staff while Rebecca faces a difficult decision about her future.",
            TedWisdom = "There's two buttons I never like to hit: that's panic and snooze.",
            Title = "The Diamond Dogs",
            Writer = "Jason Sudeikis, Brendan Hunt, Joe Kelly",
            BiscuitsWithBossMoment = "Ted and Rebecca have an honest conversation about trust.",
            UsViewersMillions = 1.42,
            ViewerRating = 9.1,
        };

        Assert.Null(parameters.MemorableMoments);
        Assert.False(parameters.RawBodyData.ContainsKey("memorable_moments"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EpisodeCreateParams
        {
            AirDate = "2020-10-02",
            CharacterFocus = ["ted-lasso", "coach-beard", "higgins", "nate"],
            Director = "MJ Delaney",
            EpisodeNumber = 8,
            MainTheme = "The power of vulnerability and male friendship",
            RuntimeMinutes = 29,
            Season = 1,
            Synopsis =
                "Ted creates a support group for the coaching staff while Rebecca faces a difficult decision about her future.",
            TedWisdom = "There's two buttons I never like to hit: that's panic and snooze.",
            Title = "The Diamond Dogs",
            Writer = "Jason Sudeikis, Brendan Hunt, Joe Kelly",
            BiscuitsWithBossMoment = "Ted and Rebecca have an honest conversation about trust.",
            UsViewersMillions = 1.42,
            ViewerRating = 9.1,

            // Null should be interpreted as omitted for these properties
            MemorableMoments = null,
        };

        Assert.Null(parameters.MemorableMoments);
        Assert.False(parameters.RawBodyData.ContainsKey("memorable_moments"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EpisodeCreateParams
        {
            AirDate = "2020-10-02",
            CharacterFocus = ["ted-lasso", "coach-beard", "higgins", "nate"],
            Director = "MJ Delaney",
            EpisodeNumber = 8,
            MainTheme = "The power of vulnerability and male friendship",
            RuntimeMinutes = 29,
            Season = 1,
            Synopsis =
                "Ted creates a support group for the coaching staff while Rebecca faces a difficult decision about her future.",
            TedWisdom = "There's two buttons I never like to hit: that's panic and snooze.",
            Title = "The Diamond Dogs",
            Writer = "Jason Sudeikis, Brendan Hunt, Joe Kelly",
            MemorableMoments =
            [
                "First Diamond Dogs meeting",
                "The famous dart scene with Rupert",
                "Be curious, not judgmental speech",
            ],
        };

        Assert.Null(parameters.BiscuitsWithBossMoment);
        Assert.False(parameters.RawBodyData.ContainsKey("biscuits_with_boss_moment"));
        Assert.Null(parameters.UsViewersMillions);
        Assert.False(parameters.RawBodyData.ContainsKey("us_viewers_millions"));
        Assert.Null(parameters.ViewerRating);
        Assert.False(parameters.RawBodyData.ContainsKey("viewer_rating"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EpisodeCreateParams
        {
            AirDate = "2020-10-02",
            CharacterFocus = ["ted-lasso", "coach-beard", "higgins", "nate"],
            Director = "MJ Delaney",
            EpisodeNumber = 8,
            MainTheme = "The power of vulnerability and male friendship",
            RuntimeMinutes = 29,
            Season = 1,
            Synopsis =
                "Ted creates a support group for the coaching staff while Rebecca faces a difficult decision about her future.",
            TedWisdom = "There's two buttons I never like to hit: that's panic and snooze.",
            Title = "The Diamond Dogs",
            Writer = "Jason Sudeikis, Brendan Hunt, Joe Kelly",
            MemorableMoments =
            [
                "First Diamond Dogs meeting",
                "The famous dart scene with Rupert",
                "Be curious, not judgmental speech",
            ],

            BiscuitsWithBossMoment = null,
            UsViewersMillions = null,
            ViewerRating = null,
        };

        Assert.Null(parameters.BiscuitsWithBossMoment);
        Assert.True(parameters.RawBodyData.ContainsKey("biscuits_with_boss_moment"));
        Assert.Null(parameters.UsViewersMillions);
        Assert.True(parameters.RawBodyData.ContainsKey("us_viewers_millions"));
        Assert.Null(parameters.ViewerRating);
        Assert.True(parameters.RawBodyData.ContainsKey("viewer_rating"));
    }

    [Fact]
    public void Url_Works()
    {
        EpisodeCreateParams parameters = new()
        {
            AirDate = "2020-10-02",
            CharacterFocus = ["ted-lasso", "coach-beard", "higgins", "nate"],
            Director = "MJ Delaney",
            EpisodeNumber = 8,
            MainTheme = "The power of vulnerability and male friendship",
            RuntimeMinutes = 29,
            Season = 1,
            Synopsis =
                "Ted creates a support group for the coaching staff while Rebecca faces a difficult decision about her future.",
            TedWisdom = "There's two buttons I never like to hit: that's panic and snooze.",
            Title = "The Diamond Dogs",
            Writer = "Jason Sudeikis, Brendan Hunt, Joe Kelly",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/episodes"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EpisodeCreateParams
        {
            AirDate = "2020-10-02",
            CharacterFocus = ["ted-lasso", "coach-beard", "higgins", "nate"],
            Director = "MJ Delaney",
            EpisodeNumber = 8,
            MainTheme = "The power of vulnerability and male friendship",
            RuntimeMinutes = 29,
            Season = 1,
            Synopsis =
                "Ted creates a support group for the coaching staff while Rebecca faces a difficult decision about her future.",
            TedWisdom = "There's two buttons I never like to hit: that's panic and snooze.",
            Title = "The Diamond Dogs",
            Writer = "Jason Sudeikis, Brendan Hunt, Joe Kelly",
            BiscuitsWithBossMoment = "Ted and Rebecca have an honest conversation about trust.",
            MemorableMoments =
            [
                "First Diamond Dogs meeting",
                "The famous dart scene with Rupert",
                "Be curious, not judgmental speech",
            ],
            UsViewersMillions = 1.42,
            ViewerRating = 9.1,
        };

        EpisodeCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
