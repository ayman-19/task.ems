namespace task.ems.dal.Context.Configurations;

internal sealed class LogHistoryConfiguration : IEntityTypeConfiguration<LogHistory>
{
    public void Configure(EntityTypeBuilder<LogHistory> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
