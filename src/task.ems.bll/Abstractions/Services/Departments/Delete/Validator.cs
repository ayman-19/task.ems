namespace task.ems.bll.Abstractions.Services.Departments.Delete;

public sealed class DeleteDepartmentRequestValidator : AbstractValidator<DeleteDepartmentRequest>
{
    public DeleteDepartmentRequestValidator(IDepartmentRepository departmentRepository)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleLevelCascadeMode = CascadeMode.Stop;
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Invalid department ID.")
            .MustAsync(async (id, ct) => await departmentRepository.AnyAsync(d => d.Id == id, ct))
            .WithMessage("department not exist.");
    }
}
