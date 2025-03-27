using HospitalManagement.DataAccess.Repository.Contracts;
using HospitalManagement.Dtos.Appointment;
using HospitalManagement.Services.Contracts;

namespace HospitalManagement.Services.Implements
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }
        public Task<AppointmentDto> CreateAsync(CreateAppointmentDto createAppointmentDto)
        {
            return null;
        }
    }
}
