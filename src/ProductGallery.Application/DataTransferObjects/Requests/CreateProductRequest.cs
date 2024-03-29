﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ProductGallery.Application.DataTransferObjects.Requests;

public class CreateProductRequest
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public Guid CategoryId { get; set; }
    [Required]
    public IFormFile Image { get; set; }
}
