using System;
using Believe.Models.Teams;

namespace Believe.Tests.Models.Teams;

public class TeamDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TeamDeleteParams { TeamID = "team_id" };

        string expectedTeamID = "team_id";

        Assert.Equal(expectedTeamID, parameters.TeamID);
    }

    [Fact]
    public void Url_Works()
    {
        TeamDeleteParams parameters = new() { TeamID = "team_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/teams/team_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TeamDeleteParams { TeamID = "team_id" };

        TeamDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
