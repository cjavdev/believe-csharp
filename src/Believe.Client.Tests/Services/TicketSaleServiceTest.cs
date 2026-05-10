using System.Threading.Tasks;
using Believe.Client.Models.TicketSales;

namespace Believe.Client.Tests.Services;

public class TicketSaleServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var ticketSale = await this.client.TicketSales.Create(
            new()
            {
                BuyerName = "Mae Green",
                Currency = "GBP",
                Discount = "9.00",
                MatchID = "match-001",
                PurchaseMethod = PurchaseMethod.Online,
                Quantity = 2,
                Subtotal = "90.00",
                Tax = "16.20",
                Total = "97.20",
                UnitPrice = "45.00",
            },
            TestContext.Current.CancellationToken
        );
        ticketSale.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var ticketSale = await this.client.TicketSales.Retrieve(
            "ticket_sale_id",
            new(),
            TestContext.Current.CancellationToken
        );
        ticketSale.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var ticketSale = await this.client.TicketSales.Update(
            "ticket_sale_id",
            new(),
            TestContext.Current.CancellationToken
        );
        ticketSale.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.TicketSales.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.TicketSales.Delete(
            "ticket_sale_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
