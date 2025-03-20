using HospitalManagement.DataAccess.Entities;

namespace HospitalManagement.Dtos.Doctor
{
    public class DoctorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SpecialityId { get; set; }
    }
}
