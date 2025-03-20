using HospitalManagement.DataAccess.Entities;
using HospitalManagement.DataAccess.Repository.Contracts;
using HospitalManagement.Dtos.Doctor;
using HospitalManagement.Services.Contracts;

namespace HospitalManagement.Services.Implements
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository repository;

        public DoctorService(IDoctorRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctors()
        { 
            return repository.GetAll()
                .Select(r => new DoctorDto()
                {
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    SpecialityId = r.SpecialityId
                });
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
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                SpecialityId = doctor.SpecialityId
            };
        }
    }
}
