using System;
using System.Threading.Tasks;
using Believe.Models.Matches;

namespace Believe.Tests.Services;

public class MatchServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var match = await this.client.Matches.Create(
            new()
            {
                AwayTeamID = "tottenham",
                Date = DateTimeOffset.Parse("2024-02-20T19:45:00Z"),
                HomeTeamID = "afc-richmond",
                MatchType = MatchType.Cup,
            },
            TestContext.Current.CancellationToken
        );
        match.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var match = await this.client.Matches.Retrieve(
            "match_id",
            new(),
            TestContext.Current.CancellationToken
        );
        match.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var match = await this.client.Matches.Update(
            "match_id",
            new(),
            TestContext.Current.CancellationToken
        );
        match.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Matches.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Matches.Delete("match_id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetLesson_Works()
    {
        await this.client.Matches.GetLesson(
            "match_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetTurningPoints_Works()
    {
        await this.client.Matches.GetTurningPoints(
            "match_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task StreamLive_Works()
    {
        await this.client.Matches.StreamLive(new(), TestContext.Current.CancellationToken);
    }
}
