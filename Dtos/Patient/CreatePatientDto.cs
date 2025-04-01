namespace HospitalManagement.Dtos.Patient
{
    public class CreatePatientDto
    {
        public string FullName { get; set; }

        public string DataOfBirth { get; set; }

        public bool IsActive { get; set; }

        public string RegisteredDate { get; set; }
        public string BlankIdentifier { get; set; }

        public int? PatientBlankId { get; set; }
    }
}
