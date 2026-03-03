using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Models.Teams.Logo;

namespace Believe.Services.Teams;

/// <summary>
/// Operations related to football teams
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILogoService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILogoServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILogoService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Delete a team's logo.
    /// </summary>
    Task Delete(LogoDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(LogoDeleteParams, CancellationToken)"/>
    Task Delete(
        string fileID,
        LogoDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Download a team's logo by file ID.
    /// </summary>
    Task<JsonElement> Download(
        LogoDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(LogoDownloadParams, CancellationToken)"/>
    Task<JsonElement> Download(
        string fileID,
        LogoDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload a logo image for a team. Accepts image files (jpg, png, gif, webp).
    /// </summary>
    Task<FileUpload> Upload(
        LogoUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upload(LogoUploadParams, CancellationToken)"/>
    Task<FileUpload> Upload(
        string teamID,
        LogoUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILogoService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILogoServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILogoServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `delete /teams/{team_id}/logo/{file_id}`, but is otherwise the
    /// same as <see cref="ILogoService.Delete(LogoDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        LogoDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(LogoDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string fileID,
        LogoDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /teams/{team_id}/logo/{file_id}`, but is otherwise the
    /// same as <see cref="ILogoService.Download(LogoDownloadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> Download(
        LogoDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Download(LogoDownloadParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> Download(
        string fileID,
        LogoDownloadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /teams/{team_id}/logo`, but is otherwise the
    /// same as <see cref="ILogoService.Upload(LogoUploadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileUpload>> Upload(
        LogoUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upload(LogoUploadParams, CancellationToken)"/>
    Task<HttpResponse<FileUpload>> Upload(
        string teamID,
        LogoUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}
