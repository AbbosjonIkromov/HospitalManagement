using HospitalManagement.DataAccess.Entities;
using HospitalManagement.DataAccess.Repository.Contracts;
using HospitalManagement.DataAccess.Repository.Impements;
using HospitalManagement.Dtos.Doctor;

namespace HospitalManagement.DataAccess.Repository.Implements
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HospitalContext context) : base(context)
        {
            
        }
    }
}
