namespace ProductGallery.Application.DataTransferObjects.Responses;

public class CreateProductResponse
{
    public string Id { get; set; }
    public string Name { get; set; }

    public CreateProductResponse(string id, string name)
    {
        Id = id;
        Name = name;
    }
}
