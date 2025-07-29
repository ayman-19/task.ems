namespace task.ems.bll.Abstractions.Services.Departments.Create;

public sealed record CreateDepartmentResult(long Id, string Name, long? ManagerId)
{
    public static implicit operator CreateDepartmentResult(Department department)
    {
        return new(department.Id, department.Name, department.ManagerId);
    }
}
