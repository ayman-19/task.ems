namespace task.ems.bll.Abstractions.Services.Departments.Dtos;

public sealed record DepartmentDto(
    long Id,
    string Name,
    long? ManagerId,
    string MangerName,
    List<EmployeeResult> Employees
)
{
    public static implicit operator DepartmentDto(Department department)
    {
        return new(
            department.Id,
            department.Name,
            department.ManagerId,
            department.Manager?.Name ?? string.Empty,
            department.Employees.Select(e => (EmployeeResult)e).ToList()
        );
    }
}
