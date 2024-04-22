using Microsoft.EntityFrameworkCore;
using OpenTicket.Api.Extensions;
using OpenTicket.Data.Context;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDataContext>(
    options => options.UseSqlite("Data Source=openticket.db;Cache=shared", b => b.MigrationsAssembly("OpenTicket.Api"))
);

builder.Services.AddControllers();
builder.Services.AddHandlers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors
(
    c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
);

app.MapControllers();

app.Run();