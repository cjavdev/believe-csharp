using System;
using Believe.Models.Matches;

namespace Believe.Tests.Models.Matches;

public class MatchStreamLiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MatchStreamLiveParams
        {
            AwayTeam = "away_team",
            ExcitementLevel = 1,
            HomeTeam = "home_team",
            Speed = 0.1,
        };

        string expectedAwayTeam = "away_team";
        long expectedExcitementLevel = 1;
        string expectedHomeTeam = "home_team";
        double expectedSpeed = 0.1;

        Assert.Equal(expectedAwayTeam, parameters.AwayTeam);
        Assert.Equal(expectedExcitementLevel, parameters.ExcitementLevel);
        Assert.Equal(expectedHomeTeam, parameters.HomeTeam);
        Assert.Equal(expectedSpeed, parameters.Speed);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MatchStreamLiveParams { };

        Assert.Null(parameters.AwayTeam);
        Assert.False(parameters.RawQueryData.ContainsKey("away_team"));
        Assert.Null(parameters.ExcitementLevel);
        Assert.False(parameters.RawQueryData.ContainsKey("excitement_level"));
        Assert.Null(parameters.HomeTeam);
        Assert.False(parameters.RawQueryData.ContainsKey("home_team"));
        Assert.Null(parameters.Speed);
        Assert.False(parameters.RawQueryData.ContainsKey("speed"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MatchStreamLiveParams
        {
            // Null should be interpreted as omitted for these properties
            AwayTeam = null,
            ExcitementLevel = null,
            HomeTeam = null,
            Speed = null,
        };

        Assert.Null(parameters.AwayTeam);
        Assert.False(parameters.RawQueryData.ContainsKey("away_team"));
        Assert.Null(parameters.ExcitementLevel);
        Assert.False(parameters.RawQueryData.ContainsKey("excitement_level"));
        Assert.Null(parameters.HomeTeam);
        Assert.False(parameters.RawQueryData.ContainsKey("home_team"));
        Assert.Null(parameters.Speed);
        Assert.False(parameters.RawQueryData.ContainsKey("speed"));
    }

    [Fact]
    public void Url_Works()
    {
        MatchStreamLiveParams parameters = new()
        {
            AwayTeam = "away_team",
            ExcitementLevel = 1,
            HomeTeam = "home_team",
            Speed = 0.1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://believe.cjav.dev/matches/live?away_team=away_team&excitement_level=1&home_team=home_team&speed=0.1"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MatchStreamLiveParams
        {
            AwayTeam = "away_team",
            ExcitementLevel = 1,
            HomeTeam = "home_team",
            Speed = 0.1,
        };

        MatchStreamLiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
