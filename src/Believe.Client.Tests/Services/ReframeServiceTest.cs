using System.Threading.Tasks;

namespace Believe.Client.Tests.Services;

public class ReframeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task TransformNegativeThoughts_Works()
    {
        var response = await this.client.Reframe.TransformNegativeThoughts(
            new() { NegativeThought = "I'm not good enough for this job." },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
