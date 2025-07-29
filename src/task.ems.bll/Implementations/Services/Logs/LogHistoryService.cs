namespace task.ems.bll.Implementations.Services.Logs;

internal sealed class LogHistoryService(ILogHistoryRepository logHistoryRepository)
    : ILogHistoryService
{
    public async Task<PaginationResponse<IEnumerable<LogHistory>>> PaginateAsync(
        PaginateLogsRequest request,
        CancellationToken cancellationToken = default
    )
    {
        int totalCount = await logHistoryRepository.CountAsync(cancellationToken);

        var employees = await logHistoryRepository.PaginateAsync(
            request.PageIndex,
            request.PageSize,
            request.SortDirection,
            cancellationToken
        );
        return new()
        {
            Count = employees.Count,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalCount = totalCount,
            Result = employees.Select(log => log),
        };
    }
}
