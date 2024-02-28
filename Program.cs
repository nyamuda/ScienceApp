using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScienceApp.Data;
using ScienceApp.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ScienceAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ScienceAppContext") ?? throw new InvalidOperationException("Connection string 'ScienceAppContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CurriculumService>();
builder.Services.AddScoped<SubjectService>();

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
