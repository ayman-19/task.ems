namespace task.ems.bll.Abstractions.Services.Logs;

public interface ILogHistoryService
{
    Task<PaginationResponse<IEnumerable<LogHistory>>> PaginateAsync(
        PaginateLogsRequest request,
        CancellationToken cancellationToken = default
    );
}
