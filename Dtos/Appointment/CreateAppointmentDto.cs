namespace HospitalManagement.Dtos.Appointment
{
    public class CreateAppointmentDto
    {
        public DateTime AppointmentDate { get; set; } = DateTime.UtcNow;

        public int PatientId { get; set; }

        public int DoctorId { get; set; }
    }
}
