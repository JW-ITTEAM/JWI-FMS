using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace FMS_API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // source -> destination
            CreateMap<T_USER, VM_USER>();
        }
    }
}
