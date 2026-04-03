using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Coaching.Principles;

namespace Believe.Services.Coaching;

/// <inheritdoc/>
public sealed class PrincipleService : IPrincipleService
{
    readonly Lazy<IPrincipleServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPrincipleServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public IPrincipleService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PrincipleService(this._client.WithOptions(modifier)); }

    public PrincipleService (IBelieveClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PrincipleServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<CoachingPrinciple> Retrieve(
        PrincipleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<CoachingPrinciple> Retrieve(
        string principleID,
        PrincipleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PrincipleID = principleID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PrincipleListPage> List(
        PrincipleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CoachingPrinciple> GetRandom(
        PrincipleGetRandomParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetRandom(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PrincipleServiceWithRawResponse : IPrincipleServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPrincipleServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PrincipleServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PrincipleServiceWithRawResponse (
        IBelieveClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<CoachingPrinciple>> Retrieve(
        PrincipleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PrincipleID == null)
        {
            throw new BelieveInvalidDataException(
                "'parameters.PrincipleID' cannot be null"
            );
        }

        HttpRequest<PrincipleRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var coachingPrinciple = await response.Deserialize<CoachingPrinciple>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                coachingPrinciple.Validate();
            }
            return coachingPrinciple;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<CoachingPrinciple>> Retrieve(
        string principleID,
        PrincipleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            PrincipleID = principleID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PrincipleListPage>> List(
        PrincipleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PrincipleListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PrincipleListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PrincipleListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CoachingPrinciple>> GetRandom(
        PrincipleGetRandomParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PrincipleGetRandomParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var coachingPrinciple = await response.Deserialize<CoachingPrinciple>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                coachingPrinciple.Validate();
            }
            return coachingPrinciple;
        });
    }
}