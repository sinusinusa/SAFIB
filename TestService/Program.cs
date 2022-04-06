using TestService.DataAccess;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TestService.Configuration;

// Build application
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Set up the configuration
builder.Services.Configure<DatabaseConfiguration>(
	builder.Configuration.GetSection("DatabaseConfiguration"));

// Set up the Postgres connection
builder.Services.AddDbContext<UnitContext>((sc, options) =>
{
	var databaseConfigurationOptions = sc.GetService<IOptions<DatabaseConfiguration>>();
	var connectionString = databaseConfigurationOptions?.Value.ConnectionString;
	if (string.IsNullOrEmpty(connectionString))
		throw new System.Exception("DatabaseConfigurationOptions is null");
	options.UseNpgsql(connectionString);
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
