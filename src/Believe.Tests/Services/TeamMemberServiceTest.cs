using System.Threading.Tasks;
using Believe.Models.TeamMembers;

namespace Believe.Tests.Services;

public class TeamMemberServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var teamMember = await this.client.TeamMembers.Create(
            new()
            {
                Member = new Player()
                {
                    CharacterID = "jamie-tartt",
                    JerseyNumber = 9,
                    Position = Position.Forward,
                    TeamID = "afc-richmond",
                    YearsWithTeam = 3,
                    Assists = 23,
                    GoalsScored = 47,
                    IsCaptain = false,
                    MemberType = MemberType.Player,
                },
            },
            TestContext.Current.CancellationToken
        );
        teamMember.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var teamMember = await this.client.TeamMembers.Retrieve(
            "member_id",
            new(),
            TestContext.Current.CancellationToken
        );
        teamMember.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var teamMember = await this.client.TeamMembers.Update(
            "member_id",
            new()
            {
                Updates = new PlayerUpdate()
                {
                    Assists = 0,
                    GoalsScored = 0,
                    IsCaptain = true,
                    JerseyNumber = 1,
                    Position = Position.Goalkeeper,
                    TeamID = "team_id",
                    YearsWithTeam = 0,
                },
            },
            TestContext.Current.CancellationToken
        );
        teamMember.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.TeamMembers.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.TeamMembers.Delete(
            "member_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListCoaches_Works()
    {
        var page = await this.client.TeamMembers.ListCoaches(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListPlayers_Works()
    {
        var page = await this.client.TeamMembers.ListPlayers(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListStaff_Works()
    {
        var page = await this.client.TeamMembers.ListStaff(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
