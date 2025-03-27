using HospitalManagement.DataAccess.Entities;

namespace HospitalManagement.DataAccess.Repository.Contracts
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetHighSeverityPatients(int severity);

    }
}
