using System;
using Believe.Models.Teams;

namespace Believe.Tests.Models.Teams;

public class TeamGetRivalsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TeamGetRivalsParams { TeamID = "team_id" };

        string expectedTeamID = "team_id";

        Assert.Equal(expectedTeamID, parameters.TeamID);
    }

    [Fact]
    public void Url_Works()
    {
        TeamGetRivalsParams parameters = new() { TeamID = "team_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/teams/team_id/rivals"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TeamGetRivalsParams { TeamID = "team_id" };

        TeamGetRivalsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
