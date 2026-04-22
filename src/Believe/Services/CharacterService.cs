using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Characters;

namespace Believe.Services;

/// <inheritdoc/>
public sealed class CharacterService : ICharacterService
{
    readonly Lazy<ICharacterServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICharacterServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public ICharacterService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CharacterService(this._client.WithOptions(modifier));
    }

    public CharacterService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CharacterServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Character> Create(
        CharacterCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Character> Retrieve(
        CharacterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Character> Retrieve(
        string characterID,
        CharacterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CharacterID = characterID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Character> Update(
        CharacterUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Character> Update(
        string characterID,
        CharacterUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { CharacterID = characterID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CharacterListPage> List(
        CharacterListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        CharacterDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string characterID,
        CharacterDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { CharacterID = characterID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<string>> GetQuotes(
        CharacterGetQuotesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetQuotes(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<string>> GetQuotes(
        string characterID,
        CharacterGetQuotesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetQuotes(parameters with { CharacterID = characterID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CharacterServiceWithRawResponse : ICharacterServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICharacterServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CharacterServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CharacterServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Character>> Create(
        CharacterCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CharacterCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var character = await response.Deserialize<Character>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    character.Validate();
                }
                return character;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Character>> Retrieve(
        CharacterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CharacterID == null)
        {
            throw new BelieveInvalidDataException("'parameters.CharacterID' cannot be null");
        }

        HttpRequest<CharacterRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var character = await response.Deserialize<Character>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    character.Validate();
                }
                return character;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Character>> Retrieve(
        string characterID,
        CharacterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CharacterID = characterID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Character>> Update(
        CharacterUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CharacterID == null)
        {
            throw new BelieveInvalidDataException("'parameters.CharacterID' cannot be null");
        }

        HttpRequest<CharacterUpdateParams> request = new()
        {
            Method = BelieveClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var character = await response.Deserialize<Character>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    character.Validate();
                }
                return character;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Character>> Update(
        string characterID,
        CharacterUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { CharacterID = characterID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CharacterListPage>> List(
        CharacterListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CharacterListParams> request = new()
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
                    .Deserialize<CharacterListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CharacterListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CharacterDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CharacterID == null)
        {
            throw new BelieveInvalidDataException("'parameters.CharacterID' cannot be null");
        }

        HttpRequest<CharacterDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string characterID,
        CharacterDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { CharacterID = characterID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<string>>> GetQuotes(
        CharacterGetQuotesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CharacterID == null)
        {
            throw new BelieveInvalidDataException("'parameters.CharacterID' cannot be null");
        }

        HttpRequest<CharacterGetQuotesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<List<string>>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<string>>> GetQuotes(
        string characterID,
        CharacterGetQuotesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetQuotes(parameters with { CharacterID = characterID }, cancellationToken);
    }
}
