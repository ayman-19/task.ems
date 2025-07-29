namespace task.ems.bll;

public static class Depndencies
{
    public static IServiceCollection RegisterBLLDependencies(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddScoped<ILogHistoryService, LogHistoryService>()
            .AddScoped<IDepartmentService, DepartmentService>()
            .AddScoped<IEmployeeService, EmployeeService>();

        services.AddValidatorsFromAssembly(typeof(Depndencies).Assembly);
        services.AddFluentValidationAutoValidation(configuration =>
        {
            configuration.DisableBuiltInModelValidation = true;

            configuration.ValidationStrategy = ValidationStrategy.All;

            configuration.EnableBodyBindingSourceAutomaticValidation = true;

            configuration.EnableFormBindingSourceAutomaticValidation = true;

            configuration.EnableQueryBindingSourceAutomaticValidation = true;

            configuration.EnablePathBindingSourceAutomaticValidation = true;

            configuration.EnableCustomBindingSourceAutomaticValidation = true;

            configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
        });
        return services;
    }
}
