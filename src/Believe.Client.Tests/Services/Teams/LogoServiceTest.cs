using System.Text;
using System.Threading.Tasks;

namespace Believe.Client.Tests.Services.Teams;

public class LogoServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Teams.Logo.Delete(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { TeamID = "team_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Download_Works()
    {
        await this.client.Teams.Logo.Download(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new() { TeamID = "team_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upload_Works()
    {
        var fileUpload = await this.client.Teams.Logo.Upload(
            "team_id",
            new() { File = Encoding.UTF8.GetBytes("Example data") },
            TestContext.Current.CancellationToken
        );
        fileUpload.Validate();
    }
}
