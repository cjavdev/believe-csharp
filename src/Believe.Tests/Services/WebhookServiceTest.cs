using System.Threading.Tasks;
using Believe.Models.Webhooks;

namespace Believe.Tests.Services;

public class WebhookServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var webhook = await this.client.Webhooks.Create(new()
        {
            UrlValue = "https://example.com/webhooks"
        }, TestContext.Current.CancellationToken);
        webhook.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var registeredWebhook = await this.client.Webhooks.Retrieve("webhook_id",
        new(), TestContext.Current.CancellationToken);
        registeredWebhook.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var registeredWebhooks = await this.client.Webhooks.List(new(), TestContext.Current.CancellationToken);
        foreach (var item in registeredWebhooks)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Webhooks.Delete("webhook_id",
        new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task TriggerEvent_Works()
    {
        var response = await this.client.Webhooks.TriggerEvent(new()
        {
            EventType = WebhookTriggerEventParamsEventType.MatchCompleted
        }, TestContext.Current.CancellationToken);
        response.Validate();
    }
}