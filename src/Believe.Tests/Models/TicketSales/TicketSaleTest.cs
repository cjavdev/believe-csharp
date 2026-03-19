using System.Text.Json;
using Believe.Core;
using Believe.Models.TicketSales;

namespace Believe.Tests.Models.TicketSales;

public class TicketSaleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TicketSale
        {
            ID = "ts-001",
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

        string expectedID = "ts-001";
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

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBuyerName, model.BuyerName);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedMatchID, model.MatchID);
        Assert.Equal(expectedPurchaseMethod, model.PurchaseMethod);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedSubtotal, model.Subtotal);
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedBuyerEmail, model.BuyerEmail);
        Assert.Equal(expectedCouponCode, model.CouponCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TicketSale
        {
            ID = "ts-001",
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketSale>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TicketSale
        {
            ID = "ts-001",
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketSale>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "ts-001";
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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBuyerName, deserialized.BuyerName);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedMatchID, deserialized.MatchID);
        Assert.Equal(expectedPurchaseMethod, deserialized.PurchaseMethod);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedSubtotal, deserialized.Subtotal);
        Assert.Equal(expectedTax, deserialized.Tax);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedBuyerEmail, deserialized.BuyerEmail);
        Assert.Equal(expectedCouponCode, deserialized.CouponCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TicketSale
        {
            ID = "ts-001",
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TicketSale
        {
            ID = "ts-001",
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

        Assert.Null(model.BuyerEmail);
        Assert.False(model.RawData.ContainsKey("buyer_email"));
        Assert.Null(model.CouponCode);
        Assert.False(model.RawData.ContainsKey("coupon_code"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TicketSale
        {
            ID = "ts-001",
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TicketSale
        {
            ID = "ts-001",
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

        Assert.Null(model.BuyerEmail);
        Assert.True(model.RawData.ContainsKey("buyer_email"));
        Assert.Null(model.CouponCode);
        Assert.True(model.RawData.ContainsKey("coupon_code"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TicketSale
        {
            ID = "ts-001",
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TicketSale
        {
            ID = "ts-001",
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

        TicketSale copied = new(model);

        Assert.Equal(model, copied);
    }
}
