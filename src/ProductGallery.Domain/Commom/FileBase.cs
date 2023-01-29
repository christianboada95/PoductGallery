using System;
namespace ProductGallery.Domain.Commom;

public abstract class FileBase
{
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] DocumentBytes { get; set; }

    public FileBase(string fileName, string contentType, byte[] documentBytes)
    {
        FileName = fileName;
        ContentType = contentType;
        DocumentBytes = documentBytes;
    }
}
