namespace task.ems.bll.Abstractions.Services.Departments;

public interface IDepartmentService
{
    Task<ResponseOf<CreateDepartmentResult>> CreateAsync(
        CreateDepartmentRequest request,
        CancellationToken cancellationToken
    );
    Task<Response> DeleteAsync(
        DeleteDepartmentRequest request,
        CancellationToken cancellationToken = default
    );
    Task<ResponseOf<UpdateDepartmentResult>> UpdateAsync(
        UpdateDepartmentRequest request,
        CancellationToken cancellationToken = default
    );
    Task<ResponseOf<DepartmentDto>> GetAsync(
        GetDepartmentRequest request,
        CancellationToken cancellationToken = default
    );
    Task<PaginationResponse<IEnumerable<PaginateDepartmentDto>>> PaginateAsync(
        PaginateDepartmentsRequest request,
        CancellationToken cancellationToken = default
    );
}
