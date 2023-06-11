using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel;
using Myproject.Context;
using Myproject.Repositories;
using Myproject.Models;
using Myproject.Services;
using Serilog.Sinks.SystemConsole;
using Serilog.Sinks.File;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BankContext>(opt =>
                          opt.UseSqlServer(builder.Configuration.GetConnectionString("NewDatabase"))
                             .EnableSensitiveDataLogging()
                             .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddScoped<IRepositoryInterface<Banks,int>,BanksRepository>();
builder.Services.AddScoped<IRepositoryInterface<Director,int>,DirectorRepository>();
builder.Services.AddScoped<IRepositoryInterface<ContactPerson,int>, ContactPersonRepository>();

var _logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext()
    .MinimumLevel.Error()
    .WriteTo.File(@"/Users/giorgishushanashvili/Projects/Myproject/Myproject/logfile.txt",
    rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(_logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.MapControllers();

app.Run();

