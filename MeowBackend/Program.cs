using MeowBackend.API.Extensions;
using MeowBackend.Business;
using MeowBackend.DataLayer;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

    builder.Services.ConfigureApiServices();
    builder.Services.ConfigureDalServices();
    builder.Services.ConfigureBllServices();
    builder.Services.ConfigureDataBase(builder.Configuration);

    builder.Host.UseSerilog();

    var app = builder.Build();



    //app.UseMiddleware<ExceptionMiddleware>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

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