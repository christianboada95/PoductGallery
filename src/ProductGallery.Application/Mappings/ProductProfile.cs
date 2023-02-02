using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProductGallery.Application.DataTransferObjects.Responses;
using ProductGallery.Application.Utilities;
using ProductGallery.Domain.Entities;

namespace ProductGallery.Application.Mappings;

internal class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<IFormFile, ProductImage>().ConstructUsing(p =>
            new ProductImage(p.FileName, p.ContentType, p.ToBytes().Result));

        CreateMap<Product, ProductRecord>();
    }
}
