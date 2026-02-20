using System.Threading.Tasks;

namespace Believe.Tests.Services;

public class HealthServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Check_Works()
    {
        await this.client.Health.Check(new(), TestContext.Current.CancellationToken);
    }
}
