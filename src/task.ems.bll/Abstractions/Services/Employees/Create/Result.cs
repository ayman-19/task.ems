namespace task.ems.bll.Abstractions.Services.Employees.Create;

public sealed record CreateEmployeeResult(
    long Id,
    string Name,
    string Email,
    DateTime HireDate,
    EmployeeStatus Status,
    long DepartmentId
)
{
    public static implicit operator CreateEmployeeResult(Employee employee)
    {
        return new(
            employee.Id,
            employee.Name,
            employee.Email,
            employee.HireDate,
            employee.Status,
            employee.DepartmentId
        );
    }
}
