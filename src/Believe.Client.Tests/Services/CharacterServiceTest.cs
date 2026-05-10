using System.Threading.Tasks;
using Believe.Client.Models.Characters;

namespace Believe.Client.Tests.Services;

public class CharacterServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var character = await this.client.Characters.Create(
            new()
            {
                Background =
                    "Legendary midfielder for Chelsea and AFC Richmond, now assistant coach. Known for his gruff exterior hiding a heart of gold.",
                EmotionalStats = new()
                {
                    Curiosity = 40,
                    Empathy = 85,
                    Optimism = 45,
                    Resilience = 95,
                    Vulnerability = 60,
                },
                Name = "Roy Kent",
                PersonalityTraits = ["intense", "loyal", "secretly caring", "profane"],
                Role = CharacterRole.Coach,
            },
            TestContext.Current.CancellationToken
        );
        character.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var character = await this.client.Characters.Retrieve(
            "character_id",
            new(),
            TestContext.Current.CancellationToken
        );
        character.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var character = await this.client.Characters.Update(
            "character_id",
            new(),
            TestContext.Current.CancellationToken
        );
        character.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Characters.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Characters.Delete(
            "character_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetQuotes_Works()
    {
        await this.client.Characters.GetQuotes(
            "character_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
