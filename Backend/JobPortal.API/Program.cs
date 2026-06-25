using JobPortal.Application.Interfaces;
using JobPortal.Infrastructure.Data;
using JobPortal.Infrastructure.Repositories;
using JobPortal.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddOpenApi();                                      //API documentation enable pannu.

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));           //appsettings la irukkura values-a MongoDbSettings class-ku map pannudhu.

builder.Services.AddSingleton<MongoDbContext>();                    //Application full-a oru MongoDbContext object mattum create pannu.

builder.Services.AddScoped<IJobRepository, JobRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();