using HospitalManagement.DataAccess.Entities;
using HospitalManagement.DataAccess.Repository.Contracts;
using HospitalManagement.DataAccess.Repository.Impements;

namespace HospitalManagement.DataAccess.Repository.Implements
{
    public class PatientBlankRepository : Repository<PatientBlank>, IPatientBlankRepository
    {

        public PatientBlankRepository(HospitalContext context) : base(context)
        {
            
        }
    }
}
