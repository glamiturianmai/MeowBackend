using FluentValidation;
using MeowBackend.Business.Services;
using MeowBackend.Business.Tests.Services;
using MeowBackend.Core.Models.Requestes;
using MeowBackend.Core.Validation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowBackend.Business.Tests
{
    public static class ConfigureServices
    {
        public static void ConfigureBllTestServices(this IServiceCollection services)
        {
            services.AddScoped<PersonsServiceTest>();
            services.AddScoped<DogsServiceTest>();
        }
    }
}
