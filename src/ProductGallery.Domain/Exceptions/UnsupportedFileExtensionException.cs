using System.Runtime.Serialization;

namespace ProductGallery.Domain.Exceptions;

[Serializable]
public class UnsupportedFileExtensionException : Exception
{
    public UnsupportedFileExtensionException()
    {
    }

    public UnsupportedFileExtensionException(string? message) : base(message)
    {
    }

    public UnsupportedFileExtensionException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UnsupportedFileExtensionException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
