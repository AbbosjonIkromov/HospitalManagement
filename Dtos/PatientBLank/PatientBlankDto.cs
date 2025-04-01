namespace HospitalManagement.Dtos.PatientBLank
{
    public class PatientBlankDto
    {
        public string BlankIdentifier { get; set; }

        public bool IsActive { get; set; }

        public int PatientId { get; set; }

        public int Severity { get; set; }
    }
}
