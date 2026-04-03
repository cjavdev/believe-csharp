using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.TicketSales;

/// <summary>
/// Full ticket sale model with ID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TicketSale, TicketSaleFromRaw>))]
public sealed record class TicketSale : JsonModel
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Name of the ticket buyer
    /// </summary>
    public required string BuyerName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "buyer_name"
            );
        }
        init { this._rawData.Set("buyer_name", value); }
    }

    /// <summary>
    /// Currency code (GBP, USD, or EUR)
    /// </summary>
    public required string Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Discount amount applied from coupon
    /// </summary>
    public required string Discount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "discount"
            );
        }
        init { this._rawData.Set("discount", value); }
    }

    /// <summary>
    /// ID of the match
    /// </summary>
    public required string MatchID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "match_id"
            );
        }
        init { this._rawData.Set("match_id", value); }
    }

    /// <summary>
    /// How the ticket was purchased
    /// </summary>
    public required ApiEnum<string, PurchaseMethod> PurchaseMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PurchaseMethod>>(
                "purchase_method"
            );
        }
        init { this._rawData.Set("purchase_method", value); }
    }

    /// <summary>
    /// Number of tickets purchased
    /// </summary>
    public required long Quantity {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "quantity"
            );
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// Subtotal before discount and tax (unit_price * quantity)
    /// </summary>
    public required string Subtotal {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "subtotal"
            );
        }
        init { this._rawData.Set("subtotal", value); }
    }

    /// <summary>
    /// Tax amount (20% UK VAT on discounted subtotal)
    /// </summary>
    public required string Tax {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "tax"
            );
        }
        init { this._rawData.Set("tax", value); }
    }

    /// <summary>
    /// Final total (subtotal - discount + tax)
    /// </summary>
    public required string Total {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "total"
            );
        }
        init { this._rawData.Set("total", value); }
    }

    /// <summary>
    /// Price per ticket (decimal string)
    /// </summary>
    public required string UnitPrice {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "unit_price"
            );
        }
        init { this._rawData.Set("unit_price", value); }
    }

    /// <summary>
    /// Email of the ticket buyer
    /// </summary>
    public string? BuyerEmail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "buyer_email"
            );
        }
        init { this._rawData.Set("buyer_email", value); }
    }

    /// <summary>
    /// Coupon code applied, if any
    /// </summary>
    public string? CouponCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "coupon_code"
            );
        }
        init { this._rawData.Set("coupon_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BuyerName;
        _ = this.Currency;
        _ = this.Discount;
        _ = this.MatchID;
        this.PurchaseMethod.Validate();
        _ = this.Quantity;
        _ = this.Subtotal;
        _ = this.Tax;
        _ = this.Total;
        _ = this.UnitPrice;
        _ = this.BuyerEmail;
        _ = this.CouponCode;
    }

    public TicketSale ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TicketSale (TicketSale ticketSale) : base(ticketSale)
    {  }
    #pragma warning restore CS8618

    public TicketSale (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TicketSale (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TicketSaleFromRaw.FromRawUnchecked"/>
    public static TicketSale FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TicketSaleFromRaw : IFromRawJson<TicketSale>
{
    /// <inheritdoc/>
    public TicketSale FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TicketSale.FromRawUnchecked(rawData);
}