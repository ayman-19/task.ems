namespace task.ems.dal.Context;

public sealed class EMSDbContext : DbContext
{
    public EMSDbContext(DbContextOptions<EMSDbContext> options)
        : base(options)
    {
        NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
