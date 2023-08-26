using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder => builder
        .WithOrigins("https://8081-dffafdafebcfacbdcbaeadfdfbaabfff.premiumproject.examly.io") // Replace with your allowed origins
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("Content-Disposition"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
