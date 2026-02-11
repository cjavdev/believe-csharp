using System.Threading.Tasks;

namespace Believe.Tests.Services;

public class PepTalkServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var pepTalk = await this.client.PepTalk.Retrieve(
            new(),
            TestContext.Current.CancellationToken
        );
        pepTalk.Validate();
    }
}
