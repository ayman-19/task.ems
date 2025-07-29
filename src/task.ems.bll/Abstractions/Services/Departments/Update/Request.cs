namespace task.ems.bll.Abstractions.Services.Departments.Update;

public sealed record UpdateDepartmentRequest(long Id, string Name, long? ManagerId);
