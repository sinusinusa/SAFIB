using A.UnitTree;

var builder = WebApplication.CreateBuilder(args);

UnitTree u = new ListFileUnitCreate().Create();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
