namespace task.ems.bll.Abstractions.Services.Departments.Dtos;

public sealed record PaginateDepartmentDto(long Id, string Name, long? ManagerId, string MangerName)
{
    public static explicit operator PaginateDepartmentDto(Department department) =>
        new(
            department.Id,
            department.Name,
            department.ManagerId,
            department.Manager?.Name ?? string.Empty
        );
}
