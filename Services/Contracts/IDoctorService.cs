using HospitalManagement.DataAccess.Repository.Contracts;
using HospitalManagement.Dtos.Doctor;

namespace HospitalManagement.Services.Contracts
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctors();
        Task<DoctorDto> CreateDoctor(CreateDoctorDto createDoctorDto);

        Task<DoctorDto> GetDoctorById(long id);

        Task SendPatentStatus();
    }
}
