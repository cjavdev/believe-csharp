using System;
using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Client.TicketSales;

namespace Believe.Tests.Models.Client.TicketSales;

public class TicketSaleListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TicketSaleListParams
        {
            CouponCode = "coupon_code",
            Currency = "currency",
            Limit = 10,
            MatchID = "match_id",
            PurchaseMethod = TicketSaleListParamsPurchaseMethod.Online,
            Skip = 0,
        };

        string expectedCouponCode = "coupon_code";
        string expectedCurrency = "currency";
        long expectedLimit = 10;
        string expectedMatchID = "match_id";
        ApiEnum<string, TicketSaleListParamsPurchaseMethod> expectedPurchaseMethod =
            TicketSaleListParamsPurchaseMethod.Online;
        long expectedSkip = 0;

        Assert.Equal(expectedCouponCode, parameters.CouponCode);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMatchID, parameters.MatchID);
        Assert.Equal(expectedPurchaseMethod, parameters.PurchaseMethod);
        Assert.Equal(expectedSkip, parameters.Skip);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TicketSaleListParams
        {
            CouponCode = "coupon_code",
            Currency = "currency",
            MatchID = "match_id",
            PurchaseMethod = TicketSaleListParamsPurchaseMethod.Online,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TicketSaleListParams
        {
            CouponCode = "coupon_code",
            Currency = "currency",
            MatchID = "match_id",
            PurchaseMethod = TicketSaleListParamsPurchaseMethod.Online,

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Skip = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TicketSaleListParams { Limit = 10, Skip = 0 };

        Assert.Null(parameters.CouponCode);
        Assert.False(parameters.RawQueryData.ContainsKey("coupon_code"));
        Assert.Null(parameters.Currency);
        Assert.False(parameters.RawQueryData.ContainsKey("currency"));
        Assert.Null(parameters.MatchID);
        Assert.False(parameters.RawQueryData.ContainsKey("match_id"));
        Assert.Null(parameters.PurchaseMethod);
        Assert.False(parameters.RawQueryData.ContainsKey("purchase_method"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TicketSaleListParams
        {
            Limit = 10,
            Skip = 0,

            CouponCode = null,
            Currency = null,
            MatchID = null,
            PurchaseMethod = null,
        };

        Assert.Null(parameters.CouponCode);
        Assert.True(parameters.RawQueryData.ContainsKey("coupon_code"));
        Assert.Null(parameters.Currency);
        Assert.True(parameters.RawQueryData.ContainsKey("currency"));
        Assert.Null(parameters.MatchID);
        Assert.True(parameters.RawQueryData.ContainsKey("match_id"));
        Assert.Null(parameters.PurchaseMethod);
        Assert.True(parameters.RawQueryData.ContainsKey("purchase_method"));
    }

    [Fact]
    public void Url_Works()
    {
        TicketSaleListParams parameters = new()
        {
            CouponCode = "coupon_code",
            Currency = "currency",
            Limit = 10,
            MatchID = "match_id",
            PurchaseMethod = TicketSaleListParamsPurchaseMethod.Online,
            Skip = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://believe.cjav.dev/ticket-sales?coupon_code=coupon_code&currency=currency&limit=10&match_id=match_id&purchase_method=online&skip=0"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TicketSaleListParams
        {
            CouponCode = "coupon_code",
            Currency = "currency",
            Limit = 10,
            MatchID = "match_id",
            PurchaseMethod = TicketSaleListParamsPurchaseMethod.Online,
            Skip = 0,
        };

        TicketSaleListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TicketSaleListParamsPurchaseMethodTest : TestBase
{
    [Theory]
    [InlineData(TicketSaleListParamsPurchaseMethod.Online)]
    [InlineData(TicketSaleListParamsPurchaseMethod.BoxOffice)]
    [InlineData(TicketSaleListParamsPurchaseMethod.WillCall)]
    [InlineData(TicketSaleListParamsPurchaseMethod.Phone)]
    public void Validation_Works(TicketSaleListParamsPurchaseMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TicketSaleListParamsPurchaseMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TicketSaleListParamsPurchaseMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TicketSaleListParamsPurchaseMethod.Online)]
    [InlineData(TicketSaleListParamsPurchaseMethod.BoxOffice)]
    [InlineData(TicketSaleListParamsPurchaseMethod.WillCall)]
    [InlineData(TicketSaleListParamsPurchaseMethod.Phone)]
    public void SerializationRoundtrip_Works(TicketSaleListParamsPurchaseMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TicketSaleListParamsPurchaseMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TicketSaleListParamsPurchaseMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TicketSaleListParamsPurchaseMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TicketSaleListParamsPurchaseMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
