using FluentValidation;
using MeowBackend.Business.Services;
using MeowBackend.Core.Models.Requestes;
using MeowBackend.Core.Validation;
using Microsoft.Extensions.DependencyInjection;
namespace MeowBackend.Business;

public static class ConfigureServices
{
    public static void ConfigureBllServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreatePersonRequest>, PersonValidation>();
        services.AddScoped<IValidator<UpdateAuthorizationPersonRequest>, AuthorizationPersonValidation>();
        services.AddScoped<ICatsService, CatsService>();
        services.AddScoped<IPersonsService, PersonsService>();
        services.AddScoped<IDogsService, DogsService>();
    }
}
