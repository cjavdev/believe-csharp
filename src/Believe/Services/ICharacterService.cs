using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Characters;

namespace Believe.Services;

/// <summary>
/// Operations related to Ted Lasso characters
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ICharacterService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICharacterServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICharacterService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Add a new character to the Ted Lasso universe.
    /// </summary>
    Task<Character> Create(
        CharacterCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve detailed information about a specific character.
    /// </summary>
    Task<Character> Retrieve(
        CharacterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CharacterRetrieveParams, CancellationToken)"/>
    Task<Character> Retrieve(
        string characterID,
        CharacterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update specific fields of an existing character.
    /// </summary>
    Task<Character> Update(
        CharacterUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CharacterUpdateParams, CancellationToken)"/>
    Task<Character> Update(
        string characterID,
        CharacterUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a paginated list of Ted Lasso characters.
    /// </summary>
    Task<CharacterListPage> List(
        CharacterListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a character from the database.
    /// </summary>
    Task Delete(CharacterDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(CharacterDeleteParams, CancellationToken)"/>
    Task Delete(
        string characterID,
        CharacterDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get all signature quotes from a specific character.
    /// </summary>
    Task<List<string>> GetQuotes(
        CharacterGetQuotesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetQuotes(CharacterGetQuotesParams, CancellationToken)"/>
    Task<List<string>> GetQuotes(
        string characterID,
        CharacterGetQuotesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICharacterService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICharacterServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICharacterServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /characters`, but is otherwise the
    /// same as <see cref="ICharacterService.Create(CharacterCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Character>> Create(
        CharacterCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /characters/{character_id}`, but is otherwise the
    /// same as <see cref="ICharacterService.Retrieve(CharacterRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Character>> Retrieve(
        CharacterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CharacterRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Character>> Retrieve(
        string characterID,
        CharacterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /characters/{character_id}`, but is otherwise the
    /// same as <see cref="ICharacterService.Update(CharacterUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Character>> Update(
        CharacterUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CharacterUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Character>> Update(
        string characterID,
        CharacterUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /characters`, but is otherwise the
    /// same as <see cref="ICharacterService.List(CharacterListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CharacterListPage>> List(
        CharacterListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /characters/{character_id}`, but is otherwise the
    /// same as <see cref="ICharacterService.Delete(CharacterDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        CharacterDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CharacterDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string characterID,
        CharacterDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /characters/{character_id}/quotes`, but is otherwise the
    /// same as <see cref="ICharacterService.GetQuotes(CharacterGetQuotesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<string>>> GetQuotes(
        CharacterGetQuotesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetQuotes(CharacterGetQuotesParams, CancellationToken)"/>
    Task<HttpResponse<List<string>>> GetQuotes(
        string characterID,
        CharacterGetQuotesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
