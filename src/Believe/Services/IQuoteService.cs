using System;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Quotes;

namespace Believe.Services;

/// <summary>
/// Memorable quotes from the show
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IQuoteService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IQuoteServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IQuoteService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Add a new memorable quote to the collection.
    /// </summary>
    Task<Quote> Create(QuoteCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve a specific quote by its ID.
    /// </summary>
    Task<Quote> Retrieve(
        QuoteRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(QuoteRetrieveParams, CancellationToken)"/>
    Task<Quote> Retrieve(
        string quoteID,
        QuoteRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update specific fields of an existing quote.
    /// </summary>
    Task<Quote> Update(QuoteUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(QuoteUpdateParams, CancellationToken)"/>
    Task<Quote> Update(
        string quoteID,
        QuoteUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a paginated list of all memorable Ted Lasso quotes with optional filtering.
    /// </summary>
    Task<QuoteListPage> List(
        QuoteListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a quote from the collection.
    /// </summary>
    Task Delete(QuoteDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(QuoteDeleteParams, CancellationToken)"/>
    Task Delete(
        string quoteID,
        QuoteDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a random Ted Lasso quote, optionally filtered.
    /// </summary>
    Task<Quote> GetRandom(
        QuoteGetRandomParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a paginated list of quotes from a specific character.
    /// </summary>
    Task<QuoteListByCharacterPage> ListByCharacter(
        QuoteListByCharacterParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByCharacter(QuoteListByCharacterParams, CancellationToken)"/>
    Task<QuoteListByCharacterPage> ListByCharacter(
        string characterID,
        QuoteListByCharacterParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a paginated list of quotes related to a specific theme.
    /// </summary>
    Task<QuoteListByThemePage> ListByTheme(
        QuoteListByThemeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByTheme(QuoteListByThemeParams, CancellationToken)"/>
    Task<QuoteListByThemePage> ListByTheme(
        ApiEnum<string, QuoteTheme> theme,
        QuoteListByThemeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IQuoteService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IQuoteServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IQuoteServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /quotes`, but is otherwise the
    /// same as <see cref="IQuoteService.Create(QuoteCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Quote>> Create(
        QuoteCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /quotes/{quote_id}`, but is otherwise the
    /// same as <see cref="IQuoteService.Retrieve(QuoteRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Quote>> Retrieve(
        QuoteRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(QuoteRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Quote>> Retrieve(
        string quoteID,
        QuoteRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /quotes/{quote_id}`, but is otherwise the
    /// same as <see cref="IQuoteService.Update(QuoteUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Quote>> Update(
        QuoteUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(QuoteUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Quote>> Update(
        string quoteID,
        QuoteUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /quotes`, but is otherwise the
    /// same as <see cref="IQuoteService.List(QuoteListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<QuoteListPage>> List(
        QuoteListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /quotes/{quote_id}`, but is otherwise the
    /// same as <see cref="IQuoteService.Delete(QuoteDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        QuoteDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(QuoteDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string quoteID,
        QuoteDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /quotes/random`, but is otherwise the
    /// same as <see cref="IQuoteService.GetRandom(QuoteGetRandomParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Quote>> GetRandom(
        QuoteGetRandomParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /quotes/characters/{character_id}`, but is otherwise the
    /// same as <see cref="IQuoteService.ListByCharacter(QuoteListByCharacterParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<QuoteListByCharacterPage>> ListByCharacter(
        QuoteListByCharacterParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByCharacter(QuoteListByCharacterParams, CancellationToken)"/>
    Task<HttpResponse<QuoteListByCharacterPage>> ListByCharacter(
        string characterID,
        QuoteListByCharacterParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /quotes/themes/{theme}`, but is otherwise the
    /// same as <see cref="IQuoteService.ListByTheme(QuoteListByThemeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<QuoteListByThemePage>> ListByTheme(
        QuoteListByThemeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListByTheme(QuoteListByThemeParams, CancellationToken)"/>
    Task<HttpResponse<QuoteListByThemePage>> ListByTheme(
        ApiEnum<string, QuoteTheme> theme,
        QuoteListByThemeParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
