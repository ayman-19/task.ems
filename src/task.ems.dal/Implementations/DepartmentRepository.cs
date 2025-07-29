namespace task.ems.dal.Implementations;

internal sealed class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(EMSDbContext context)
        : base(context) { }

    public async Task<Department> GetByIdAsync(long Id, CancellationToken cancellationToken) =>
        await _entities
            .Where(e => e.Id == Id)
            .Include(e => e.Employees)
            .Include(e => e.Manager)
            .AsNoTracking()
            .FirstAsync(cancellationToken);

    public async Task<IReadOnlyCollection<Department>> PaginateAsync(
        int index,
        int size,
        string name,
        SortDirection sortDirection,
        CancellationToken cancellationToken = default
    )
    {
        var query = _entities.AsNoTracking().AsQueryable();

        if (name.HasValue())
            query = query.Where(x => EF.Functions.Like(x.Name, $"{name}%"));

        query = query.Include(e => e.Manager);

        if (sortDirection == SortDirection.Ascending)
            query = query.OrderBy(x => x.Name);
        else
            query = query.OrderByDescending(x => x.Name);

        query = query.Paginate(index, size);

        return await query.ToListAsync(cancellationToken);
    }
}
