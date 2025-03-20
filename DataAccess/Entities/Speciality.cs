namespace HospitalManagement.DataAccess.Entities
{
    public class Speciality
    {
        public Speciality()
        {
            Doctors = new List<Doctor>();
        }
        public int  SpecialityId { get; set; }
        public string  Name { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
