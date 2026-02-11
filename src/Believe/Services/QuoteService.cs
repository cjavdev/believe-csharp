using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Quotes;

namespace Believe.Services;

/// <inheritdoc/>
public sealed class QuoteService : IQuoteService
{
    readonly Lazy<IQuoteServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IQuoteServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IQuoteService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new QuoteService(this._client.WithOptions(modifier));
    }

    public QuoteService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new QuoteServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Quote> Create(
        QuoteCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Quote> Retrieve(
        QuoteRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Quote> Retrieve(
        string quoteID,
        QuoteRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { QuoteID = quoteID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Quote> Update(
        QuoteUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Quote> Update(
        string quoteID,
        QuoteUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { QuoteID = quoteID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<QuoteListPage> List(
        QuoteListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(QuoteDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string quoteID,
        QuoteDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { QuoteID = quoteID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Quote> GetRandom(
        QuoteGetRandomParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetRandom(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<QuoteListByCharacterPage> ListByCharacter(
        QuoteListByCharacterParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByCharacter(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<QuoteListByCharacterPage> ListByCharacter(
        string characterID,
        QuoteListByCharacterParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListByCharacter(
            parameters with
            {
                CharacterID = characterID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<QuoteListByThemePage> ListByTheme(
        QuoteListByThemeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByTheme(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<QuoteListByThemePage> ListByTheme(
        ApiEnum<string, QuoteTheme> theme,
        QuoteListByThemeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListByTheme(parameters with { Theme = theme }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class QuoteServiceWithRawResponse : IQuoteServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IQuoteServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new QuoteServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public QuoteServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Quote>> Create(
        QuoteCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<QuoteCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var quote = await response.Deserialize<Quote>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    quote.Validate();
                }
                return quote;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Quote>> Retrieve(
        QuoteRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.QuoteID == null)
        {
            throw new BelieveInvalidDataException("'parameters.QuoteID' cannot be null");
        }

        HttpRequest<QuoteRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var quote = await response.Deserialize<Quote>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    quote.Validate();
                }
                return quote;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Quote>> Retrieve(
        string quoteID,
        QuoteRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { QuoteID = quoteID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Quote>> Update(
        QuoteUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.QuoteID == null)
        {
            throw new BelieveInvalidDataException("'parameters.QuoteID' cannot be null");
        }

        HttpRequest<QuoteUpdateParams> request = new()
        {
            Method = BelieveClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var quote = await response.Deserialize<Quote>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    quote.Validate();
                }
                return quote;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Quote>> Update(
        string quoteID,
        QuoteUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { QuoteID = quoteID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<QuoteListPage>> List(
        QuoteListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<QuoteListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<PaginatedResponseQuote>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new QuoteListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        QuoteDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.QuoteID == null)
        {
            throw new BelieveInvalidDataException("'parameters.QuoteID' cannot be null");
        }

        HttpRequest<QuoteDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string quoteID,
        QuoteDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { QuoteID = quoteID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Quote>> GetRandom(
        QuoteGetRandomParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<QuoteGetRandomParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var quote = await response.Deserialize<Quote>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    quote.Validate();
                }
                return quote;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<QuoteListByCharacterPage>> ListByCharacter(
        QuoteListByCharacterParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CharacterID == null)
        {
            throw new BelieveInvalidDataException("'parameters.CharacterID' cannot be null");
        }

        HttpRequest<QuoteListByCharacterParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<PaginatedResponseQuote>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new QuoteListByCharacterPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<QuoteListByCharacterPage>> ListByCharacter(
        string characterID,
        QuoteListByCharacterParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListByCharacter(
            parameters with
            {
                CharacterID = characterID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<QuoteListByThemePage>> ListByTheme(
        QuoteListByThemeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Theme == null)
        {
            throw new BelieveInvalidDataException("'parameters.Theme' cannot be null");
        }

        HttpRequest<QuoteListByThemeParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<PaginatedResponseQuote>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new QuoteListByThemePage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<QuoteListByThemePage>> ListByTheme(
        ApiEnum<string, QuoteTheme> theme,
        QuoteListByThemeParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListByTheme(parameters with { Theme = theme }, cancellationToken);
    }
}
