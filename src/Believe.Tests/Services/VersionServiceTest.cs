using System.Threading.Tasks;

namespace Believe.Tests.Services;

public class VersionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        await this.client.Version.Retrieve(new(), TestContext.Current.CancellationToken);
    }
}
