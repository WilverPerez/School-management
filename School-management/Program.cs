using Core.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Inject services
void AddServices()
{
    builder.Services.AddScoped<IStudentRepository, StudentRepository>();
}

// Inject context
void AddDbContexts()
{
    string sqlSeverConnectionString = builder.Configuration.GetConnectionString("ConnectionString");
    builder.Services.AddDbContext<SqlContext>(options =>
    {
        options.UseSqlServer(sqlSeverConnectionString).LogTo((msg) => Debug.WriteLine(msg));
    });
}

AddServices();
AddDbContexts();

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
