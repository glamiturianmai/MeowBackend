using MeowBackend.Business.Services;
using MeowBackend.DataLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace MeowBackend.Business;

public static class ConfigureServices
{
    public static void ConfigureBllServices(this IServiceCollection services)
    {
        services.AddScoped<ICatsService, CatsService>();
        services.AddScoped<IPersonsService, PersonsService>();
    }
}
