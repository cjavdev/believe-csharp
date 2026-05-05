using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Believe.Client.Core;

namespace Believe.Client.Models.TicketSales;

/// <summary>
/// Record a new ticket sale.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TicketSaleCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Name of the ticket buyer
    /// </summary>
    public required string BuyerName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("buyer_name");
        }
        init { this._rawBodyData.Set("buyer_name", value); }
    }

    /// <summary>
    /// Currency code (GBP, USD, or EUR)
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("currency");
        }
        init { this._rawBodyData.Set("currency", value); }
    }

    /// <summary>
    /// Discount amount applied from coupon
    /// </summary>
    public required string Discount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("discount");
        }
        init { this._rawBodyData.Set("discount", value); }
    }

    /// <summary>
    /// ID of the match
    /// </summary>
    public required string MatchID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("match_id");
        }
        init { this._rawBodyData.Set("match_id", value); }
    }

    /// <summary>
    /// How the ticket was purchased
    /// </summary>
    public required ApiEnum<string, PurchaseMethod> PurchaseMethod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, PurchaseMethod>>(
                "purchase_method"
            );
        }
        init { this._rawBodyData.Set("purchase_method", value); }
    }

    /// <summary>
    /// Number of tickets purchased
    /// </summary>
    public required long Quantity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("quantity");
        }
        init { this._rawBodyData.Set("quantity", value); }
    }

    /// <summary>
    /// Subtotal before discount and tax (unit_price * quantity)
    /// </summary>
    public required string Subtotal
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("subtotal");
        }
        init { this._rawBodyData.Set("subtotal", value); }
    }

    /// <summary>
    /// Tax amount (20% UK VAT on discounted subtotal)
    /// </summary>
    public required string Tax
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("tax");
        }
        init { this._rawBodyData.Set("tax", value); }
    }

    /// <summary>
    /// Final total (subtotal - discount + tax)
    /// </summary>
    public required string Total
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("total");
        }
        init { this._rawBodyData.Set("total", value); }
    }

    /// <summary>
    /// Price per ticket (decimal string)
    /// </summary>
    public required string UnitPrice
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("unit_price");
        }
        init { this._rawBodyData.Set("unit_price", value); }
    }

    /// <summary>
    /// Email of the ticket buyer
    /// </summary>
    public string? BuyerEmail
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("buyer_email");
        }
        init { this._rawBodyData.Set("buyer_email", value); }
    }

    /// <summary>
    /// Coupon code applied, if any
    /// </summary>
    public string? CouponCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("coupon_code");
        }
        init { this._rawBodyData.Set("coupon_code", value); }
    }

    public TicketSaleCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TicketSaleCreateParams(TicketSaleCreateParams ticketSaleCreateParams)
        : base(ticketSaleCreateParams)
    {
        this._rawBodyData = new(ticketSaleCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TicketSaleCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TicketSaleCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TicketSaleCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TicketSaleCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/ticket-sales")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
