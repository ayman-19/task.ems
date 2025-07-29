namespace task.ems.api.Controllers;

[Route("api/v1/logs")]
[ApiController]
public class LogsController(ILogHistoryService logHistoryService) : ControllerBase
{
    /// <summary>
    ///  Paginate logs
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet()]
    public async Task<ActionResult<PaginationResponse<IEnumerable<LogHistory>>>> GeteAsync(
        [FromQuery] PaginateLogsRequest request,
        CancellationToken cancellationToken = default
    ) => Ok(await logHistoryService.PaginateAsync(request, cancellationToken));
}
