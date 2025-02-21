using Serilog;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EmplDepartCore.Interfaces;
using MediatR;
using EmplDepartCore.Interfaces.Repositories;
using EmplDepartInfrastructure.Repositories;
using EmplDepartInfrastructure;
namespace EmplDepartInfraConfig.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories();

            

            // Serilog Logging
            services.AddSingleton(Log.Logger);
            services.AddLogging();

            // MediatR Setup
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            return services;
        }
    }
}
