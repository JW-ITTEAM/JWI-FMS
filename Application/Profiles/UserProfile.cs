using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // source -> destination
            CreateMap<T_USER, VM_USER>()                
                .ForMember(dest => dest.F_CompanyName, opt => opt.MapFrom(src => src.F_CompanyId))
                .ForMember(dest => dest.F_EmailVerified, opt => opt.MapFrom(src => false));
        }
    }
}
