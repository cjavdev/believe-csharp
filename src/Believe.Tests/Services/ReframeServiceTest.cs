using System.Threading.Tasks;

namespace Believe.Tests.Services;

public class ReframeServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task TransformNegativeThoughts_Works()
    {
        var response = await this.client.Reframe.TransformNegativeThoughts(
            new() { NegativeThought = "I'm not good enough for this job." },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
