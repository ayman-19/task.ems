namespace task.ems.bll.Abstractions.Services.Employees.Update;

public sealed record UpdateEmployeeResult(
    long Id,
    string Name,
    string Email,
    DateTime HireDate,
    EmployeeStatus Status,
    long DepartmentId
)
{
    public static implicit operator UpdateEmployeeResult(Employee employee)
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
