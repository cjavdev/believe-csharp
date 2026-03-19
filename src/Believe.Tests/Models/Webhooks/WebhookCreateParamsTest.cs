using System;
using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Webhooks;

namespace Believe.Tests.Models.Webhooks;

public class WebhookCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookCreateParams
        {
            UrlValue = "https://example.com/webhooks",
            Description = "Production webhook for match notifications",
            EventTypes = [EventType.MatchCompleted, EventType.TeamMemberTransferred],
        };

        string expectedUrlValue = "https://example.com/webhooks";
        string expectedDescription = "Production webhook for match notifications";
        List<ApiEnum<string, EventType>> expectedEventTypes =
        [
            EventType.MatchCompleted,
            EventType.TeamMemberTransferred,
        ];

        Assert.Equal(expectedUrlValue, parameters.UrlValue);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.EventTypes);
        Assert.Equal(expectedEventTypes.Count, parameters.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], parameters.EventTypes[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookCreateParams { UrlValue = "https://example.com/webhooks" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EventTypes);
        Assert.False(parameters.RawBodyData.ContainsKey("event_types"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WebhookCreateParams
        {
            UrlValue = "https://example.com/webhooks",

            Description = null,
            EventTypes = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.EventTypes);
        Assert.True(parameters.RawBodyData.ContainsKey("event_types"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookCreateParams parameters = new() { UrlValue = "https://example.com/webhooks" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/webhooks"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookCreateParams
        {
            UrlValue = "https://example.com/webhooks",
            Description = "Production webhook for match notifications",
            EventTypes = [EventType.MatchCompleted, EventType.TeamMemberTransferred],
        };

        WebhookCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EventTypeTest : TestBase
{
    [Theory]
    [InlineData(EventType.MatchCompleted)]
    [InlineData(EventType.TeamMemberTransferred)]
    public void Validation_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EventType.MatchCompleted)]
    [InlineData(EventType.TeamMemberTransferred)]
    public void SerializationRoundtrip_Works(EventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EventType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
