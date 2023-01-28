namespace ProductGallery.Application.DataTransferObjects.Responses;

public class ProductListResponse
{
    public List<ProductRecord> Products { get; set; } = new();
}

public record ProductRecord(string Id, string Name, string Description);
