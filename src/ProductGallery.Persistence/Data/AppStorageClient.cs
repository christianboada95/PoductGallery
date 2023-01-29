using System;
using Azure.Storage.Blobs;

namespace ProductGallery.Persistence.Data;

public class AppStorageClient : BlobServiceClient
{
    public AppStorageClient() { }

    public AppStorageClient(string connectionString)
        : base(connectionString) { }
}

