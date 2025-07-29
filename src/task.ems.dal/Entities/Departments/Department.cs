namespace task.ems.dal.Entities.Departments;

public sealed record Department : Entity
{
    public string Name { get; set; }
    public long? ManagerId { get; set; }
    public Employee? Manager { get; set; }

    public List<Employee> Employees { get; set; }

    public Department()
    {
        Employees = new();
    }

    public void Update(string name, long? managerId)
    {
        Name = name;
        ManagerId = managerId;
    }
}
