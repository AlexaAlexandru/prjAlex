using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using SchedulePlatform.Data;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Data.Repositories;
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
builder.Services.AddScoped<ICustomerService,CustomerService>();

builder.Services.AddScoped<IServiceProvidedRepository,ServiceProvidedRepository>();
builder.Services.AddScoped<IServiceProvidedService,ServiceProvidedService>();

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

