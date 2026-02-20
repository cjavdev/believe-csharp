using System.Threading.Tasks;

namespace Believe.Tests.Services.Matches;

public class CommentaryServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Stream_Works()
    {
        await this.client.Matches.Commentary.Stream(
            "match_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
