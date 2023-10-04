using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using dotnetapp.Models;
using dotnetapp.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<FootballdbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnString"));
});
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPlayersService, PlayersService>();
builder.Services.AddScoped<IPositionsService, PositionsService>();
builder.Services
    .AddControllersWithViews()
    .AddNewtonsoftJson(
        options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json
                .ReferenceLoopHandling
                .Ignore
    );
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAnyOrigin",
        builder =>
        {
            builder
                .AllowAnyOrigin() // Allow requests from any origin
                .AllowAnyMethod()
                .AllowAnyHeader();
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
