using System;
using Believe.Client.Core;
using Believe.Client.Services.Coaching;

namespace Believe.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICoachingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICoachingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICoachingService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPrincipleService Principles { get; }
}

/// <summary>
/// A view of <see cref="ICoachingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICoachingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICoachingServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IPrincipleServiceWithRawResponse Principles { get; }
}
