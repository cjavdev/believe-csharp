using System;
using Believe.Core;
using Believe.Models.TicketSales;

namespace Believe.Tests.Models.TicketSales;

public class TicketSaleCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TicketSaleCreateParams
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
            BuyerEmail = "mae.green@example.com",
            CouponCode = "BELIEVE10",
        };

        string expectedBuyerName = "Mae Green";
        string expectedCurrency = "GBP";
        string expectedDiscount = "9.00";
        string expectedMatchID = "match-001";
        ApiEnum<string, PurchaseMethod> expectedPurchaseMethod = PurchaseMethod.Online;
        long expectedQuantity = 2;
        string expectedSubtotal = "90.00";
        string expectedTax = "16.20";
        string expectedTotal = "97.20";
        string expectedUnitPrice = "45.00";
        string expectedBuyerEmail = "mae.green@example.com";
        string expectedCouponCode = "BELIEVE10";

        Assert.Equal(expectedBuyerName, parameters.BuyerName);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedDiscount, parameters.Discount);
        Assert.Equal(expectedMatchID, parameters.MatchID);
        Assert.Equal(expectedPurchaseMethod, parameters.PurchaseMethod);
        Assert.Equal(expectedQuantity, parameters.Quantity);
        Assert.Equal(expectedSubtotal, parameters.Subtotal);
        Assert.Equal(expectedTax, parameters.Tax);
        Assert.Equal(expectedTotal, parameters.Total);
        Assert.Equal(expectedUnitPrice, parameters.UnitPrice);
        Assert.Equal(expectedBuyerEmail, parameters.BuyerEmail);
        Assert.Equal(expectedCouponCode, parameters.CouponCode);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TicketSaleCreateParams
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
        };

        Assert.Null(parameters.BuyerEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("buyer_email"));
        Assert.Null(parameters.CouponCode);
        Assert.False(parameters.RawBodyData.ContainsKey("coupon_code"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TicketSaleCreateParams
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

            BuyerEmail = null,
            CouponCode = null,
        };

        Assert.Null(parameters.BuyerEmail);
        Assert.True(parameters.RawBodyData.ContainsKey("buyer_email"));
        Assert.Null(parameters.CouponCode);
        Assert.True(parameters.RawBodyData.ContainsKey("coupon_code"));
    }

    [Fact]
    public void Url_Works()
    {
        TicketSaleCreateParams parameters = new()
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
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://believe.cjav.dev/ticket-sales"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TicketSaleCreateParams
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
            BuyerEmail = "mae.green@example.com",
            CouponCode = "BELIEVE10",
        };

        TicketSaleCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
