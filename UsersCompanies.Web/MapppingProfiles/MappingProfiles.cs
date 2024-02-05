using AutoMapper;
using UsersCompanies.Domain.Entities;
using UsersCompanies.Web.Models;
using UsersCompanies.Domain.DTO;

namespace UsersCompanies.Web.MapppingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CompanyDTO, CompanyViewModel>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ReverseMap();

            CreateMap<UserDTO, UserViewModel>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<JobDTO, JobViewModel>().ReverseMap();
            CreateMap<Job, JobDTO>().ReverseMap();
        }
    }
}
