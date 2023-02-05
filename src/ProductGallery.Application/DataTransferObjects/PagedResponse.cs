namespace ProductGallery.Application.DataTransferObjects;

public class PagedResponse<T> : Response<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }

    public PagedResponse(T data, int pageNumber, int pageSize)
        : base(data)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Data = data;
    }

    public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords)
        : base(data)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Data = data;
        TotalRecords = totalRecords;
        TotalPages = totalRecords / pageSize;
    }
}
