using System;
using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Client.TicketSales;

namespace Believe.Tests.Models.Client.TicketSales;

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

        Assert.Equal(new Uri("https://believe.cjav.dev/ticket-sales"), url);
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

public class PurchaseMethodTest : TestBase
{
    [Theory]
    [InlineData(PurchaseMethod.Online)]
    [InlineData(PurchaseMethod.BoxOffice)]
    [InlineData(PurchaseMethod.WillCall)]
    [InlineData(PurchaseMethod.Phone)]
    public void Validation_Works(PurchaseMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PurchaseMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PurchaseMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PurchaseMethod.Online)]
    [InlineData(PurchaseMethod.BoxOffice)]
    [InlineData(PurchaseMethod.WillCall)]
    [InlineData(PurchaseMethod.Phone)]
    public void SerializationRoundtrip_Works(PurchaseMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PurchaseMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PurchaseMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PurchaseMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PurchaseMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
