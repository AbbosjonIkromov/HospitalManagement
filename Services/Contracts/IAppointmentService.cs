using HospitalManagement.Dtos.Appointment;

namespace HospitalManagement.Services.Contracts
{
    public interface IAppointmentService
    {
        Task<AppointmentDto> CreateAsync(CreateAppointmentDto createAppointmentDto);

    }
}
