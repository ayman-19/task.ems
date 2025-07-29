namespace task.ems.bll.FluentValidationSettings;

public sealed class CustomResultFactory : IFluentValidationAutoValidationResultFactory
{
    public IActionResult CreateActionResult(
        ActionExecutingContext context,
        ValidationProblemDetails validationProblemDetails
    )
    {
        return new BadRequestObjectResult(
            new Response
            {
                Success = false,
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = validationProblemDetails
                    .Errors[validationProblemDetails?.Errors.First().Key]
                    .FirstOrDefault(),
            }
        );
    }
}
