using task.ems.dal.Enums;

namespace task.ems.dal.Entities.Employees;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee> GetByIdAsync(long Id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Employee>> PaginateAsync(
        int index,
        int size,
        string name,
        string department,
        EmployeeStatus? status,
        DateTime? fromDate,
        DateTime? toDate,
        SortDirection sortDirection,
        CancellationToken cancellationToken = default
    );
}
