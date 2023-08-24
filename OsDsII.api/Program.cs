using Microsoft.EntityFrameworkCore;

using OsDsII.api.Data;
using OsDsII.api.Repositories.Interfaces;
using OsDsII.api.Repositories;
using OsDsII.api.Services.Interfaces;
using OsDsII.api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultMySQLConnection");
    var serverVersion = new MySqlServerVersion(new Version(8,0,33));
    options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddScoped<ICustomersRepository, CustumersRepository>();
builder.Services.AddScoped<ICustomersService, CustumersService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
