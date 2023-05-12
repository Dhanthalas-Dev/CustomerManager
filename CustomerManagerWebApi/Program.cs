using CustomerManagerApplication;
using CustomerManagerApplication.IO;
using CustomerManagerRepositories;
using CustomerManagerRepositories.Repositories;
using CustomerManagerWebApi.Extensions;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlite<ApplicationDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(IAmApplication))));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

app.ConfigureExceptionHandling();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
