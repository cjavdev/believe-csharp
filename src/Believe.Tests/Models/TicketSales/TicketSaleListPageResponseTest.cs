using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.TicketSales;

namespace Believe.Tests.Models.TicketSales;

public class TicketSaleListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TicketSaleListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        List<TicketSale> expectedData =
        [
            new()
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
            },
        ];
        bool expectedHasMore = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedPages = 0;
        long expectedSkip = 0;
        long expectedTotal = 0;

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedPages, model.Pages);
        Assert.Equal(expectedSkip, model.Skip);
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TicketSaleListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketSaleListPageResponse>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TicketSaleListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketSaleListPageResponse>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<TicketSale> expectedData =
        [
            new()
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
            },
        ];
        bool expectedHasMore = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedPages = 0;
        long expectedSkip = 0;
        long expectedTotal = 0;

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedPages, deserialized.Pages);
        Assert.Equal(expectedSkip, deserialized.Skip);
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TicketSaleListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TicketSaleListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        TicketSaleListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}