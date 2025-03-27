using FluentValidation;
using HospitalManagement.DataAccess.Entities;
using HospitalManagement.DataAccess.Repository.Contracts;
using HospitalManagement.DataAccess.Repository.Impements;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace HospitalManagement.DataAccess.Repository.Implements
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly HospitalContext context;
        private readonly IMemoryCache cache;

        public PatientRepository(HospitalContext context, IMemoryCache cache) : base(context)
        {
            this.context = context;
            this.cache = cache;
        }
        public async Task<IEnumerable<Patient>> GetHighSeverityPatients(int severity)
        {
            return await context.Patients
                .Include(r => r.PatientBlank)
                .Where(r => r.PatientBlank.Severity > severity)
                .ToListAsync();
        }
    }
}
