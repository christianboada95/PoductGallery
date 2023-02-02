using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ProductGallery.Domain.Contracts;

namespace ProductGallery.SharedKernel;

public class BlobStorageBase : IBlobStorage
{
    protected readonly BlobServiceClient blobServiceClient;
    protected readonly BlobContainerClient blobContainerClient;

    public BlobStorageBase(BlobServiceClient blobServiceClient, BlobContainerClient blobContainerClient)
    {
        this.blobServiceClient = blobServiceClient;
        this.blobContainerClient = blobContainerClient;
    }

    public async Task<BlobDownloadResult> DownloadBinaryAsync(string filename)
    {
        BlobClient blobClient = blobContainerClient.GetBlobClient(filename);
        BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();
        return downloadResult;
    }

    public async Task<BlobContentInfo> UploadBinaryAsync(string filename, byte[] bytes)
    {
        BinaryData binary = new(bytes);
        BlobContentInfo response = await blobContainerClient.UploadBlobAsync(filename, binary);
        return response;
    }
}
