namespace task.ems.bll.Abstractions.Services.Departments.Create;

public sealed record CreateDepartmentRequest(string Name, long? ManagerId)
{
    public static implicit operator Department(CreateDepartmentRequest request)
    {
        return new Department { Name = request.Name, ManagerId = request.ManagerId };
    }
}
