using System.Diagnostics.Eventing.Reader;

namespace HospitalManagement.DataAccess.Entities
{
    public class PatientBlank
    {
        public int PatientBlankId { get; set; }

        public string BlankIdentifier { get; set; }

        public bool IsActive { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }    
        public DateTime CreatedAt { get; set; }


    }
}
