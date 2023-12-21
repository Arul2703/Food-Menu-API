using FoodMenuApi.Constraints;
using FoodMenuApi.Data;
using FoodMenuApi.Interfaces;
using FoodMenuApi.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddDbContext<MenuAppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFoodMenuService, MenuService>();
builder.Services.AddScoped<CategoryConstraintActionFilter>();

// builder.Services.AddSingleton<IRouteConstraint, CategoryRouteConstraint>();
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("category", typeof(CategoryRouteConstraint));
    options.ConstraintMap.Add("handler", typeof(CategoryRouteHandler));
});

builder.Services.AddCors();

//configure the SeriLog
string logFileLocation = configuration["Logging:LogFileLocation"];
var _logger = new LoggerConfiguration()
.WriteTo.File(logFileLocation,rollingInterval:RollingInterval.Day)
.CreateLogger();
builder.Logging.AddSerilog(_logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// app.UseMiddleware<RouteConstraintMiddleware>();
app.UseHttpsRedirection();
app.UseCors(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
app.UseAuthorization();

app.MapControllers();

app.Run();
