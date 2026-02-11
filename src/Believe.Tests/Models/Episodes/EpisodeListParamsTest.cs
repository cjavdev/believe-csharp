using System;
using Believe.Models.Episodes;

namespace Believe.Tests.Models.Episodes;

public class EpisodeListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EpisodeListParams
        {
            CharacterFocus = "character_focus",
            Limit = 10,
            Season = 1,
            Skip = 0,
        };

        string expectedCharacterFocus = "character_focus";
        long expectedLimit = 10;
        long expectedSeason = 1;
        long expectedSkip = 0;

        Assert.Equal(expectedCharacterFocus, parameters.CharacterFocus);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedSeason, parameters.Season);
        Assert.Equal(expectedSkip, parameters.Skip);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EpisodeListParams { CharacterFocus = "character_focus", Season = 1 };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EpisodeListParams
        {
            CharacterFocus = "character_focus",
            Season = 1,

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Skip = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EpisodeListParams { Limit = 10, Skip = 0 };

        Assert.Null(parameters.CharacterFocus);
        Assert.False(parameters.RawQueryData.ContainsKey("character_focus"));
        Assert.Null(parameters.Season);
        Assert.False(parameters.RawQueryData.ContainsKey("season"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EpisodeListParams
        {
            Limit = 10,
            Skip = 0,

            CharacterFocus = null,
            Season = null,
        };

        Assert.Null(parameters.CharacterFocus);
        Assert.True(parameters.RawQueryData.ContainsKey("character_focus"));
        Assert.Null(parameters.Season);
        Assert.True(parameters.RawQueryData.ContainsKey("season"));
    }

    [Fact]
    public void Url_Works()
    {
        EpisodeListParams parameters = new()
        {
            CharacterFocus = "character_focus",
            Limit = 10,
            Season = 1,
            Skip = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://believe.cjav.dev/episodes?character_focus=character_focus&limit=10&season=1&skip=0"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EpisodeListParams
        {
            CharacterFocus = "character_focus",
            Limit = 10,
            Season = 1,
            Skip = 0,
        };

        EpisodeListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
