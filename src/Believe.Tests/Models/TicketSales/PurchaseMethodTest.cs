using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.TicketSales;

namespace Believe.Tests.Models.TicketSales;

public class PurchaseMethodTest : TestBase
{
    [Theory][InlineData(PurchaseMethod.Online)][InlineData(PurchaseMethod.BoxOffice)][InlineData(PurchaseMethod.WillCall)][InlineData(PurchaseMethod.Phone)]
    public void Validation_Works(PurchaseMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PurchaseMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PurchaseMethod>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(PurchaseMethod.Online)][InlineData(PurchaseMethod.BoxOffice)][InlineData(PurchaseMethod.WillCall)][InlineData(PurchaseMethod.Phone)]
    public void SerializationRoundtrip_Works(PurchaseMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PurchaseMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PurchaseMethod>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PurchaseMethod>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PurchaseMethod>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}