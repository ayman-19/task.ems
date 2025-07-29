namespace task.ems.bll.Abstractions.Services.Departments.Update;

using FluentValidation;
using task.ems.dal.Entities.Departments;

public sealed class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentRequest>
{
    public UpdateDepartmentValidator(
        IDepartmentRepository departmentRepository,
        IEmployeeRepository employeeRepository
    )
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Department ID must be greater than zero.")
            .MustAsync(async (id, ct) => await departmentRepository.AnyAsync(d => d.Id == id, ct))
            .WithMessage("department not exist.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Department name is required.")
            .Length(3, 100)
            .WithMessage("Department name must be between 3 and 100 characters.");

        //RuleFor(x => x.ManagerId)
        //    .GreaterThan(0)
        //    .WithMessage("Manager ID must be a positive number.")
        //    .MustAsync(async (id, ct) => await employeeRepository.AnyAsync(d => d.Id == id, ct))
        //    .WithMessage("Manager not exist.");
    }
}
