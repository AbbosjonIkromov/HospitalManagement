﻿using HospitalManagement.DataAccess.Entities;
using HospitalManagement.DataAccess.Repository.Contracts;
using HospitalManagement.DataAccess.Repository.Impements;

namespace HospitalManagement.DataAccess.Repository.Implements
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {

        public AppointmentRepository(HospitalContext context) : base(context)
        {
            
        }
    }
}
