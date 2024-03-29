﻿using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using ProductGallery.Domain.Contracts;
using ProductGallery.Domain.Entities;
using ProductGallery.Persistence.Data;
using ProductGallery.SharedKernel;

namespace ProductGallery.Persistence.Storages;

public class ImageStorage : BlobStorageBase, IFileStorage<ProductImage>
{
    private readonly AppStorageClient _appStorageClient;
    //private readonly IConfiguration _configuration;

    public ImageStorage(AppStorageClient appStorageClient, IConfiguration configuration)
        : base(appStorageClient, appStorageClient.GetBlobContainerClient("productimages"))
        => _appStorageClient = appStorageClient;

    public Task DeleteFileAsync(ProductImage file, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Return Blob Uploaded file URL
    /// </summary>
    /// <param name="file"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<string> SaveFileAsync(ProductImage file, CancellationToken cancellationToken = default)
    {
        await blobContainerClient.CreateIfNotExistsAsync();

        var blobContentInfo = await UploadBinaryAsync(file.FileName, file.DocumentBytes);

        var blobClient = blobContainerClient.GetBlobClient(file.FileName);
        BlobHttpHeaders blobHttpHeaders = new() { ContentType = file.ContentType, ContentHash = file.GetFileHash() };
        blobClient.SetHttpHeaders(blobHttpHeaders);
        return blobClient.Uri.AbsoluteUri;
    }
}

