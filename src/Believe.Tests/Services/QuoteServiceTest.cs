using System.Threading.Tasks;
using Believe.Models.Quotes;

namespace Believe.Tests.Services;

public class QuoteServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var quote = await this.client.Quotes.Create(
            new()
            {
                CharacterID = "ted-lasso",
                Context = "Ted's first team meeting, revealing his coaching philosophy",
                MomentType = QuoteMoment.LockerRoom,
                Text = "I believe in believe.",
                Theme = QuoteTheme.Belief,
            },
            TestContext.Current.CancellationToken
        );
        quote.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var quote = await this.client.Quotes.Retrieve(
            "quote_id",
            new(),
            TestContext.Current.CancellationToken
        );
        quote.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var quote = await this.client.Quotes.Update(
            "quote_id",
            new(),
            TestContext.Current.CancellationToken
        );
        quote.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Quotes.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Quotes.Delete("quote_id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetRandom_Works()
    {
        var quote = await this.client.Quotes.GetRandom(
            new(),
            TestContext.Current.CancellationToken
        );
        quote.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListByCharacter_Works()
    {
        var page = await this.client.Quotes.ListByCharacter(
            "character_id",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListByTheme_Works()
    {
        var page = await this.client.Quotes.ListByTheme(
            QuoteTheme.Belief,
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
