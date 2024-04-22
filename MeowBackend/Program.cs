using MeowBackend.API.Extensions;
using MeowBackend.Business.Services;
using MeowBackend.DataLayer;
using MeowBackend.Business;
using MeowBackend.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.ConfigureApiServices();
builder.Services.ConfigureDalServices();
builder.Services.ConfigureBllServices();
builder.Services.ConfigureDataBase(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
