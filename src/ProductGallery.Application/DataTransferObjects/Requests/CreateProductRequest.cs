using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ProductGallery.Application.DataTransferObjects.Requests;

public class CreateProductRequest
{
    [Required]
    public string? Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    //public IFormFile Image { get; set; }
}
