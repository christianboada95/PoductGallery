namespace ProductGallery.Application.Filters;

public class PaginationFilter
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }

    public PaginationFilter()
    {
        PageIndex = 1;
        PageSize = 10;
    }
    public PaginationFilter(int pageIndex, int pageSize)
    {
        PageIndex = pageIndex < 1 ? 1 : pageIndex;
        PageSize = pageSize > 100 ? 100 : pageSize;
    }
}
