using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Webhooks;

namespace Believe.Tests.Models.Webhooks;

public class WebhookTriggerEventResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookTriggerEventResponse
        {
            Deliveries =
            [
                new()
                {
                    Success = true,
                    Url = "url",
                    WebhookID = "webhook_id",
                    Error = "error",
                    StatusCode = 0,
                },
            ],
            EventID = "event_id",
            EventType = WebhookTriggerEventResponseEventType.MatchCompleted,
            SuccessfulDeliveries = 0,
            TedSays = "ted_says",
            TotalWebhooks = 0,
        };

        List<Delivery> expectedDeliveries =
        [
            new()
            {
                Success = true,
                Url = "url",
                WebhookID = "webhook_id",
                Error = "error",
                StatusCode = 0,
            },
        ];
        string expectedEventID = "event_id";
        ApiEnum<string, WebhookTriggerEventResponseEventType> expectedEventType =
            WebhookTriggerEventResponseEventType.MatchCompleted;
        long expectedSuccessfulDeliveries = 0;
        string expectedTedSays = "ted_says";
        long expectedTotalWebhooks = 0;

        Assert.Equal(expectedDeliveries.Count, model.Deliveries.Count);
        for (int i = 0; i < expectedDeliveries.Count; i++)
        {
            Assert.Equal(expectedDeliveries[i], model.Deliveries[i]);
        }
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedEventType, model.EventType);
        Assert.Equal(expectedSuccessfulDeliveries, model.SuccessfulDeliveries);
        Assert.Equal(expectedTedSays, model.TedSays);
        Assert.Equal(expectedTotalWebhooks, model.TotalWebhooks);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookTriggerEventResponse
        {
            Deliveries =
            [
                new()
                {
                    Success = true,
                    Url = "url",
                    WebhookID = "webhook_id",
                    Error = "error",
                    StatusCode = 0,
                },
            ],
            EventID = "event_id",
            EventType = WebhookTriggerEventResponseEventType.MatchCompleted,
            SuccessfulDeliveries = 0,
            TedSays = "ted_says",
            TotalWebhooks = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookTriggerEventResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookTriggerEventResponse
        {
            Deliveries =
            [
                new()
                {
                    Success = true,
                    Url = "url",
                    WebhookID = "webhook_id",
                    Error = "error",
                    StatusCode = 0,
                },
            ],
            EventID = "event_id",
            EventType = WebhookTriggerEventResponseEventType.MatchCompleted,
            SuccessfulDeliveries = 0,
            TedSays = "ted_says",
            TotalWebhooks = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookTriggerEventResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Delivery> expectedDeliveries =
        [
            new()
            {
                Success = true,
                Url = "url",
                WebhookID = "webhook_id",
                Error = "error",
                StatusCode = 0,
            },
        ];
        string expectedEventID = "event_id";
        ApiEnum<string, WebhookTriggerEventResponseEventType> expectedEventType =
            WebhookTriggerEventResponseEventType.MatchCompleted;
        long expectedSuccessfulDeliveries = 0;
        string expectedTedSays = "ted_says";
        long expectedTotalWebhooks = 0;

        Assert.Equal(expectedDeliveries.Count, deserialized.Deliveries.Count);
        for (int i = 0; i < expectedDeliveries.Count; i++)
        {
            Assert.Equal(expectedDeliveries[i], deserialized.Deliveries[i]);
        }
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedEventType, deserialized.EventType);
        Assert.Equal(expectedSuccessfulDeliveries, deserialized.SuccessfulDeliveries);
        Assert.Equal(expectedTedSays, deserialized.TedSays);
        Assert.Equal(expectedTotalWebhooks, deserialized.TotalWebhooks);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookTriggerEventResponse
        {
            Deliveries =
            [
                new()
                {
                    Success = true,
                    Url = "url",
                    WebhookID = "webhook_id",
                    Error = "error",
                    StatusCode = 0,
                },
            ],
            EventID = "event_id",
            EventType = WebhookTriggerEventResponseEventType.MatchCompleted,
            SuccessfulDeliveries = 0,
            TedSays = "ted_says",
            TotalWebhooks = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookTriggerEventResponse
        {
            Deliveries =
            [
                new()
                {
                    Success = true,
                    Url = "url",
                    WebhookID = "webhook_id",
                    Error = "error",
                    StatusCode = 0,
                },
            ],
            EventID = "event_id",
            EventType = WebhookTriggerEventResponseEventType.MatchCompleted,
            SuccessfulDeliveries = 0,
            TedSays = "ted_says",
            TotalWebhooks = 0,
        };

        WebhookTriggerEventResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeliveryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Delivery
        {
            Success = true,
            Url = "url",
            WebhookID = "webhook_id",
            Error = "error",
            StatusCode = 0,
        };

        bool expectedSuccess = true;
        string expectedUrl = "url";
        string expectedWebhookID = "webhook_id";
        string expectedError = "error";
        long expectedStatusCode = 0;

        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedWebhookID, model.WebhookID);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedStatusCode, model.StatusCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Delivery
        {
            Success = true,
            Url = "url",
            WebhookID = "webhook_id",
            Error = "error",
            StatusCode = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delivery>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Delivery
        {
            Success = true,
            Url = "url",
            WebhookID = "webhook_id",
            Error = "error",
            StatusCode = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delivery>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedSuccess = true;
        string expectedUrl = "url";
        string expectedWebhookID = "webhook_id";
        string expectedError = "error";
        long expectedStatusCode = 0;

        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedWebhookID, deserialized.WebhookID);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedStatusCode, deserialized.StatusCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Delivery
        {
            Success = true,
            Url = "url",
            WebhookID = "webhook_id",
            Error = "error",
            StatusCode = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Delivery
        {
            Success = true,
            Url = "url",
            WebhookID = "webhook_id",
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.StatusCode);
        Assert.False(model.RawData.ContainsKey("status_code"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Delivery
        {
            Success = true,
            Url = "url",
            WebhookID = "webhook_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Delivery
        {
            Success = true,
            Url = "url",
            WebhookID = "webhook_id",

            Error = null,
            StatusCode = null,
        };

        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
        Assert.Null(model.StatusCode);
        Assert.True(model.RawData.ContainsKey("status_code"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Delivery
        {
            Success = true,
            Url = "url",
            WebhookID = "webhook_id",

            Error = null,
            StatusCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Delivery
        {
            Success = true,
            Url = "url",
            WebhookID = "webhook_id",
            Error = "error",
            StatusCode = 0,
        };

        Delivery copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookTriggerEventResponseEventTypeTest : TestBase
{
    [Theory]
    [InlineData(WebhookTriggerEventResponseEventType.MatchCompleted)]
    [InlineData(WebhookTriggerEventResponseEventType.TeamMemberTransferred)]
    public void Validation_Works(WebhookTriggerEventResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookTriggerEventResponseEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookTriggerEventResponseEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookTriggerEventResponseEventType.MatchCompleted)]
    [InlineData(WebhookTriggerEventResponseEventType.TeamMemberTransferred)]
    public void SerializationRoundtrip_Works(WebhookTriggerEventResponseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookTriggerEventResponseEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookTriggerEventResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookTriggerEventResponseEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookTriggerEventResponseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
