using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Teams.Logo;

/// <summary>
/// Response model for file uploads.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileUpload, FileUploadFromRaw>))]
public sealed record class FileUpload : JsonModel
{
    public required string ChecksumSha256 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "checksum_sha256"
            );
        }
        init { this._rawData.Set("checksum_sha256", value); }
    }

    public required string ContentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "content_type"
            );
        }
        init { this._rawData.Set("content_type", value); }
    }

    public required string FileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "file_id"
            );
        }
        init { this._rawData.Set("file_id", value); }
    }

    public required string Filename {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "filename"
            );
        }
        init { this._rawData.Set("filename", value); }
    }

    public required long SizeBytes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "size_bytes"
            );
        }
        init { this._rawData.Set("size_bytes", value); }
    }

    public required DateTimeOffset UploadedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "uploaded_at"
            );
        }
        init { this._rawData.Set("uploaded_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChecksumSha256;
        _ = this.ContentType;
        _ = this.FileID;
        _ = this.Filename;
        _ = this.SizeBytes;
        _ = this.UploadedAt;
    }

    public FileUpload ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUpload (FileUpload fileUpload) : base(fileUpload)
    {  }
    #pragma warning restore CS8618

    public FileUpload (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUpload (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FileUploadFromRaw.FromRawUnchecked"/>
    public static FileUpload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FileUploadFromRaw : IFromRawJson<FileUpload>
{
    /// <inheritdoc/>
    public FileUpload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FileUpload.FromRawUnchecked(rawData);
}