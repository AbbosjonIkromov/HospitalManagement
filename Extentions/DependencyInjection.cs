using HospitalManagement.DataAccess;
using HospitalManagement.DataAccess.Repository.Contracts;
using HospitalManagement.DataAccess.Repository.Implements;
using HospitalManagement.Services;
using HospitalManagement.Services.Contracts;
using HospitalManagement.Services.Implements;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddSingleton<PdpService>();

            return services;
        }
    }
}
