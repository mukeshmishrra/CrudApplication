using CrudAppliction.Data;
using CrudAppliction.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();   // Swagger configuration

// 1. Fetch connection string safely from appsettings.json
var getDbConnection = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Register AppDbContext with SQL Server Configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(getDbConnection));

// 3. Register your custom Application Services (Dependency Injection)
builder.Services.AddScoped<IProductService, ProductService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();    // Swagger configuration
    app.UseSwaggerUI();  // Swagger configuration

    // Swagger configuration 
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "CrudApplication v1");
        s.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
