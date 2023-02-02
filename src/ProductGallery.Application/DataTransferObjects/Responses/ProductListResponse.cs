namespace ProductGallery.Application.DataTransferObjects.Responses;

public class ProductListResponse : PagedResponse<List<ProductRecord>>
{
    public ProductListResponse(List<ProductRecord> data, int pageNumber, int pageSize) : base(data, pageNumber, pageSize)
    {
    }
}

public record ProductRecord(string Id, string Name, string Description);
