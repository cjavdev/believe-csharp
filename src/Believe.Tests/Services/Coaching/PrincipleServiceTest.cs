using System.Threading.Tasks;

namespace Believe.Tests.Services.Coaching;

public class PrincipleServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var coachingPrinciple = await this.client.Coaching.Principles.Retrieve(
            "principle_id",
            new(),
            TestContext.Current.CancellationToken
        );
        coachingPrinciple.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Coaching.Principles.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetRandom_Works()
    {
        var coachingPrinciple = await this.client.Coaching.Principles.GetRandom(
            new(),
            TestContext.Current.CancellationToken
        );
        coachingPrinciple.Validate();
    }
}
