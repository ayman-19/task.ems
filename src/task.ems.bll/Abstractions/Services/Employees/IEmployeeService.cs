namespace task.ems.bll.Abstractions.Services.Employees;

public interface IEmployeeService
{
    Task<ResponseOf<CreateEmployeeResult>> CreateAsync(
        CreateEmployeeRequest request,
        CancellationToken cancellationToken
    );
    Task<Response> DeleteAsync(
        DeleteEmployeeRequest request,
        CancellationToken cancellationToken = default
    );
    Task<ResponseOf<UpdateEmployeeResult>> UpdateAsync(
        UpdateEmployeeRequest request,
        CancellationToken cancellationToken = default
    );
    Task<ResponseOf<EmployeeDto>> GetAsync(
        GetEmployeeRequest request,
        CancellationToken cancellationToken = default
    );
    Task<PaginationResponse<IEnumerable<EmployeeDto>>> PaginateAsync(
        PaginateEmployeesRequest request,
        CancellationToken cancellationToken = default
    );
}
