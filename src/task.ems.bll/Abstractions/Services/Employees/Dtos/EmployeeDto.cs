namespace task.ems.bll.Abstractions.Services.Employees.Dtos;

public sealed record EmployeeDto(
    long Id,
    string Name,
    string Email,
    DateTime HireDate,
    EmployeeStatus Status,
    string DepartmentName
)
{
    public static implicit operator EmployeeDto(Employee employee)
    {
        return new(
            employee.Id,
            employee.Name,
            employee.Email,
            employee.HireDate,
            employee.Status,
            employee.Department.Name
        );
    }
}
