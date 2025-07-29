namespace task.ems.bll.Abstractions.Services.Employees.Update;

public sealed record UpdateEmployeeRequest(
    long Id,
    string Name,
    string Email,
    DateTime HireDate,
    EmployeeStatus Status,
    long DepartmentId
);
