using System;
using Believe.Core;
using Believe.Models.TicketSales;

namespace Believe.Tests.Models.TicketSales;

public class TicketSaleUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TicketSaleUpdateParams
        {
            TicketSaleID = "ticket_sale_id",
            BuyerEmail = "dev@stainless.com",
            BuyerName = "buyer_name",
            CouponCode = "coupon_code",
            Currency = "currency",
            Discount = "discount",
            MatchID = "match_id",
            PurchaseMethod = PurchaseMethod.Online,
            Quantity = 1,
            Subtotal = "subtotal",
            Tax = "tax",
            Total = "total",
            UnitPrice = "unit_price",
        };

        string expectedTicketSaleID = "ticket_sale_id";
        string expectedBuyerEmail = "dev@stainless.com";
        string expectedBuyerName = "buyer_name";
        string expectedCouponCode = "coupon_code";
        string expectedCurrency = "currency";
        string expectedDiscount = "discount";
        string expectedMatchID = "match_id";
        ApiEnum<string, PurchaseMethod> expectedPurchaseMethod = PurchaseMethod.Online;
        long expectedQuantity = 1;
        string expectedSubtotal = "subtotal";
        string expectedTax = "tax";
        string expectedTotal = "total";
        string expectedUnitPrice = "unit_price";

        Assert.Equal(expectedTicketSaleID, parameters.TicketSaleID);
        Assert.Equal(expectedBuyerEmail, parameters.BuyerEmail);
        Assert.Equal(expectedBuyerName, parameters.BuyerName);
        Assert.Equal(expectedCouponCode, parameters.CouponCode);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedDiscount, parameters.Discount);
        Assert.Equal(expectedMatchID, parameters.MatchID);
        Assert.Equal(expectedPurchaseMethod, parameters.PurchaseMethod);
        Assert.Equal(expectedQuantity, parameters.Quantity);
        Assert.Equal(expectedSubtotal, parameters.Subtotal);
        Assert.Equal(expectedTax, parameters.Tax);
        Assert.Equal(expectedTotal, parameters.Total);
        Assert.Equal(expectedUnitPrice, parameters.UnitPrice);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TicketSaleUpdateParams { TicketSaleID = "ticket_sale_id" };

        Assert.Null(parameters.BuyerEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("buyer_email"));
        Assert.Null(parameters.BuyerName);
        Assert.False(parameters.RawBodyData.ContainsKey("buyer_name"));
        Assert.Null(parameters.CouponCode);
        Assert.False(parameters.RawBodyData.ContainsKey("coupon_code"));
        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.Discount);
        Assert.False(parameters.RawBodyData.ContainsKey("discount"));
        Assert.Null(parameters.MatchID);
        Assert.False(parameters.RawBodyData.ContainsKey("match_id"));
        Assert.Null(parameters.PurchaseMethod);
        Assert.False(parameters.RawBodyData.ContainsKey("purchase_method"));
        Assert.Null(parameters.Quantity);
        Assert.False(parameters.RawBodyData.ContainsKey("quantity"));
        Assert.Null(parameters.Subtotal);
        Assert.False(parameters.RawBodyData.ContainsKey("subtotal"));
        Assert.Null(parameters.Tax);
        Assert.False(parameters.RawBodyData.ContainsKey("tax"));
        Assert.Null(parameters.Total);
        Assert.False(parameters.RawBodyData.ContainsKey("total"));
        Assert.Null(parameters.UnitPrice);
        Assert.False(parameters.RawBodyData.ContainsKey("unit_price"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TicketSaleUpdateParams
        {
            TicketSaleID = "ticket_sale_id",

            BuyerEmail = null,
            BuyerName = null,
            CouponCode = null,
            Currency = null,
            Discount = null,
            MatchID = null,
            PurchaseMethod = null,
            Quantity = null,
            Subtotal = null,
            Tax = null,
            Total = null,
            UnitPrice = null,
        };

        Assert.Null(parameters.BuyerEmail);
        Assert.True(parameters.RawBodyData.ContainsKey("buyer_email"));
        Assert.Null(parameters.BuyerName);
        Assert.True(parameters.RawBodyData.ContainsKey("buyer_name"));
        Assert.Null(parameters.CouponCode);
        Assert.True(parameters.RawBodyData.ContainsKey("coupon_code"));
        Assert.Null(parameters.Currency);
        Assert.True(parameters.RawBodyData.ContainsKey("currency"));
        Assert.Null(parameters.Discount);
        Assert.True(parameters.RawBodyData.ContainsKey("discount"));
        Assert.Null(parameters.MatchID);
        Assert.True(parameters.RawBodyData.ContainsKey("match_id"));
        Assert.Null(parameters.PurchaseMethod);
        Assert.True(parameters.RawBodyData.ContainsKey("purchase_method"));
        Assert.Null(parameters.Quantity);
        Assert.True(parameters.RawBodyData.ContainsKey("quantity"));
        Assert.Null(parameters.Subtotal);
        Assert.True(parameters.RawBodyData.ContainsKey("subtotal"));
        Assert.Null(parameters.Tax);
        Assert.True(parameters.RawBodyData.ContainsKey("tax"));
        Assert.Null(parameters.Total);
        Assert.True(parameters.RawBodyData.ContainsKey("total"));
        Assert.Null(parameters.UnitPrice);
        Assert.True(parameters.RawBodyData.ContainsKey("unit_price"));
    }

    [Fact]
    public void Url_Works()
    {
        TicketSaleUpdateParams parameters = new() { TicketSaleID = "ticket_sale_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/ticket-sales/ticket_sale_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TicketSaleUpdateParams
        {
            TicketSaleID = "ticket_sale_id",
            BuyerEmail = "dev@stainless.com",
            BuyerName = "buyer_name",
            CouponCode = "coupon_code",
            Currency = "currency",
            Discount = "discount",
            MatchID = "match_id",
            PurchaseMethod = PurchaseMethod.Online,
            Quantity = 1,
            Subtotal = "subtotal",
            Tax = "tax",
            Total = "total",
            UnitPrice = "unit_price",
        };

        TicketSaleUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
