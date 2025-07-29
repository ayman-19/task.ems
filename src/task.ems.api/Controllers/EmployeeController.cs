using task.ems.bll.Abstractions.Services.Employees.Delete;
using task.ems.bll.Abstractions.Services.Employees.Get;

namespace task.ems.api.Controllers;

[Route("api/v1/employees")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    /// <summary>
    /// Add new employee
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ResponseOf<CreateEmployeeResult>>> CreateAsync(
        [FromBody] CreateEmployeeRequest request,
        CancellationToken cancellationToken = default
    ) => Ok(await employeeService.CreateAsync(request, cancellationToken));

    /// <summary>
    /// Update employee
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult<ResponseOf<UpdateEmployeeResult>>> UpdateAsync(
        [FromBody] UpdateEmployeeRequest request,
        CancellationToken cancellationToken = default
    ) => Ok(await employeeService.UpdateAsync(request, cancellationToken));

    /// <summary>
    ///  get employee by id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet()]
    public async Task<ActionResult<PaginationResponse<IEnumerable<EmployeeDto>>>> GeteAsync(
        [FromQuery] GetEmployeeRequest request,
        CancellationToken cancellationToken = default
    ) => Ok(await employeeService.GetAsync(request, cancellationToken));

    /// <summary>
    ///  delete employee
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete()]
    public async Task<ActionResult<PaginationResponse<IEnumerable<Response>>>> DeleteAsync(
        [FromQuery] DeleteEmployeeRequest request,
        CancellationToken cancellationToken = default
    ) => Ok(await employeeService.DeleteAsync(request, cancellationToken));

    /// <summary>
    ///  Paginate employees
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("paginate")]
    public async Task<ActionResult<PaginationResponse<IEnumerable<EmployeeDto>>>> GeteAsync(
        [FromQuery] PaginateEmployeesRequest request,
        CancellationToken cancellationToken = default
    ) => Ok(await employeeService.PaginateAsync(request, cancellationToken));
}
