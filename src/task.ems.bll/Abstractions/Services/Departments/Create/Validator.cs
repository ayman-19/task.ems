namespace task.ems.bll.Abstractions.Services.Departments.Create;

public sealed class CreateDepartmentValidator : AbstractValidator<CreateDepartmentRequest>
{
    public CreateDepartmentValidator(IEmployeeRepository employeeRepository)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleLevelCascadeMode = CascadeMode.Stop;
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Department name is required.")
            .Length(3, 100)
            .WithMessage("Department name must be between 3 and 100 characters.");

        RuleFor(x => x.ManagerId)
            .GreaterThan(0)
            .WithMessage("Manager ID must be a positive number.")
            .MustAsync(
                async (managerId, cancellation) =>
                    managerId != null
                        ? await employeeRepository.AnyAsync(e => e.Id == managerId, cancellation)
                        : true
            )
            .WithMessage("manager not exist.");
    }
}
