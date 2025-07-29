namespace task.ems.bll.Bases.Requests;

public record PaginateRequest
{
    public virtual int PageIndex { get; set; } = 1;
    public virtual int PageSize { get; set; } = 10;
    public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
}
