namespace task.ems.dal;

public static class Depndencies
{
    public static IServiceCollection RegisterDALDependencies(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<EMSDbContext>(cfg =>
        {
            cfg.UseNpgsql(configuration.GetConnectionString("EmsDbConnection"));
            cfg.EnableDetailedErrors().EnableSensitiveDataLogging();
        });
        services
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IEmployeeRepository, EmployeeRepository>()
            .AddScoped<ILogHistoryRepository, LogHistoryRepository>()
            .AddScoped<IDepartmentRepository, DepartmentRepository>();
        return services;
    }
}
