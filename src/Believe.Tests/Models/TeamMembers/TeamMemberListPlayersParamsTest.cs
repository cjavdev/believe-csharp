using System;
using Believe.Core;
using Believe.Models.TeamMembers;

namespace Believe.Tests.Models.TeamMembers;

public class TeamMemberListPlayersParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {


        var parameters = new TeamMemberListPlayersParams
        {
            Limit = 10,Position = Position.Goalkeeper,Skip = 0,TeamID = "team_id",
        };

        long expectedLimit = 10;
        ApiEnum<string, Position> expectedPosition = Position.Goalkeeper;
        long expectedSkip = 0;
        string expectedTeamID = "team_id";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPosition, parameters.Position);
        Assert.Equal(expectedSkip, parameters.Skip);
        Assert.Equal(expectedTeamID, parameters.TeamID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {


        var parameters = new TeamMemberListPlayersParams
        {
            Position = Position.Goalkeeper,TeamID = "team_id",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));

    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {


        var parameters = new TeamMemberListPlayersParams
        {
            Position = Position.Goalkeeper,TeamID = "team_id",

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


        var parameters = new TeamMemberListPlayersParams
        {
            Limit = 10,Skip = 0,
        };

        Assert.Null(parameters.Position);
        Assert.False(parameters.RawQueryData.ContainsKey("position"));Assert.Null(parameters.TeamID);
        Assert.False(parameters.RawQueryData.ContainsKey("team_id"));

    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {


        var parameters = new TeamMemberListPlayersParams
        {
            Limit = 10,Skip = 0,

            Position = null,TeamID = null,
        };

        Assert.Null(parameters.Position);
        Assert.True(parameters.RawQueryData.ContainsKey("position"));Assert.Null(parameters.TeamID);
        Assert.True(parameters.RawQueryData.ContainsKey("team_id"));

    }

    [Fact]
    public void Url_Works()
    {
        TeamMemberListPlayersParams parameters = new()
        {
            Limit = 10,
            Position = Position.Goalkeeper,
            Skip = 0,
            TeamID = "team_id",
        };

        var url = parameters.Url(
            new()
            {
                ApiKey = "My API Key"
            }
        );

        Assert.Equal(new Uri("https://believe.cjav.dev/team-members/players/?limit=10&position=goalkeeper&skip=0&team_id=team_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TeamMemberListPlayersParams
        {
            Limit = 10,
            Position = Position.Goalkeeper,
            Skip = 0,
            TeamID = "team_id",
        };

        TeamMemberListPlayersParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}