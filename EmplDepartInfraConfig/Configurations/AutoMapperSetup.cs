
using Microsoft.Extensions.DependencyInjection;
using EmplDepartApplication.Mappings;

namespace EmplDepartInfraConfig.Configurations;

public static class AutoMapperSetup
{
    public static IServiceCollection AddAutoMapperSetup(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        return services;
    }
}
