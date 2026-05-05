using System.Threading.Tasks;
using Believe.Client.Models.Believe;

namespace Believe.Client.Tests.Services;

public class BelieveServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Submit_Works()
    {
        var response = await this.client.Believe.Submit(
            new()
            {
                Situation =
                    "I just got passed over for a promotion I've been working toward for two years.",
                SituationType = SituationType.WorkChallenge,
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
