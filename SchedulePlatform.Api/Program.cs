using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using SchedulePlatform.Data;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Data.Repositories;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service;
using SchedulePlatform.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchedulePlatform.Api", Version = "v1" });
});

ConfigurationManager configuration = builder.Configuration;

var connectionString = configuration.GetConnectionString("connect");

builder.Services.AddDbContext<SchedulePlatformContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IServiceProvidedRepository, ServiceProvidedRepository>();
builder.Services.AddScoped<IServiceProvidedService, ServiceProvidedService>();

builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IMenuService, MenuService>();

builder.Services.AddScoped<INutritionistRepository, NutritionistRepository>();
builder.Services.AddScoped<INutritionistServiceS, NutritionistServiceS>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddAutoMapper(typeof(Appointment));

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

app.UseCors(corsPolicyBuilder =>
{
    corsPolicyBuilder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
});

app.Run();

