namespace task.ems.dal.Entities.Logs;

public sealed record LogHistory : Entity
{
    public EntityType EntityType { get; set; }
    public TransactionType TransactionType { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
}
