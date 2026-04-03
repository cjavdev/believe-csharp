using System.Threading.Tasks;

namespace Believe.Tests.Services;

public class StreamServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task TestConnection_Works()
    {
        await this.client.Stream.TestConnection(new(), TestContext.Current.CancellationToken);
    }
}