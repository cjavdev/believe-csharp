using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Conflicts;

namespace Believe.Services;

/// <inheritdoc/>
public sealed class ConflictService : IConflictService
{
    readonly Lazy<IConflictServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConflictServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IConflictService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ConflictService(this._client.WithOptions(modifier)); }

    public ConflictService (IBelieveClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ConflictServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ConflictResolveResponse> Resolve(
        ConflictResolveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Resolve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ConflictServiceWithRawResponse : IConflictServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConflictServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConflictServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConflictServiceWithRawResponse (IBelieveClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConflictResolveResponse>> Resolve(
        ConflictResolveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ConflictResolveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ConflictResolveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}