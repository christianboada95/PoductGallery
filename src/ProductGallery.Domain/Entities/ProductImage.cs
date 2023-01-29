using System;
using ProductGallery.Domain.Commom;

namespace ProductGallery.Domain.Entities;

public class ProductImage : FileBase
{
    public ProductImage(string fileName, string contentType, byte[] documentBytes)
        : base(fileName, contentType, documentBytes)
    {
    }
}

