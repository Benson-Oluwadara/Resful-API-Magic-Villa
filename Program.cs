using MagicVilla_Api;
using MagicVilla_Api.Data;
using MagicVilla_Api.Logging;
using MagicVilla_Api.Repository;
using MagicVilla_Api.Repository.IRepository;
using MagicVilla_Api.Repository.Repository;
//using MagicVilla_Api.Respository.IRepositoryNew;
using Microsoft.EntityFrameworkCore;

/*using Serilog;*/ //import this after installing serilog file and serilog asp net

var builder = WebApplication.CreateBuilder(args);

//using debugging level or information level
//.debug or .information()

//Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.File("log/villalogs.txt", rollingInterval:RollingInterval.Day).CreateLogger();//COnfiguring Serilog to write to a file log everyday
//builder.Host.UseSerilog();//Configure the host machine not to use the inbuilt logs but to use serilog

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});//Adding SQL server to the container from Configuration file called appsettings.json 
builder.Services.AddScoped<IVillaRepository, VillaRepository>();//Adding independency Injection
builder.Services.AddScoped<IVillaNumberRepository, VillaNumberRepository>();
builder.Services.AddControllers().AddNewtonsoftJson();//Added for Patch in Action

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILogging, LoggingV2>();//Regisster the Custom logger 
builder.Services.AddAutoMapper(typeof(MappingConfig));//Register Automapping


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
