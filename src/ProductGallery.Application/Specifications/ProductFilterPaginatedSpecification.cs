using ProductGallery.Domain.Entities;
using ProductGallery.SharedKernel;

namespace ProductGallery.Application.Specifications;

public class ProductFilterPaginatedSpecification : SpecificationBase<Product>
{
    public ProductFilterPaginatedSpecification(string input)
        : base(p => !string.IsNullOrEmpty(input) && p.Category.Name.Contains(input) || p.Name.Contains(input))
    {
        //AddInclude(p => p.Category);
        //Queryable.Where<Product>(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
        //    (!typeId.HasValue || i.CatalogTypeId == typeId))
        //    .Skip(skip).Take(take);
    }
}
