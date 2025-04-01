using System.Reflection;
using HospitalManagement.DataAccess;
using HospitalManagement.DataAccess.Repository.Contracts;
using HospitalManagement.DataAccess.Repository.Implements;
using HospitalManagement.Services;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Implements;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace HospitalManagement.Extentions
{
    public static class DependencyInjection
    {
        //public static IServiceCollection AddDependencies(this IServiceCollection services)
        //{
        //    //Repository
        //    //services.AddScoped<IDoctorRepository, DoctorRepository>();
        //    //services.AddScoped<IPatientRepository, PatientRepository>();

        //    //Services
        //    services.AddScoped<IDoctorService, DoctorService>();
        //    services.AddScoped<IPatientService, PatientService>();
        //    services.AddScoped<INotificationService, NotificationService>();


        //    // AutoInjectRepository
        //    //var assembly = Assembly.GetExecutingAssembly();

        //    //var types = assembly.GetTypes()
        //    //    .Where(r => r.IsClass && r.Name.EndsWith("Repository"))
        //    //    .ToList();

        //    //foreach (var type in types)
        //    //{
        //    //    var interfaceType = type.GetInterfaces().FirstOrDefault(r => r.Name.EndsWith("Repository"));

        //    //    services.AddScoped(interfaceType, type);
        //    //}

        //    // AutoInjectRepository
        //    //services.Scan(r => r.FromEntryAssembly()
        //    //    .AddClasses(r => r.Where(r => r.Name.EndsWith("Repository")))
        //    //    .AsMatchingInterface()
        //    //    .WithLifetime(ServiceLifetime.Scoped));


        //    // AutoMapper
        //   // services.AddAutoMapper(Assembly.GetExecutingAssembly());


        //    return services;
        //}

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<HospitalContext>(options =>
            {
                options
                    .UseNpgsql(connection)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .UseSnakeCaseNamingConvention();
            });

            return services;
        }

        public static IServiceCollection AddMonitoring(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSerilog((serviceProvider, loggerConfiguration) =>
            {
                loggerConfiguration
                    .ReadFrom
                    .Configuration(configuration);
            });

            return services;
        }

        // Static class, static method
        // Automatik tarzda Repositorylarni va Servicelarni DI ga biriktirish uchun iwlatiladi
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service") ||
                                                             type.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
                

            return services;
        }
    }
}
