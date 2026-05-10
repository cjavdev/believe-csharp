using System;
using Believe.Client.Models.Quotes;

namespace Believe.Client.Tests.Models.Quotes;

public class QuoteDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new QuoteDeleteParams { QuoteID = "quote_id" };

        string expectedQuoteID = "quote_id";

        Assert.Equal(expectedQuoteID, parameters.QuoteID);
    }

    [Fact]
    public void Url_Works()
    {
        QuoteDeleteParams parameters = new() { QuoteID = "quote_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://believe.cjav.dev/quotes/quote_id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new QuoteDeleteParams { QuoteID = "quote_id" };

        QuoteDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
