namespace CachacaCanutoWebApi.Models;

public class PagedListMetadata<T>
{
    public int TotalCount { get; }
    public int PageSize { get; }
    public int CurrentPage { get; }
    public int TotalPages { get; }
    public bool HasNext { get; }
    public bool HasPrevious { get; }

    public PagedListMetadata(PagedList<T> pagedList)
    {
        TotalCount = pagedList.TotalCount;
        PageSize = pagedList.PageSize;
        CurrentPage = pagedList.CurrentPage;
        TotalPages = pagedList.TotalPages;
        HasNext = pagedList.HasNext;
        HasPrevious = pagedList.HasPrevious;
    }
}
