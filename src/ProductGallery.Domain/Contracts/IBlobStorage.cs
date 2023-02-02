using System;
using Azure.Storage.Blobs.Models;
namespace ProductGallery.Domain.Contracts;

public interface IBlobStorage
{
    Task<BlobContentInfo> UploadBinaryAsync(string filename, byte[] bytes);
    Task<BlobDownloadResult> DownloadBinaryAsync(string filename);
}

