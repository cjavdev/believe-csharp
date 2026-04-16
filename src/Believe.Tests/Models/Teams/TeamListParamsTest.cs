using System;
using Believe.Core;
using Believe.Models.Teams;

namespace Believe.Tests.Models.Teams;

public class TeamListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TeamListParams
        {
            League = League.PremierLeague,
            Limit = 10,
            MinCultureScore = 0,
            Skip = 0,
        };

        ApiEnum<string, League> expectedLeague = League.PremierLeague;
        long expectedLimit = 10;
        long expectedMinCultureScore = 0;
        long expectedSkip = 0;

        Assert.Equal(expectedLeague, parameters.League);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMinCultureScore, parameters.MinCultureScore);
        Assert.Equal(expectedSkip, parameters.Skip);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TeamListParams { League = League.PremierLeague, MinCultureScore = 0 };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TeamListParams
        {
            League = League.PremierLeague,
            MinCultureScore = 0,

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
        var parameters = new TeamListParams { Limit = 10, Skip = 0 };

        Assert.Null(parameters.League);
        Assert.False(parameters.RawQueryData.ContainsKey("league"));
        Assert.Null(parameters.MinCultureScore);
        Assert.False(parameters.RawQueryData.ContainsKey("min_culture_score"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TeamListParams
        {
            Limit = 10,
            Skip = 0,

            League = null,
            MinCultureScore = null,
        };

        Assert.Null(parameters.League);
        Assert.True(parameters.RawQueryData.ContainsKey("league"));
        Assert.Null(parameters.MinCultureScore);
        Assert.True(parameters.RawQueryData.ContainsKey("min_culture_score"));
    }

    [Fact]
    public void Url_Works()
    {
        TeamListParams parameters = new()
        {
            League = League.PremierLeague,
            Limit = 10,
            MinCultureScore = 0,
            Skip = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://believe.cjav.dev/teams?league=Premier+League&limit=10&min_culture_score=0&skip=0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TeamListParams
        {
            League = League.PremierLeague,
            Limit = 10,
            MinCultureScore = 0,
            Skip = 0,
        };

        TeamListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
