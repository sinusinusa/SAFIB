using A.Service;
using A.UnitTree;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

UnitTreeSync UTree = new ListFileUnitCreate().Create();

// Add services to the container.
builder.Services.AddHttpClient();

builder.Services.AddControllers();

//builder.Services.AddSingleton<UnitTreeSync>();

builder.Services.AddHostedService<TimedHostedService>();

builder.Services.AddControllers().AddJsonOptions(x =>
				x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
