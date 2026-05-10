using System;
using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Models.Webhooks;

namespace Believe.Client.Tests.Models.Webhooks;

public class WebhookCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookCreateResponse
        {
            Webhook = new()
            {
                ID = "wh_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [RegisteredWebhookEventType.MatchCompleted],
                Secret = "whsec_abc123def456...",
                Url = "https://example.com",
                Description = "description",
            },
            Message = "message",
            TedSays = "ted_says",
        };

        RegisteredWebhook expectedWebhook = new()
        {
            ID = "wh_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [RegisteredWebhookEventType.MatchCompleted],
            Secret = "whsec_abc123def456...",
            Url = "https://example.com",
            Description = "description",
        };
        string expectedMessage = "message";
        string expectedTedSays = "ted_says";

        Assert.Equal(expectedWebhook, model.Webhook);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedTedSays, model.TedSays);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookCreateResponse
        {
            Webhook = new()
            {
                ID = "wh_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [RegisteredWebhookEventType.MatchCompleted],
                Secret = "whsec_abc123def456...",
                Url = "https://example.com",
                Description = "description",
            },
            Message = "message",
            TedSays = "ted_says",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookCreateResponse
        {
            Webhook = new()
            {
                ID = "wh_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [RegisteredWebhookEventType.MatchCompleted],
                Secret = "whsec_abc123def456...",
                Url = "https://example.com",
                Description = "description",
            },
            Message = "message",
            TedSays = "ted_says",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RegisteredWebhook expectedWebhook = new()
        {
            ID = "wh_abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EventTypes = [RegisteredWebhookEventType.MatchCompleted],
            Secret = "whsec_abc123def456...",
            Url = "https://example.com",
            Description = "description",
        };
        string expectedMessage = "message";
        string expectedTedSays = "ted_says";

        Assert.Equal(expectedWebhook, deserialized.Webhook);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedTedSays, deserialized.TedSays);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookCreateResponse
        {
            Webhook = new()
            {
                ID = "wh_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [RegisteredWebhookEventType.MatchCompleted],
                Secret = "whsec_abc123def456...",
                Url = "https://example.com",
                Description = "description",
            },
            Message = "message",
            TedSays = "ted_says",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookCreateResponse
        {
            Webhook = new()
            {
                ID = "wh_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [RegisteredWebhookEventType.MatchCompleted],
                Secret = "whsec_abc123def456...",
                Url = "https://example.com",
                Description = "description",
            },
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.TedSays);
        Assert.False(model.RawData.ContainsKey("ted_says"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookCreateResponse
        {
            Webhook = new()
            {
                ID = "wh_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [RegisteredWebhookEventType.MatchCompleted],
                Secret = "whsec_abc123def456...",
                Url = "https://example.com",
                Description = "description",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebhookCreateResponse
        {
            Webhook = new()
            {
                ID = "wh_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [RegisteredWebhookEventType.MatchCompleted],
                Secret = "whsec_abc123def456...",
                Url = "https://example.com",
                Description = "description",
            },

            // Null should be interpreted as omitted for these properties
            Message = null,
            TedSays = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.TedSays);
        Assert.False(model.RawData.ContainsKey("ted_says"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookCreateResponse
        {
            Webhook = new()
            {
                ID = "wh_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [RegisteredWebhookEventType.MatchCompleted],
                Secret = "whsec_abc123def456...",
                Url = "https://example.com",
                Description = "description",
            },

            // Null should be interpreted as omitted for these properties
            Message = null,
            TedSays = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookCreateResponse
        {
            Webhook = new()
            {
                ID = "wh_abc123",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EventTypes = [RegisteredWebhookEventType.MatchCompleted],
                Secret = "whsec_abc123def456...",
                Url = "https://example.com",
                Description = "description",
            },
            Message = "message",
            TedSays = "ted_says",
        };

        WebhookCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
