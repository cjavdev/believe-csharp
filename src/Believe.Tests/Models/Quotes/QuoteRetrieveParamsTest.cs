using System;
using Believe.Models.Quotes;

namespace Believe.Tests.Models.Quotes;

public class QuoteRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {


        var parameters = new QuoteRetrieveParams
        {
            QuoteID = "quote_id",
        };

        string expectedQuoteID = "quote_id";

        Assert.Equal(expectedQuoteID, parameters.QuoteID);
    }

    [Fact]
    public void Url_Works()
    {
        QuoteRetrieveParams parameters = new() { QuoteID = "quote_id" };

        var url = parameters.Url(
            new()
            {
                ApiKey = "My API Key"
            }
        );

        Assert.Equal(new Uri("https://believe.cjav.dev/quotes/quote_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new QuoteRetrieveParams
        {
            QuoteID = "quote_id"
        };

        QuoteRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}