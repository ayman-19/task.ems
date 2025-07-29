namespace task.ems.dal.Entities.Logs;

public interface ILogHistoryRepository : IRepository<LogHistory>
{
    Task<IReadOnlyCollection<LogHistory>> PaginateAsync(
        int index,
        int size,
        SortDirection sortDirection,
        CancellationToken cancellationToken = default
    );
}
