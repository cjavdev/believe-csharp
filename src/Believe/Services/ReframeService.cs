using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Reframe;

namespace Believe.Services;

/// <inheritdoc/>
public sealed class ReframeService : IReframeService
{
    readonly Lazy<IReframeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReframeServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IReframeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ReframeService(this._client.WithOptions(modifier)); }

    public ReframeService (IBelieveClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ReframeServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<ReframeTransformNegativeThoughtsResponse> TransformNegativeThoughts(
        ReframeTransformNegativeThoughtsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.TransformNegativeThoughts(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ReframeServiceWithRawResponse : IReframeServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReframeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ReframeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReframeServiceWithRawResponse (IBelieveClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReframeTransformNegativeThoughtsResponse>> TransformNegativeThoughts(
        ReframeTransformNegativeThoughtsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ReframeTransformNegativeThoughtsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ReframeTransformNegativeThoughtsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }
}