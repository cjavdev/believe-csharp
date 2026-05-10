using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Models.Teams;

namespace Believe.Client.Tests.Models.Teams;

public class GeoLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GeoLocation { Latitude = 51.4816, Longitude = -0.191 };

        double expectedLatitude = 51.4816;
        double expectedLongitude = -0.191;

        Assert.Equal(expectedLatitude, model.Latitude);
        Assert.Equal(expectedLongitude, model.Longitude);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GeoLocation { Latitude = 51.4816, Longitude = -0.191 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeoLocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GeoLocation { Latitude = 51.4816, Longitude = -0.191 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeoLocation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedLatitude = 51.4816;
        double expectedLongitude = -0.191;

        Assert.Equal(expectedLatitude, deserialized.Latitude);
        Assert.Equal(expectedLongitude, deserialized.Longitude);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GeoLocation { Latitude = 51.4816, Longitude = -0.191 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GeoLocation { Latitude = 51.4816, Longitude = -0.191 };

        GeoLocation copied = new(model);

        Assert.Equal(model, copied);
    }
}
