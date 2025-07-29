namespace task.ems.bll.Abstractions.Services.Departments.Update;

public sealed record UpdateDepartmentResult(long Id, string Name, long? ManagerId)
{
    public static implicit operator UpdateDepartmentResult(Department department)
    {
        return new(department.Id, department.Name, department.ManagerId);
    }
}
