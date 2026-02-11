using System.Threading.Tasks;

namespace Believe.Tests.Services;

public class EpisodeServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var episode = await this.client.Episodes.Create(
            new()
            {
                AirDate = "2020-10-02",
                CharacterFocus = ["ted-lasso", "coach-beard", "higgins", "nate"],
                Director = "MJ Delaney",
                EpisodeNumber = 8,
                MainTheme = "The power of vulnerability and male friendship",
                RuntimeMinutes = 29,
                Season = 1,
                Synopsis =
                    "Ted creates a support group for the coaching staff while Rebecca faces a difficult decision about her future.",
                TedWisdom = "There's two buttons I never like to hit: that's panic and snooze.",
                Title = "The Diamond Dogs",
                Writer = "Jason Sudeikis, Brendan Hunt, Joe Kelly",
            },
            TestContext.Current.CancellationToken
        );
        episode.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var episode = await this.client.Episodes.Retrieve(
            "episode_id",
            new(),
            TestContext.Current.CancellationToken
        );
        episode.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var episode = await this.client.Episodes.Update(
            "episode_id",
            new(),
            TestContext.Current.CancellationToken
        );
        episode.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Episodes.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Episodes.Delete(
            "episode_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetWisdom_Works()
    {
        await this.client.Episodes.GetWisdom(
            "episode_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListBySeason_Works()
    {
        var page = await this.client.Episodes.ListBySeason(
            0,
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
