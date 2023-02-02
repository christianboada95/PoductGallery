using System.Runtime.Serialization;

namespace ProductGallery.Domain.Exceptions;

[Serializable]
public class NotFoundException : ApiException
{
    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
