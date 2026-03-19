using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Believe.Core;

namespace Believe.Models.TicketSales;

/// <summary>
/// Get a paginated list of all ticket sales with optional filtering. With 300 records,
/// this endpoint is ideal for practicing pagination.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TicketSaleListParams : ParamsBase
{
    /// <summary>
    /// Filter by coupon code (use 'none' for sales without coupons)
    /// </summary>
    public string? CouponCode
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("coupon_code");
        }
        init { this._rawQueryData.Set("coupon_code", value); }
    }

    /// <summary>
    /// Filter by currency (GBP, USD, EUR)
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("currency");
        }
        init { this._rawQueryData.Set("currency", value); }
    }

    /// <summary>
    /// Maximum number of items to return (max: 100)
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Filter by match ID
    /// </summary>
    public string? MatchID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("match_id");
        }
        init { this._rawQueryData.Set("match_id", value); }
    }

    /// <summary>
    /// Filter by purchase method
    /// </summary>
    public ApiEnum<string, PurchaseMethod>? PurchaseMethod
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, PurchaseMethod>>(
                "purchase_method"
            );
        }
        init { this._rawQueryData.Set("purchase_method", value); }
    }

    /// <summary>
    /// Number of items to skip (offset)
    /// </summary>
    public long? Skip
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("skip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("skip", value);
        }
    }

    public TicketSaleListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TicketSaleListParams(TicketSaleListParams ticketSaleListParams)
        : base(ticketSaleListParams) { }
#pragma warning restore CS8618

    public TicketSaleListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TicketSaleListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static TicketSaleListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TicketSaleListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/ticket-sales")
        {
            Query = this.QueryString(options),
        }.Uri;
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
