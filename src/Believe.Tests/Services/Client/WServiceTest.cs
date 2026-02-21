using System.Threading.Tasks;

namespace Believe.Tests.Services.Client;

public class WServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Test_Works()
    {
        await this.client.Client.Ws.Test(new(), TestContext.Current.CancellationToken);
    }
}
