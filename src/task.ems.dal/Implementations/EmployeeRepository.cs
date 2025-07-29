using task.ems.dal.Enums;
using task.ems.dal.Extensions;

namespace task.ems.dal.Implementations;

internal sealed class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(EMSDbContext context)
        : base(context) { }

    public async Task<Employee> GetByIdAsync(long Id, CancellationToken cancellationToken) =>
        await _entities
            .Where(e => e.Id == Id)
            .Include(e => e.Department)
            .AsNoTracking()
            .FirstAsync(cancellationToken);

    public async Task<IReadOnlyCollection<Employee>> PaginateAsync(
        int index,
        int size,
        string name,
        string department,
        EmployeeStatus? status,
        DateTime? fromDate,
        DateTime? toDate,
        SortDirection sortDirection,
        CancellationToken cancellationToken = default
    )
    {
        var query = _entities.AsNoTracking().AsQueryable();

        if (name.HasValue())
            query = query.Where(x => EF.Functions.Like(x.Name, $"{name}%"));

        if (status != null)
            query = query.Where(x => x.Status == status);

        query = query.Include(e => e.Department);

        if (department.HasValue())
            query = query.Where(x => EF.Functions.Like(x.Department.Name, $"{department}%"));

        if (fromDate != null)
            query = query.Where(x => x.HireDate >= fromDate);

        if (toDate != null)
            query = query.Where(x => x.HireDate <= toDate);

        if (sortDirection == SortDirection.Ascending)
            query = query.OrderBy(x => x.HireDate);
        else
            query = query.OrderByDescending(x => x.HireDate);

        query = query.Paginate(index, size);

        return await query.ToListAsync(cancellationToken);
    }
}
