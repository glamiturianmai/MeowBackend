using MeowBackend.API.Configuration;
using MeowBackend.API.Extensions;
using MeowBackend.Business;
//using MeowBackend.Business.Tests.Services; ;
using MeowBackend.Core.Models.Requestes;
using MeowBackend.Core.Models.Responses;
using MeowBackend.Core.Validation;
using MeowBackend.DataLayer;
using Microsoft.AspNetCore.Identity;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Logging.ClearProviders();


    Log.Logger = new LoggerConfiguration() //такой singleton на все приложение 
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger(); //
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

    builder.Services.ConfigureApiServices();
    builder.Services.ConfigureDalServices();
    builder.Services.ConfigureBllServices();
    //builder.Services.ConfigureBllTestServices();
    builder.Services.ConfigureDataBase(builder.Configuration);
    builder.Services.AddAutoMapper(typeof(MappingRequestProfile), typeof(MappingResponseProfile));

    //builder.Services.AddFluentValidationAutoValidation()
    //.AddFluentValidationClientsideAdapters()
    //.AddValidatorsFromAssemblyContaining<PersonValidation>();

    builder.Host.UseSerilog();

    var app = builder.Build();



    app.UseMiddleware<ExceptionMiddleware>();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsProduction()) //чтобы бэк без свагера не сломался 
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseSerilogRequestLogging();

    app.UseAuthentication(); //а было наоборот проверяем что есть токен  
    app.UseAuthorization();

    app.MapControllers();


    Log.Information("Running app");
    
    app.Run();
}
catch (Exception ex)
{
    
    Log.Fatal(ex.Message);
}
finally
{
    Console.WriteLine("App stopped.");
    Log.CloseAndFlush();
}