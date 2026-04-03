using System;
using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Webhooks;

namespace Believe.Tests.Models.Webhooks;

public class RegisteredWebhookTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RegisteredWebhook
        {
            ID = "wh_abc123",CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),EventTypes =
            [
                RegisteredWebhookEventType.MatchCompleted
            ],Secret = "whsec_abc123def456...",Url = "https://example.com",Description = "description",
        };

        string expectedID = "wh_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, RegisteredWebhookEventType>> expectedEventTypes =
        [
            RegisteredWebhookEventType.MatchCompleted
        ];
        string expectedSecret = "whsec_abc123def456...";
        string expectedUrl = "https://example.com";
        string expectedDescription = "description";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, model.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], model.EventTypes[i]);
        }
        Assert.Equal(expectedSecret, model.Secret);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RegisteredWebhook
        {
            ID = "wh_abc123",CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),EventTypes =
            [
                RegisteredWebhookEventType.MatchCompleted
            ],Secret = "whsec_abc123def456...",Url = "https://example.com",Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegisteredWebhook>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RegisteredWebhook
        {
            ID = "wh_abc123",CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),EventTypes =
            [
                RegisteredWebhookEventType.MatchCompleted
            ],Secret = "whsec_abc123def456...",Url = "https://example.com",Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegisteredWebhook>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "wh_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, RegisteredWebhookEventType>> expectedEventTypes =
        [
            RegisteredWebhookEventType.MatchCompleted
        ];
        string expectedSecret = "whsec_abc123def456...";
        string expectedUrl = "https://example.com";
        string expectedDescription = "description";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEventTypes.Count, deserialized.EventTypes.Count);
        for (int i = 0; i < expectedEventTypes.Count; i++)
        {
            Assert.Equal(expectedEventTypes[i], deserialized.EventTypes[i]);
        }
        Assert.Equal(expectedSecret, deserialized.Secret);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RegisteredWebhook
        {
            ID = "wh_abc123",CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),EventTypes =
            [
                RegisteredWebhookEventType.MatchCompleted
            ],Secret = "whsec_abc123def456...",Url = "https://example.com",Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RegisteredWebhook
        {
            ID = "wh_abc123",CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),EventTypes =
            [
                RegisteredWebhookEventType.MatchCompleted
            ],Secret = "whsec_abc123def456...",Url = "https://example.com",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));

    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RegisteredWebhook
        {
            ID = "wh_abc123",CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),EventTypes =
            [
                RegisteredWebhookEventType.MatchCompleted
            ],Secret = "whsec_abc123def456...",Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RegisteredWebhook
        {
            ID = "wh_abc123",CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),EventTypes =
            [
                RegisteredWebhookEventType.MatchCompleted
            ],Secret = "whsec_abc123def456...",Url = "https://example.com",

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));

    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RegisteredWebhook
        {
            ID = "wh_abc123",CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),EventTypes =
            [
                RegisteredWebhookEventType.MatchCompleted
            ],Secret = "whsec_abc123def456...",Url = "https://example.com",

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RegisteredWebhook
        {
            ID = "wh_abc123",CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),EventTypes =
            [
                RegisteredWebhookEventType.MatchCompleted
            ],Secret = "whsec_abc123def456...",Url = "https://example.com",Description = "description",
        };

        RegisteredWebhook copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RegisteredWebhookEventTypeTest : TestBase
{
    [Theory][InlineData(RegisteredWebhookEventType.MatchCompleted)][InlineData(RegisteredWebhookEventType.TeamMemberTransferred)]
    public void Validation_Works(RegisteredWebhookEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RegisteredWebhookEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RegisteredWebhookEventType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(RegisteredWebhookEventType.MatchCompleted)][InlineData(RegisteredWebhookEventType.TeamMemberTransferred)]
    public void SerializationRoundtrip_Works(
        RegisteredWebhookEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RegisteredWebhookEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RegisteredWebhookEventType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RegisteredWebhookEventType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RegisteredWebhookEventType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}