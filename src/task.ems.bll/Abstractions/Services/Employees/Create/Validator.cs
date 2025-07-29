namespace task.ems.bll.Abstractions.Services.Employees.Create;

public sealed class CreateEmployeeValidator : AbstractValidator<CreateEmployeeRequest>
{
    public CreateEmployeeValidator(
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository
    )
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleLevelCascadeMode = CascadeMode.Stop;
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .Length(3, 100)
            .WithMessage("Name must be between 3 and 100 characters.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.")
            .MustAsync(
                async (email, cancellation) =>
                    !await employeeRepository.AnyAsync(e => e.Email == email, cancellation)
            )
            .WithMessage("email is exist.");

        RuleFor(x => x.HireDate)
            .NotEmpty()
            .WithMessage("Hire date is required.")
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Hire date cannot be in the future.");

        RuleFor(x => x.Status).IsInEnum().WithMessage("Invalid employee status.");

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0)
            .WithMessage("Department ID must be greater than 0.")
            .MustAsync(
                async (id, cancellation) =>
                    await departmentRepository.AnyAsync(e => e.Id == id, cancellation)
            )
            .WithMessage("department not exist.");
    }
}
