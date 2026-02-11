using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Teams.Logo;

namespace Believe.Services.Teams;

/// <inheritdoc/>
public sealed class LogoService : ILogoService
{
    readonly Lazy<ILogoServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILogoServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IBelieveClient _client;

    /// <inheritdoc/>
    public ILogoService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LogoService(this._client.WithOptions(modifier));
    }

    public LogoService(IBelieveClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LogoServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task Delete(LogoDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string fileID,
        LogoDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { FileID = fileID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Download(
        LogoDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Download(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JsonElement> Download(
        string fileID,
        LogoDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Download(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FileUpload> Upload(
        LogoUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Upload(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FileUpload> Upload(
        string teamID,
        LogoUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upload(parameters with { TeamID = teamID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class LogoServiceWithRawResponse : ILogoServiceWithRawResponse
{
    readonly IBelieveClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILogoServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LogoServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LogoServiceWithRawResponse(IBelieveClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        LogoDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new BelieveInvalidDataException("'parameters.FileID' cannot be null");
        }

        HttpRequest<LogoDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string fileID,
        LogoDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> Download(
        LogoDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new BelieveInvalidDataException("'parameters.FileID' cannot be null");
        }

        HttpRequest<LogoDownloadParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> Download(
        string fileID,
        LogoDownloadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Download(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileUpload>> Upload(
        LogoUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TeamID == null)
        {
            throw new BelieveInvalidDataException("'parameters.TeamID' cannot be null");
        }

        HttpRequest<LogoUploadParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fileUpload = await response
                    .Deserialize<FileUpload>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    fileUpload.Validate();
                }
                return fileUpload;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FileUpload>> Upload(
        string teamID,
        LogoUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upload(parameters with { TeamID = teamID }, cancellationToken);
    }
}
