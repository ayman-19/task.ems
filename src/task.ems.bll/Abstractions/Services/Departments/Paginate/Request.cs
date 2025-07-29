namespace task.ems.bll.Abstractions.Services.Departments.Paginate;

public sealed record PaginateDepartmentsRequest(string search = "") : PaginateRequest();
