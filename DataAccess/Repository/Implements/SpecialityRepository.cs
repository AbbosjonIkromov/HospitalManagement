using HospitalManagement.DataAccess.Entities;
using HospitalManagement.DataAccess.Repository.Contracts;
using HospitalManagement.DataAccess.Repository.Impements;

namespace HospitalManagement.DataAccess.Repository.Implements
{
    public class SpecialityRepository : Repository<Speciality>, ISpecialityRepository
    {

        public SpecialityRepository(HospitalContext context) : base(context)
        {

        }
    }
}
