using System;
using System.Text;
using Believe.Core;
using Believe.Models.Teams.Logo;

namespace Believe.Tests.Models.Teams.Logo;

public class LogoUploadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new LogoUploadParams { TeamID = "team_id", File = file };

        string expectedTeamID = "team_id";
        BinaryContent expectedFile = file;

        Assert.Equal(expectedTeamID, parameters.TeamID);
        Assert.Equal(expectedFile, parameters.File);
    }

    [Fact]
    public void Url_Works()
    {
        LogoUploadParams parameters = new()
        {
            TeamID = "team_id",
            File = Encoding.UTF8.GetBytes("Example data"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://believe.cjav.dev/teams/team_id/logo"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new LogoUploadParams
        {
            TeamID = "team_id",
            File = Encoding.UTF8.GetBytes("Example data"),
        };

        LogoUploadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
