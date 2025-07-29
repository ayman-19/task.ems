namespace task.ems.bll.Abstractions.Services.Employees.Paginate;

public sealed record PaginateEmployeesRequest(
    EmployeeStatus? Status,
    DateTime? fromDate,
    DateTime? toDate,
    string name = "",
    string departMent = ""
) : PaginateRequest();
