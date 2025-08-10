using HRMApp.Application;
using HRMApp.Application.Interfaces;
using HRMApp.Application.Services;
using HRMApp.Domain.Interfaces;
using HRMApp.Persistence;
using HRMApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddPresistenceDI(builder.Configuration);
builder.Services.AddApplicationDI();

builder.Services.AddDbContext<HanaHrmContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("con"))
    );


builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<ICommonRepository, CommonRepository>();
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseStaticFiles();
app.UseCors("AllowAngularDev");
app.UseAuthorization();
app.MapControllers();

app.Run();
