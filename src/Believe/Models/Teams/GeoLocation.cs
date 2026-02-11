using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Teams;

/// <summary>
/// Geographic coordinates for a location.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GeoLocation, GeoLocationFromRaw>))]
public sealed record class GeoLocation : JsonModel
{
    /// <summary>
    /// Latitude in degrees
    /// </summary>
    public required double Latitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("latitude");
        }
        init { this._rawData.Set("latitude", value); }
    }

    /// <summary>
    /// Longitude in degrees
    /// </summary>
    public required double Longitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("longitude");
        }
        init { this._rawData.Set("longitude", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Latitude;
        _ = this.Longitude;
    }

    public GeoLocation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GeoLocation(GeoLocation geoLocation)
        : base(geoLocation) { }
#pragma warning restore CS8618

    public GeoLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GeoLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GeoLocationFromRaw.FromRawUnchecked"/>
    public static GeoLocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GeoLocationFromRaw : IFromRawJson<GeoLocation>
{
    /// <inheritdoc/>
    public GeoLocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GeoLocation.FromRawUnchecked(rawData);
}
