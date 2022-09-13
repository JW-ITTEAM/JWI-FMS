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
            CreateMap<T_USER, VM_USER>();
        }
    }
}
