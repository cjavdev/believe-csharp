using System;
using Believe.Client.Models.Teams;

namespace Believe.Client.Tests.Models.Teams;

public class TeamRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TeamRetrieveParams { TeamID = "team_id" };

        string expectedTeamID = "team_id";

        Assert.Equal(expectedTeamID, parameters.TeamID);
    }

    [Fact]
    public void Url_Works()
    {
        TeamRetrieveParams parameters = new() { TeamID = "team_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://believe.cjav.dev/teams/team_id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TeamRetrieveParams { TeamID = "team_id" };

        TeamRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
