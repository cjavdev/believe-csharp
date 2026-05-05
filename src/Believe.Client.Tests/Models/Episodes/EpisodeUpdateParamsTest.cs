using System;
using System.Collections.Generic;
using Believe.Client.Models.Episodes;

namespace Believe.Client.Tests.Models.Episodes;

public class EpisodeUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EpisodeUpdateParams
        {
            EpisodeID = "episode_id",
            AirDate = "2019-12-27",
            BiscuitsWithBossMoment = "biscuits_with_boss_moment",
            CharacterFocus = ["string"],
            Director = "director",
            EpisodeNumber = 1,
            MainTheme = "main_theme",
            MemorableMoments = ["string"],
            RuntimeMinutes = 20,
            Season = 1,
            Synopsis = "synopsis",
            TedWisdom = "ted_wisdom",
            Title = "x",
            UsViewersMillions = 0,
            ViewerRating = 0,
            Writer = "writer",
        };

        string expectedEpisodeID = "episode_id";
        string expectedAirDate = "2019-12-27";
        string expectedBiscuitsWithBossMoment = "biscuits_with_boss_moment";
        List<string> expectedCharacterFocus = ["string"];
        string expectedDirector = "director";
        long expectedEpisodeNumber = 1;
        string expectedMainTheme = "main_theme";
        List<string> expectedMemorableMoments = ["string"];
        long expectedRuntimeMinutes = 20;
        long expectedSeason = 1;
        string expectedSynopsis = "synopsis";
        string expectedTedWisdom = "ted_wisdom";
        string expectedTitle = "x";
        double expectedUsViewersMillions = 0;
        double expectedViewerRating = 0;
        string expectedWriter = "writer";

        Assert.Equal(expectedEpisodeID, parameters.EpisodeID);
        Assert.Equal(expectedAirDate, parameters.AirDate);
        Assert.Equal(expectedBiscuitsWithBossMoment, parameters.BiscuitsWithBossMoment);
        Assert.NotNull(parameters.CharacterFocus);
        Assert.Equal(expectedCharacterFocus.Count, parameters.CharacterFocus.Count);
        for (int i = 0; i < expectedCharacterFocus.Count; i++)
        {
            Assert.Equal(expectedCharacterFocus[i], parameters.CharacterFocus[i]);
        }
        Assert.Equal(expectedDirector, parameters.Director);
        Assert.Equal(expectedEpisodeNumber, parameters.EpisodeNumber);
        Assert.Equal(expectedMainTheme, parameters.MainTheme);
        Assert.NotNull(parameters.MemorableMoments);
        Assert.Equal(expectedMemorableMoments.Count, parameters.MemorableMoments.Count);
        for (int i = 0; i < expectedMemorableMoments.Count; i++)
        {
            Assert.Equal(expectedMemorableMoments[i], parameters.MemorableMoments[i]);
        }
        Assert.Equal(expectedRuntimeMinutes, parameters.RuntimeMinutes);
        Assert.Equal(expectedSeason, parameters.Season);
        Assert.Equal(expectedSynopsis, parameters.Synopsis);
        Assert.Equal(expectedTedWisdom, parameters.TedWisdom);
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedUsViewersMillions, parameters.UsViewersMillions);
        Assert.Equal(expectedViewerRating, parameters.ViewerRating);
        Assert.Equal(expectedWriter, parameters.Writer);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EpisodeUpdateParams { EpisodeID = "episode_id" };

        Assert.Null(parameters.AirDate);
        Assert.False(parameters.RawBodyData.ContainsKey("air_date"));
        Assert.Null(parameters.BiscuitsWithBossMoment);
        Assert.False(parameters.RawBodyData.ContainsKey("biscuits_with_boss_moment"));
        Assert.Null(parameters.CharacterFocus);
        Assert.False(parameters.RawBodyData.ContainsKey("character_focus"));
        Assert.Null(parameters.Director);
        Assert.False(parameters.RawBodyData.ContainsKey("director"));
        Assert.Null(parameters.EpisodeNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("episode_number"));
        Assert.Null(parameters.MainTheme);
        Assert.False(parameters.RawBodyData.ContainsKey("main_theme"));
        Assert.Null(parameters.MemorableMoments);
        Assert.False(parameters.RawBodyData.ContainsKey("memorable_moments"));
        Assert.Null(parameters.RuntimeMinutes);
        Assert.False(parameters.RawBodyData.ContainsKey("runtime_minutes"));
        Assert.Null(parameters.Season);
        Assert.False(parameters.RawBodyData.ContainsKey("season"));
        Assert.Null(parameters.Synopsis);
        Assert.False(parameters.RawBodyData.ContainsKey("synopsis"));
        Assert.Null(parameters.TedWisdom);
        Assert.False(parameters.RawBodyData.ContainsKey("ted_wisdom"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.UsViewersMillions);
        Assert.False(parameters.RawBodyData.ContainsKey("us_viewers_millions"));
        Assert.Null(parameters.ViewerRating);
        Assert.False(parameters.RawBodyData.ContainsKey("viewer_rating"));
        Assert.Null(parameters.Writer);
        Assert.False(parameters.RawBodyData.ContainsKey("writer"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EpisodeUpdateParams
        {
            EpisodeID = "episode_id",

            AirDate = null,
            BiscuitsWithBossMoment = null,
            CharacterFocus = null,
            Director = null,
            EpisodeNumber = null,
            MainTheme = null,
            MemorableMoments = null,
            RuntimeMinutes = null,
            Season = null,
            Synopsis = null,
            TedWisdom = null,
            Title = null,
            UsViewersMillions = null,
            ViewerRating = null,
            Writer = null,
        };

        Assert.Null(parameters.AirDate);
        Assert.True(parameters.RawBodyData.ContainsKey("air_date"));
        Assert.Null(parameters.BiscuitsWithBossMoment);
        Assert.True(parameters.RawBodyData.ContainsKey("biscuits_with_boss_moment"));
        Assert.Null(parameters.CharacterFocus);
        Assert.True(parameters.RawBodyData.ContainsKey("character_focus"));
        Assert.Null(parameters.Director);
        Assert.True(parameters.RawBodyData.ContainsKey("director"));
        Assert.Null(parameters.EpisodeNumber);
        Assert.True(parameters.RawBodyData.ContainsKey("episode_number"));
        Assert.Null(parameters.MainTheme);
        Assert.True(parameters.RawBodyData.ContainsKey("main_theme"));
        Assert.Null(parameters.MemorableMoments);
        Assert.True(parameters.RawBodyData.ContainsKey("memorable_moments"));
        Assert.Null(parameters.RuntimeMinutes);
        Assert.True(parameters.RawBodyData.ContainsKey("runtime_minutes"));
        Assert.Null(parameters.Season);
        Assert.True(parameters.RawBodyData.ContainsKey("season"));
        Assert.Null(parameters.Synopsis);
        Assert.True(parameters.RawBodyData.ContainsKey("synopsis"));
        Assert.Null(parameters.TedWisdom);
        Assert.True(parameters.RawBodyData.ContainsKey("ted_wisdom"));
        Assert.Null(parameters.Title);
        Assert.True(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.UsViewersMillions);
        Assert.True(parameters.RawBodyData.ContainsKey("us_viewers_millions"));
        Assert.Null(parameters.ViewerRating);
        Assert.True(parameters.RawBodyData.ContainsKey("viewer_rating"));
        Assert.Null(parameters.Writer);
        Assert.True(parameters.RawBodyData.ContainsKey("writer"));
    }

    [Fact]
    public void Url_Works()
    {
        EpisodeUpdateParams parameters = new() { EpisodeID = "episode_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://believe.cjav.dev/episodes/episode_id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EpisodeUpdateParams
        {
            EpisodeID = "episode_id",
            AirDate = "2019-12-27",
            BiscuitsWithBossMoment = "biscuits_with_boss_moment",
            CharacterFocus = ["string"],
            Director = "director",
            EpisodeNumber = 1,
            MainTheme = "main_theme",
            MemorableMoments = ["string"],
            RuntimeMinutes = 20,
            Season = 1,
            Synopsis = "synopsis",
            TedWisdom = "ted_wisdom",
            Title = "x",
            UsViewersMillions = 0,
            ViewerRating = 0,
            Writer = "writer",
        };

        EpisodeUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
