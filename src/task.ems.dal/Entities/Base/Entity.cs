namespace task.ems.dal.Entities.Base;

public abstract record Entity
{
    protected Entity() { }

    public long Id { get; set; }
}
