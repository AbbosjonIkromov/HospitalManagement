
using HospitalManagement.DataAccess;
using HospitalManagement.DataAccess.Entities;
using HospitalManagement.Dtos;
using HospitalManagement.Dtos.Doctor;
using HospitalManagement.Extentions;
using HospitalManagement.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Serilog;
using Serilog.Context;

namespace HospitalManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var configuration = builder.Configuration;

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.Services
                .AddDependencies()
                // .AddDbContext<HospitalManagementDbContext>(options => options.UseSqlServer(connectionString))
                .AddDbContext(configuration)
                .AddMonitoring(configuration);

            builder.Services.AddMemoryCache();

            builder.Services.AddHttpClient();

            builder.Services.Configure<PdpSettings>(configuration.GetSection("PdpSettings"));
            builder.Services.Configure<DoctorSettings>(configuration.GetSection("DoctorSettings"));

            //Serilog
            builder.Services.AddSerilog((serviceProvider, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(configuration);
            });

            // AppSetting OnStarted
            builder.Services.AddOptions<PdpSettings>()
                .ValidateDataAnnotations();


            //Middleware
            builder.Services.AddTransient<GlobalExceptionMiddleware>();

            var app = builder.Build();

            // Middleware
            app.UseMiddleware<GlobalLoggingMiddleware>();
            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseMiddleware<CorrelationIdMiddleware>();

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
        }
    }
}
