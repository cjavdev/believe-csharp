using System;
using Believe.Core;
using Believe.Models.Matches;

namespace Believe.Tests.Models.Matches;

public class MatchListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {


        var parameters = new MatchListParams
        {
            Limit = 10,MatchType = MatchType.League,Result = MatchResult.Win,Skip = 0,TeamID = "team_id",
        };

        long expectedLimit = 10;
        ApiEnum<string, MatchType> expectedMatchType = MatchType.League;
        ApiEnum<string, MatchResult> expectedResult = MatchResult.Win;
        long expectedSkip = 0;
        string expectedTeamID = "team_id";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMatchType, parameters.MatchType);
        Assert.Equal(expectedResult, parameters.Result);
        Assert.Equal(expectedSkip, parameters.Skip);
        Assert.Equal(expectedTeamID, parameters.TeamID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {


        var parameters = new MatchListParams
        {
            MatchType = MatchType.League,Result = MatchResult.Win,TeamID = "team_id",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));

    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {


        var parameters = new MatchListParams
        {
            MatchType = MatchType.League,Result = MatchResult.Win,TeamID = "team_id",

            // Null should be interpreted as omitted for these properties
            Limit = null,Skip = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));

    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {


        var parameters = new MatchListParams
        {
            Limit = 10,Skip = 0,
        };

        Assert.Null(parameters.MatchType);
        Assert.False(parameters.RawQueryData.ContainsKey("match_type"));Assert.Null(parameters.Result);
        Assert.False(parameters.RawQueryData.ContainsKey("result"));Assert.Null(parameters.TeamID);
        Assert.False(parameters.RawQueryData.ContainsKey("team_id"));

    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {


        var parameters = new MatchListParams
        {
            Limit = 10,Skip = 0,

            MatchType = null,Result = null,TeamID = null,
        };

        Assert.Null(parameters.MatchType);
        Assert.True(parameters.RawQueryData.ContainsKey("match_type"));Assert.Null(parameters.Result);
        Assert.True(parameters.RawQueryData.ContainsKey("result"));Assert.Null(parameters.TeamID);
        Assert.True(parameters.RawQueryData.ContainsKey("team_id"));

    }

    [Fact]
    public void Url_Works()
    {
        MatchListParams parameters = new()
        {
            Limit = 10,
            MatchType = MatchType.League,
            Result = MatchResult.Win,
            Skip = 0,
            TeamID = "team_id",
        };

        var url = parameters.Url(
            new()
            {
                ApiKey = "My API Key"
            }
        );

        Assert.Equal(new Uri("https://believe.cjav.dev/matches?limit=10&match_type=league&result=win&skip=0&team_id=team_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MatchListParams
        {
            Limit = 10,
            MatchType = MatchType.League,
            Result = MatchResult.Win,
            Skip = 0,
            TeamID = "team_id",
        };

        MatchListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}