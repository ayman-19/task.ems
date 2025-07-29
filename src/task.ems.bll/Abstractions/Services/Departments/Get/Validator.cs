namespace task.ems.bll.Abstractions.Services.Departments.Get;

public sealed class GetDepartmentRequestValidator : AbstractValidator<GetDepartmentRequest>
{
    public GetDepartmentRequestValidator(IDepartmentRepository departmentRepository)
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
