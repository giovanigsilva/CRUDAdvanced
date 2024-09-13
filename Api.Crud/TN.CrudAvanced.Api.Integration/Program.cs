using FluentValidation;
using MediatR;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Diagnostics;
using System.Reflection;
using TN.CrudAdvanced.Domain.Interfaces.Repositories;
using TN.CrudAdvanced.Infrastructure.Handlers;
using TN.CrudAdvanced.Infrastructure.Repositories;
using TN.CrudAvanced.Api.Integration.Extension;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TelemetryClient>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllPersonsQueryHandler).Assembly));

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<IPersonRepository, InMemoryPersonRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
