using AutoMapper;
using HospitalManagement.DataAccess.Entities;
using HospitalManagement.Dtos.Doctor;
using HospitalManagement.Dtos.Patient;

namespace HospitalManagement.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => $"{src.FirstName}"));

            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.DataOfBirth, opt => opt.MapFrom(src => src.DataOfBirth.ToString()))
                .ForMember(dest => dest.BlankIdentifier, opt => opt.MapFrom(src => src.PatientBlank.BlankIdentifier))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.RegisteredDate, opt => opt.MapFrom(src => src.RegisteredDate.ToString("dd-MM-yyyy")));//ToString("yy-MM-dd")));
        }
    }
}
