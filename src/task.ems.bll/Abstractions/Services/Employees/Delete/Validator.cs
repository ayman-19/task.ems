namespace task.ems.bll.Abstractions.Services.Employees.Delete;

public sealed class DeleteEmployeeValidator : AbstractValidator<DeleteEmployeeRequest>
{
    public DeleteEmployeeValidator(IEmployeeRepository employeeRepository)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("employee ID must be greater than 0.")
            .MustAsync(
                async (id, cancellation) =>
                    await employeeRepository.AnyAsync(e => e.Id == id, cancellation)
            )
            .WithMessage("employee not exist.");
    }
}
