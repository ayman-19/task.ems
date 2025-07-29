using task.ems.dal.Enums;

namespace task.ems.dal.Entities.Departments;

public interface IDepartmentRepository : IRepository<Department>
{
    Task<Department> GetByIdAsync(long Id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Department>> PaginateAsync(
        int index,
        int size,
        string name,
        SortDirection sortDirection,
        CancellationToken cancellationToken = default
    );
}
