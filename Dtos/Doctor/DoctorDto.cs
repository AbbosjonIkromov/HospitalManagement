using HospitalManagement.DataAccess.Entities;

namespace HospitalManagement.Dtos.Doctor
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SpecialityId { get; set; }
    }
}
