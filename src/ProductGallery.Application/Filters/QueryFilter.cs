namespace ProductGallery.Application.Filters;

public class QueryFilter : PaginationFilter
{
    public QueryFilter(int pageIndex, int pageSize, string input)
        : base(pageIndex, pageSize)
    {
        FindBy = input;
    }

    public string FindBy { get; set; }
}
