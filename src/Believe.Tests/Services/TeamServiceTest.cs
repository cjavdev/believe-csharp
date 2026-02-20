using System.Threading.Tasks;
using Believe.Models.Teams;

namespace Believe.Tests.Services;

public class TeamServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var team = await this.client.Teams.Create(
            new()
            {
                CultureScore = 70,
                FoundedYear = 1895,
                League = League.PremierLeague,
                Name = "West Ham United",
                Stadium = "London Stadium",
                Values = new()
                {
                    PrimaryValue = "Pride",
                    SecondaryValues = ["History", "Community", "Passion"],
                    TeamMotto = "Forever Blowing Bubbles",
                },
            },
            TestContext.Current.CancellationToken
        );
        team.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var team = await this.client.Teams.Retrieve(
            "team_id",
            new(),
            TestContext.Current.CancellationToken
        );
        team.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var team = await this.client.Teams.Update(
            "team_id",
            new(),
            TestContext.Current.CancellationToken
        );
        team.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Teams.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Teams.Delete("team_id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetCulture_Works()
    {
        await this.client.Teams.GetCulture("team_id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetRivals_Works()
    {
        var teams = await this.client.Teams.GetRivals(
            "team_id",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in teams)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListLogos_Works()
    {
        var fileUploads = await this.client.Teams.ListLogos(
            "team_id",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in fileUploads)
        {
            item.Validate();
        }
    }
}
