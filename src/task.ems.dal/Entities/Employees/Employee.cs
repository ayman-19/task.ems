namespace task.ems.dal.Entities.Employees;

public sealed record Employee : Entity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime HireDate { get; set; }
    public EmployeeStatus Status { get; set; }
    public long DepartmentId { get; set; }

    public Department Department { get; set; }

    public void Update(
        string name,
        string email,
        DateTime hireDate,
        EmployeeStatus status,
        long departmentId
    )
    {
        Name = name;
        Email = email;
        HireDate = hireDate;
        Status = status;
        DepartmentId = departmentId;
    }
}
