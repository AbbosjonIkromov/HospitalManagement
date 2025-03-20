using HospitalManagement.DataAccess.Entities;

namespace HospitalManagement.Dtos.Appointment
{
    public class AppointmentDto
    {
        public DateTime AppointmentDate { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

    }
}
