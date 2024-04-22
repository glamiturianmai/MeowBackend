using MeowBackend.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace MeowBackend.DataLayer;

public static class ConfigureServices
{
    public static void ConfigureDalServices(this IServiceCollection services)
    {
        services.AddScoped<ICatsRepository, CatsRepository>();
        services.AddScoped<IPersonsRepository, PersonsRepository>();

    }
}
