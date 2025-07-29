namespace task.ems.bll.Abstractions.Services.Departments.Dtos;

public sealed record EmployeeResult(
    long Id,
    string Name,
    string Email,
    DateTime HireDate,
    EmployeeStatus Status
)
{
    public static implicit operator EmployeeResult(Employee employee)
    {
        return new(employee.Id, employee.Name, employee.Email, employee.HireDate, employee.Status);
    }
}
