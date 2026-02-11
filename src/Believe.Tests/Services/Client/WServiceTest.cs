using System.Threading.Tasks;

namespace Believe.Tests.Services.Client;

public class WServiceTest : TestBase
{
    [Fact(Skip = "Prism doesn't support callbacks yet")]
    public async Task Test_Works()
    {
        await this.client.Client.Ws.Test(new(), TestContext.Current.CancellationToken);
    }
}
