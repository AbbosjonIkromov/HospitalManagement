using AutoMapper;
using AutoMapper.QueryableExtensions;
using HospitalManagement.DataAccess.Entities;
using HospitalManagement.DataAccess.Repository.Contracts;
using HospitalManagement.Dtos.Patient;
using HospitalManagement.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Services.Implements
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository repository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository repository,
                IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }
        public async  Task<IList<PatientDto>> GetHighSeverityPatients()
        {
            var highSeverityPatients = await repository.GetHighSeverityPatients(5);

            return highSeverityPatients
                .Select(r => new PatientDto
                {
                    PatientId = r.PatientId,
                    DataOfBirth = r.DataOfBirth.ToString(),
                    IsActive = r.IsActive,
                    PatientBlankId = r.PatientBlankId
                }).ToList();

    
        }

        public async Task<IList<PatientDto>> GetAll()
        {
            var patients = repository.GetAll()
                .AsNoTracking()
                .ProjectTo<PatientDto>(_mapper.ConfigurationProvider)
                .ToList();

            return patients;
        }
    }
}
