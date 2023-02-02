namespace ProductGallery.Application.DataTransferObjects.Requests;

public class ListPagedProductRequest
{
    public int PageIndex { get; init; }
    public int PageSize { get; init; } = 50;
    public string FindBy { get; init; } = string.Empty;

    public string? OrderBy { get; init; }
}
