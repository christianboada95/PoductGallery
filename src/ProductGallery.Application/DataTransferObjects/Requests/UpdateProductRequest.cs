using Microsoft.AspNetCore.Http;

namespace ProductGallery.Application.DataTransferObjects.Requests;

public class UpdateProductRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public IFormFile Image { get; set; }
}
