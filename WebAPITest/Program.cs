using Microsoft.EntityFrameworkCore;
using Serilog;
using WebAPITest.DataAccess.DBContext;
using WebAPITest.Services.Repository;
using WebAPITest.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebAPITestContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("WebAPITestConnection")));

// Add services to the container.

//Serialog
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddScoped<IActualsRepository, ActualService>();

builder.Services.AddControllers();

// Enable Any Origin Request without Policy
builder.Services.AddCors(options => options.AddDefaultPolicy(
    builder => builder.AllowAnyOrigin()));

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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
