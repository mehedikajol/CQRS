using CQRS.Application.Handlers.CommandHandlers;
using CQRS.Core.Repositories.Command;
using CQRS.Core.Repositories.Command.Base;
using CQRS.Core.Repositories.Query;
using CQRS.Core.Repositories.Query.Base;
using CQRS.Infrastructure.Data;
using CQRS.Infrastructure.Repositories.Command;
using CQRS.Infrastructure.Repositories.Command.Base;
using CQRS.Infrastructure.Repositories.Query;
using CQRS.Infrastructure.Repositories.Query.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// dependencies
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var assembly1 = Assembly.GetExecutingAssembly();
var assembly2 = typeof(GetConfigurationValuesQueryHandler).Assembly;
services.AddMediatR(assembly1, assembly2);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
builder.Services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();


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
