using System;
using Believe.Models.Client.TicketSales;

namespace Believe.Tests.Models.Client.TicketSales;

public class TicketSaleDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TicketSaleDeleteParams { TicketSaleID = "ticket_sale_id" };

        string expectedTicketSaleID = "ticket_sale_id";

        Assert.Equal(expectedTicketSaleID, parameters.TicketSaleID);
    }

    [Fact]
    public void Url_Works()
    {
        TicketSaleDeleteParams parameters = new() { TicketSaleID = "ticket_sale_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/ticket-sales/ticket_sale_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TicketSaleDeleteParams { TicketSaleID = "ticket_sale_id" };

        TicketSaleDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
