using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using Papabytes.Portfolio.RecipeVault.Application;
using Papabytes.Portfolio.RecipeVault.Infrastructure;
using Papabytes.Portfolio.RecipeVault.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Recipe Vault API",
        Description = "A set of endpoints to manage recipes",
    });
    
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();
await app.InitialiseDatabaseAsync();

var mapper = app.Services.GetService<IMapper>();
mapper.ConfigurationProvider.AssertConfigurationIsValid();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "/docs/{documentName}/open-api.json";
    });
    app.UseSwaggerUI(opts =>
    {
        opts.SwaggerEndpoint("/docs/v1/open-api.json", "Recipe Vault V1");
        opts.RoutePrefix = "api/docs";
    });
}

// To serve under a reverse proxy
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();

app.UseCors(opts =>
{
    opts.AllowAnyHeader();
    opts.AllowAnyMethod();
    opts.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();