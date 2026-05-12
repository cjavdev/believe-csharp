using System;
using Believe.Client.Models.Teams.Logo;

namespace Believe.Client.Tests.Models.Teams.Logo;

public class LogoDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new LogoDeleteParams
        {
            TeamID = "team_id",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedTeamID = "team_id";
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedTeamID, parameters.TeamID);
        Assert.Equal(expectedFileID, parameters.FileID);
    }

    [Fact]
    public void Url_Works()
    {
        LogoDeleteParams parameters = new()
        {
            TeamID = "team_id",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://believe.cjav.dev/teams/team_id/logo/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LogoDeleteParams
        {
            TeamID = "team_id",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        LogoDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
