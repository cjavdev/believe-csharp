using System;
using System.Text;
using Believe.Models.Teams.Logo;

namespace Believe.Tests.Models.Teams.Logo;

public class LogoUploadParamsTest : TestBase
{
    [Fact]
    public void Url_Works()
    {
        LogoUploadParams parameters = new()
        {
            TeamID = "team_id",
            File = Encoding.UTF8.GetBytes("text"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/teams/team_id/logo"), url);
    }
}
