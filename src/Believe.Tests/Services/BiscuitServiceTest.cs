using System.Threading.Tasks;

namespace Believe.Tests.Services;

public class BiscuitServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var biscuit = await this.client.Biscuits.Retrieve(
            "biscuit_id",
            new(),
            TestContext.Current.CancellationToken
        );
        biscuit.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Biscuits.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetFresh_Works()
    {
        var biscuit = await this.client.Biscuits.GetFresh(
            new(),
            TestContext.Current.CancellationToken
        );
        biscuit.Validate();
    }
}
