namespace task.ems.dal.Implementations;

internal class LogHistoryRepository : Repository<LogHistory>, ILogHistoryRepository
{
    public LogHistoryRepository(EMSDbContext context)
        : base(context) { }

    public async Task<IReadOnlyCollection<LogHistory>> PaginateAsync(
        int index,
        int size,
        SortDirection sortDirection,
        CancellationToken cancellationToken = default
    )
    {
        var query = _entities.AsNoTracking().AsQueryable();

        if (sortDirection == SortDirection.Ascending)
            query = query.OrderBy(x => x.CreateDate);
        else
            query = query.OrderByDescending(x => x.CreateDate);

        query = query.Paginate(index, size);

        return await query.ToListAsync(cancellationToken);
    }
}
