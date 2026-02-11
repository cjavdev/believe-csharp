using System;
using Believe.Models.Webhooks;

namespace Believe.Tests.Models.Webhooks;

public class WebhookDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookDeleteParams { WebhookID = "webhook_id" };

        string expectedWebhookID = "webhook_id";

        Assert.Equal(expectedWebhookID, parameters.WebhookID);
    }

    [Fact]
    public void Url_Works()
    {
        WebhookDeleteParams parameters = new() { WebhookID = "webhook_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/webhooks/webhook_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookDeleteParams { WebhookID = "webhook_id" };

        WebhookDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
