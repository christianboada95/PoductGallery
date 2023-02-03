using ProductGallery.Domain.Entities;
using ProductGallery.SharedKernel;

namespace ProductGallery.Application.Specifications;

public class ProductFilterPaginatedSpecification : SpecificationBase<Product>
{
    public ProductFilterPaginatedSpecification(int skip, int take, string input)
        : base(p => string.IsNullOrEmpty(input) ||
              (p.Name.Contains(input) || p.Description.Contains(input) ||
               p.Category.Name.Contains(input)))
    {
        if (take == 0)
        {
            take = int.MaxValue;
        }

        AddInclude(p => p.Category);
        AddSkip(skip);
        AddTake(take);
    }
}
