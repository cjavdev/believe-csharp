using System;
using System.Threading;
using System.Threading.Tasks;
using Believe.Client.Core;
using Believe.Client.Models.Client.Ws;

namespace Believe.Client.Services.Client;

/// <summary>
/// WebSocket endpoints for real-time bidirectional communication - Live match simulation
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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

    /// <summary>
    /// Simple WebSocket test endpoint for connectivity testing.
    ///
    /// <para>Connect to test WebSocket functionality. The server will: 1. Send a
    /// welcome message on connection 2. Echo back any message you send</para>
    ///
    /// <para>## Example</para>
    ///
    /// <para>```javascript const ws = new WebSocket('ws://localhost:8000/ws/test');
    /// ws.onmessage = (event) => console.log(event.data); ws.send('Hello!');  // Server
    /// responds with echo ``` </para>
    /// </summary>
    Task Test(WTestParams? parameters = null, CancellationToken cancellationToken = default);
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

    /// <summary>
    /// Returns a raw HTTP response for <c>get /ws/test</c>, but is otherwise the
    /// same as <see cref="IWService.Test(WTestParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Test(
        WTestParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
