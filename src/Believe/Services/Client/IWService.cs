using System;
using Believe.Core;

namespace Believe.Services.Client;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWService WithOptions(Func<ClientOptions, ClientOptions> modifier);
}

/// <summary>
/// A view of <see cref="IWService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);
}
