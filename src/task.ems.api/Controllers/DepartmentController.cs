namespace task.ems.api.Controllers;

[Route("api/v1/departments")]
[ApiController]
public class DepartmentController(IDepartmentService departmentService) : ControllerBase
{
    /// <summary>
    /// Add new department
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ResponseOf<CreateDepartmentResult>>> CreateAsync(
        [FromBody] CreateDepartmentRequest request,
        CancellationToken cancellationToken = default
    ) => Ok(await departmentService.CreateAsync(request, cancellationToken));

    /// <summary>
    /// Update department
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult<ResponseOf<UpdateDepartmentResult>>> UpdateAsync(
        [FromBody] UpdateDepartmentRequest request,
        CancellationToken cancellationToken = default
    ) => Ok(await departmentService.UpdateAsync(request, cancellationToken));

    /// <summary>
    ///  get department by id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet()]
    public async Task<ActionResult<PaginationResponse<IEnumerable<DepartmentDto>>>> GeteAsync(
        [FromQuery] GetDepartmentRequest request,
        CancellationToken cancellationToken = default
    ) => Ok(await departmentService.GetAsync(request, cancellationToken));

    /// <summary>
    ///  delete department
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete()]
    public async Task<ActionResult<PaginationResponse<IEnumerable<Response>>>> DeleteAsync(
        [FromQuery] DeleteDepartmentRequest request,
        CancellationToken cancellationToken = default
    ) => Ok(await departmentService.DeleteAsync(request, cancellationToken));

    /// <summary>
    ///  Paginate departments
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("paginate")]
    public async Task<
        ActionResult<PaginationResponse<IEnumerable<PaginateDepartmentDto>>>
    > GeteAsync(
        [FromQuery] PaginateDepartmentsRequest request,
        CancellationToken cancellationToken = default
    ) => Ok(await departmentService.PaginateAsync(request, cancellationToken));
}
