using System;
using Believe.Models.Teams;

namespace Believe.Tests.Models.Teams;

public class TeamGetCultureParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TeamGetCultureParams { TeamID = "team_id" };

        string expectedTeamID = "team_id";

        Assert.Equal(expectedTeamID, parameters.TeamID);
    }

    [Fact]
    public void Url_Works()
    {
        TeamGetCultureParams parameters = new() { TeamID = "team_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/teams/team_id/culture"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TeamGetCultureParams { TeamID = "team_id" };

        TeamGetCultureParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
