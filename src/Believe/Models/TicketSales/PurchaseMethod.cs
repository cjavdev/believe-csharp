using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Exceptions;

namespace Believe.Models.TicketSales;

/// <summary>
/// How the ticket was purchased.
/// </summary>
[JsonConverter(typeof(PurchaseMethodConverter))]
public enum PurchaseMethod
{
    Online,
    BoxOffice,
    WillCall,
    Phone,
}

sealed class PurchaseMethodConverter : JsonConverter<PurchaseMethod>
{
    public override PurchaseMethod Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "online" => PurchaseMethod.Online,
            "box_office" => PurchaseMethod.BoxOffice,
            "will_call" => PurchaseMethod.WillCall,
            "phone" => PurchaseMethod.Phone,
            _ => (PurchaseMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PurchaseMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PurchaseMethod.Online => "online",
                PurchaseMethod.BoxOffice => "box_office",
                PurchaseMethod.WillCall => "will_call",
                PurchaseMethod.Phone => "phone",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
