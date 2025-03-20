using HospitalManagement.DataAccess.Entities;
using HospitalManagement.DataAccess.Repository.Contracts;
using HospitalManagement.DataAccess.Repository.Impements;

namespace HospitalManagement.DataAccess.Repository.Implements
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {

        public PatientRepository(HospitalContext context) : base(context)
        {

        }
    }
}
