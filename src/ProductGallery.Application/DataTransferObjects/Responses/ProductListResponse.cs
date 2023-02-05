namespace ProductGallery.Application.DataTransferObjects.Responses;

public class ProductListResponse : PagedResponse<List<ProductRecord>>
{
    public ProductListResponse(List<ProductRecord> data, int pageNumber, int pageSize) 
        : base(data, pageNumber, pageSize)
    {
    }

    public ProductListResponse(List<ProductRecord> data, int pageNumber, int pageSize, int totalRecords) 
        : base(data, pageNumber, pageSize, totalRecords)
    {
    }
}

public record ProductRecord(string Id, string Name, string Description, CategoryRecord Category, string ImageUrl, DateTime CreatedAt, DateTime? UpdateAt);

public record CategoryRecord(string Id, string Name, DateTime CreatedAt, DateTime? UpdateAt);
