using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Believe.Core;

namespace Believe.Models.TicketSales;

/// <summary>
/// Update specific fields of an existing ticket sale.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TicketSaleUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? TicketSaleID { get; init; }

    public string? BuyerEmail
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("buyer_email");
        }
        init { this._rawBodyData.Set("buyer_email", value); }
    }

    public string? BuyerName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("buyer_name");
        }
        init { this._rawBodyData.Set("buyer_name", value); }
    }

    public string? CouponCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("coupon_code");
        }
        init { this._rawBodyData.Set("coupon_code", value); }
    }

    public string? Currency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("currency");
        }
        init { this._rawBodyData.Set("currency", value); }
    }

    public string? Discount
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("discount");
        }
        init { this._rawBodyData.Set("discount", value); }
    }

    public string? MatchID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("match_id");
        }
        init { this._rawBodyData.Set("match_id", value); }
    }

    /// <summary>
    /// How the ticket was purchased.
    /// </summary>
    public ApiEnum<string, PurchaseMethod>? PurchaseMethod
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, PurchaseMethod>>(
                "purchase_method"
            );
        }
        init { this._rawBodyData.Set("purchase_method", value); }
    }

    public long? Quantity
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("quantity");
        }
        init { this._rawBodyData.Set("quantity", value); }
    }

    public string? Subtotal
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("subtotal");
        }
        init { this._rawBodyData.Set("subtotal", value); }
    }

    public string? Tax
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tax");
        }
        init { this._rawBodyData.Set("tax", value); }
    }

    public string? Total
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("total");
        }
        init { this._rawBodyData.Set("total", value); }
    }

    public string? UnitPrice
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("unit_price");
        }
        init { this._rawBodyData.Set("unit_price", value); }
    }

    public TicketSaleUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TicketSaleUpdateParams(TicketSaleUpdateParams ticketSaleUpdateParams)
        : base(ticketSaleUpdateParams)
    {
        this.TicketSaleID = ticketSaleUpdateParams.TicketSaleID;

        this._rawBodyData = new(ticketSaleUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TicketSaleUpdateParams(
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
    TicketSaleUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string ticketSaleID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.TicketSaleID = ticketSaleID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TicketSaleUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string ticketSaleID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            ticketSaleID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["TicketSaleID"] = JsonSerializer.SerializeToElement(this.TicketSaleID),
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

    public virtual bool Equals(TicketSaleUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.TicketSaleID?.Equals(other.TicketSaleID) ?? other.TicketSaleID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/ticket-sales/{0}", this.TicketSaleID)
        )
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
