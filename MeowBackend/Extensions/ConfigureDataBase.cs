using MeowBackend.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace MeowBackend.API.Extensions;

public static class DataBaseExtensions
{
    public static void ConfigureDataBase(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddDbContext<MeowDBContext>
            (options => options
            .UseNpgsql(configurationManager.GetConnectionString("MypConnection"))
            .UseSnakeCaseNamingConvention()
            );

    }
}
