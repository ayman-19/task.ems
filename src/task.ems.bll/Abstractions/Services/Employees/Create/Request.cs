namespace task.ems.bll.Abstractions.Services.Employees.Create;

public sealed record CreateEmployeeRequest(
    string Name,
    string Email,
    DateTime HireDate,
    EmployeeStatus Status,
    long DepartmentId
)
{
    public static implicit operator Employee(CreateEmployeeRequest request)
    {
        return new Employee
        {
            Name = request.Name,
            Email = request.Email,
            HireDate = request.HireDate,
            Status = request.Status,
            DepartmentId = request.DepartmentId,
        };
    }
}
