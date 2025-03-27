using AutoMapper;
using HospitalManagement.DataAccess.Entities;
using HospitalManagement.DataAccess.Repository.Contracts;
using HospitalManagement.Dtos.Doctor;
using HospitalManagement.Dtos.Speciality;
using HospitalManagement.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Services.Implements
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository repository;
        private readonly IPatientRepository patientRepository;
        private readonly INotificationService notification;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository repository,
            IPatientRepository patientRepository,
            INotificationService notification,
            IMapper mapper)
        {
            this.repository = repository;
            this.patientRepository = patientRepository;
            this.notification = notification;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctors()
        { 
            return repository.GetAll()
                .Select(r => new DoctorDto()
                {
                    Id = r.DoctorId,
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    SpecialityId = r.SpecialityId
                });
        }

        public async Task<DoctorDto> GetDoctor(int id)
        {
            var doctor = await repository.GetByIdAsync(id);

            return _mapper.Map<DoctorDto>(doctor);
        }
        public async Task<DoctorDto> CreateDoctor(CreateDoctorDto createDoctorDto)
        {
            var doctor = new Doctor()
            {
                FirstName = createDoctorDto.FirstName,
                LastName = createDoctorDto.LastName,
                SpecialityId = createDoctorDto.SpecialityId
            };

            await repository.AddAsync(doctor);
            await repository.SaveChangesAsync();

            return new DoctorDto
            {
                Id = doctor.DoctorId,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                SpecialityId = doctor.SpecialityId
            };
        }

        public async Task<DoctorDto> GetDoctorById(long id)
        {
            var doctor = repository.GetById(id);

            if (doctor is null)
            {
                throw new KeyNotFoundException("Doctor Not Found!");
            }

            return new DoctorDto
            {
                Id = doctor.DoctorId,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                SpecialityId = doctor.SpecialityId
            };
        }

        public async Task SendPatentStatus()
        {
            var highSeverityPatients = await patientRepository.GetHighSeverityPatients(5);

            var doctors = repository.GetAll()
                .AsNoTracking()
                .Where(r => r.SpecialityId == (int)SpecialityType.Operatives)
                .Select(r => r.DoctorId)
                .ToList();

            foreach (var doctor in doctors)
            {
                await notification.Nofify(doctor, highSeverityPatients.Select(r => r.PatientId).ToArray());
            }

        }
    }
}
