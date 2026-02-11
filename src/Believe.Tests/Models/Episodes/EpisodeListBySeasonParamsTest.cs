using System;
using Believe.Models.Episodes;

namespace Believe.Tests.Models.Episodes;

public class EpisodeListBySeasonParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EpisodeListBySeasonParams
        {
            SeasonNumber = 0,
            Limit = 10,
            Skip = 0,
        };

        long expectedSeasonNumber = 0;
        long expectedLimit = 10;
        long expectedSkip = 0;

        Assert.Equal(expectedSeasonNumber, parameters.SeasonNumber);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedSkip, parameters.Skip);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EpisodeListBySeasonParams { SeasonNumber = 0 };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EpisodeListBySeasonParams
        {
            SeasonNumber = 0,

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
    public void Url_Works()
    {
        EpisodeListBySeasonParams parameters = new()
        {
            SeasonNumber = 0,
            Limit = 10,
            Skip = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/episodes/seasons/0?limit=10&skip=0"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EpisodeListBySeasonParams
        {
            SeasonNumber = 0,
            Limit = 10,
            Skip = 0,
        };

        EpisodeListBySeasonParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
