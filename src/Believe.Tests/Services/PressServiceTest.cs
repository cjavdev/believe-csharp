using System.Threading.Tasks;

namespace Believe.Tests.Services;

public class PressServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Simulate_Works()
    {
        var response = await this.client.Press.Simulate(
            new()
            {
                Question =
                    "Ted, your team just lost 5-0. How do you explain this embarrassing defeat?",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
