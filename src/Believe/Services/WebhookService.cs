using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Webhooks;

namespace Believe.Services;

/// <inheritdoc/>
public sealed class WebhookService : IWebhookService
{
    readonly Lazy<IWebhookServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookService(this._client.WithOptions(modifier));
    }

    public WebhookService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WebhookServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<WebhookCreateResponse> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RegisteredWebhook> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RegisteredWebhook> Retrieve(
        string webhookID,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { WebhookID = webhookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<RegisteredWebhook>> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, JsonElement>> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Dictionary<string, JsonElement>> Delete(
        string webhookID,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { WebhookID = webhookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookTriggerEventResponse> TriggerEvent(
        WebhookTriggerEventParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.TriggerEvent(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class WebhookServiceWithRawResponse : IWebhookServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WebhookServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookCreateResponse>> Create(
        WebhookCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebhookCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhook = await response
                    .Deserialize<WebhookCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhook.Validate();
                }
                return webhook;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RegisteredWebhook>> Retrieve(
        WebhookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookID == null)
        {
            throw new BelieveInvalidDataException("'parameters.WebhookID' cannot be null");
        }

        HttpRequest<WebhookRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var registeredWebhook = await response
                    .Deserialize<RegisteredWebhook>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    registeredWebhook.Validate();
                }
                return registeredWebhook;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RegisteredWebhook>> Retrieve(
        string webhookID,
        WebhookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { WebhookID = webhookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<RegisteredWebhook>>> List(
        WebhookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WebhookListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var registeredWebhooks = await response
                    .Deserialize<List<RegisteredWebhook>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in registeredWebhooks)
                    {
                        item.Validate();
                    }
                }
                return registeredWebhooks;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, JsonElement>>> Delete(
        WebhookDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WebhookID == null)
        {
            throw new BelieveInvalidDataException("'parameters.WebhookID' cannot be null");
        }

        HttpRequest<WebhookDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response
                    .Deserialize<Dictionary<string, JsonElement>>(token)
                    .ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Dictionary<string, JsonElement>>> Delete(
        string webhookID,
        WebhookDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { WebhookID = webhookID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookTriggerEventResponse>> TriggerEvent(
        WebhookTriggerEventParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebhookTriggerEventParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<WebhookTriggerEventResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
