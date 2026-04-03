using System.Threading.Tasks;
using Believe.Models.Conflicts;

namespace Believe.Tests.Services;

public class ConflictServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Resolve_Works()
    {
        var response = await this.client.Conflicts.Resolve(new()
        {
            ConflictType = ConflictType.Interpersonal,
            Description = "Alex keeps taking credit for my ideas in meetings and I'm getting resentful.",
            PartiesInvolved =
            [
                "Me", "My teammate Alex"
            ],
        }, TestContext.Current.CancellationToken);
        response.Validate();
    }
}