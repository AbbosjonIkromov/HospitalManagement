using HospitalManagement.Dtos.Patient;

namespace HospitalManagement.Services.Contracts
{
    public interface IPatientService
    {
        Task<IList<PatientDto>> GetHighSeverityPatients();

        Task<IList<PatientDto>> GetAll();
    }
}
