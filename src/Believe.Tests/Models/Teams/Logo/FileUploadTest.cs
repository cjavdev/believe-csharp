using System;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Teams.Logo;

namespace Believe.Tests.Models.Teams.Logo;

public class FileUploadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileUpload
        {
            ChecksumSha256 = "checksum_sha256",ContentType = "content_type",FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",Filename = "filename",SizeBytes = 0,UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedChecksumSha256 = "checksum_sha256";
        string expectedContentType = "content_type";
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFilename = "filename";
        long expectedSizeBytes = 0;
        DateTimeOffset expectedUploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedChecksumSha256, model.ChecksumSha256);
        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.Equal(expectedUploadedAt, model.UploadedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileUpload
        {
            ChecksumSha256 = "checksum_sha256",ContentType = "content_type",FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",Filename = "filename",SizeBytes = 0,UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileUpload>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileUpload
        {
            ChecksumSha256 = "checksum_sha256",ContentType = "content_type",FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",Filename = "filename",SizeBytes = 0,UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileUpload>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedChecksumSha256 = "checksum_sha256";
        string expectedContentType = "content_type";
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFilename = "filename";
        long expectedSizeBytes = 0;
        DateTimeOffset expectedUploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedChecksumSha256, deserialized.ChecksumSha256);
        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.Equal(expectedUploadedAt, deserialized.UploadedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileUpload
        {
            ChecksumSha256 = "checksum_sha256",ContentType = "content_type",FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",Filename = "filename",SizeBytes = 0,UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileUpload
        {
            ChecksumSha256 = "checksum_sha256",ContentType = "content_type",FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",Filename = "filename",SizeBytes = 0,UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        FileUpload copied = new(model);

        Assert.Equal(model, copied);
    }
}