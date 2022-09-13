using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace FMS_API.Profiles
{
    public class ShipmentProfile : Profile
    {
        public ShipmentProfile()
        {
            // source -> destination
            CreateMap<TC_OIM, VM_OIM>()
                .ForMember(dest => dest.F_RefNo, opt => opt.MapFrom(src => src.oim.F_RefNo))
                .ForMember(dest => dest.F_MBLNo, opt => opt.MapFrom(src => src.oim.F_MBLNo))
                .ForMember(dest => dest.F_HBLNo, opt => opt.MapFrom(src => src.oih.F_HBLNo))
                .ForMember(dest => dest.F_LoadingPort, opt => opt.MapFrom(src => src.oim.F_LoadingPort))
                .ForMember(dest => dest.F_ETD, opt => opt.MapFrom(src => src.oim.F_ETD))
                .ForMember(dest => dest.F_ETA, opt => opt.MapFrom(src => src.oim.F_ETA));
            CreateMap<TC_OIM, VM_OIM_DETAIL>()
                // master
                .ForMember(dest => dest.F_RefNo, opt => opt.MapFrom(src => src.oim.F_RefNo))
                .ForMember(dest => dest.F_MBLNo, opt => opt.MapFrom(src => src.oim.F_MBLNo))
                .ForMember(dest => dest.F_M_SName, opt => opt.MapFrom(src => src.oim.F_SName))
                .ForMember(dest => dest.F_M_CName, opt => opt.MapFrom(src => src.oim.F_CName))
                .ForMember(dest => dest.F_M_NName, opt => opt.MapFrom(src => src.oim.F_NName))
                .ForMember(dest => dest.F_CarrierName, opt => opt.MapFrom(src => src.oim.F_CarrierName))
                .ForMember(dest => dest.F_M_PostDate, opt => opt.MapFrom(src => src.oim.F_PostDate))
                // house
                .ForMember(dest => dest.F_HBLNo, opt => opt.MapFrom(src => src.oih.F_HBLNo))
                .ForMember(dest => dest.F_Customer, opt => opt.MapFrom(src => src.oih.F_Customer))
                .ForMember(dest => dest.F_CustRefNo, opt => opt.MapFrom(src => src.oih.F_CustRefNo))
                .ForMember(dest => dest.F_H_SName, opt => opt.MapFrom(src => src.oih.F_SName))
                .ForMember(dest => dest.F_H_CName, opt => opt.MapFrom(src => src.oih.F_CName))
                .ForMember(dest => dest.F_H_NName, opt => opt.MapFrom(src => src.oih.F_NName))
                // shipping
                .ForMember(dest => dest.F_Vessel, opt => opt.MapFrom(src => src.oim.F_Vessel))
                .ForMember(dest => dest.F_Voyage, opt => opt.MapFrom(src => src.oim.F_Voyage))
                .ForMember(dest => dest.F_LoadingPort, opt => opt.MapFrom(src => src.oim.F_LoadingPort))
                .ForMember(dest => dest.F_ETD, opt => opt.MapFrom(src => src.oim.F_ETD))
                .ForMember(dest => dest.F_DisCharge, opt => opt.MapFrom(src => src.oim.F_DisCharge))
                .ForMember(dest => dest.F_ETA, opt => opt.MapFrom(src => src.oim.F_ETA))
                .ForMember(dest => dest.F_FinalDelivery, opt => opt.MapFrom(src => src.oim.F_FinalDelivery))
                .ForMember(dest => dest.F_FETA, opt => opt.MapFrom(src => src.oim.F_FETA))
                .ForMember(dest => dest.F_MoveType, opt => opt.MapFrom(src => src.oim.F_MoveType))
                .ForMember(dest => dest.F_CYLocation, opt => opt.MapFrom(src => src.oih.F_CYLocation))
                .ForMember(dest => dest.F_CFSLocation, opt => opt.MapFrom(src => src.oih.F_CFSLocation))
                .ForMember(dest => dest.F_PaidPlace, opt => opt.MapFrom(src => src.oim.F_PaidPlace))
                // rail
                .ForMember(dest => dest.F_ITNo, opt => opt.MapFrom(src => src.oim.F_ITNo))
                .ForMember(dest => dest.F_ITPlace, opt => opt.MapFrom(src => src.oim.F_ITPlace))
                .ForMember(dest => dest.F_ITDate, opt => opt.MapFrom(src => src.oim.F_ITDate))

                .ForMember(dest => dest.F_LCLFCL, opt => opt.MapFrom(src => src.oim.F_LCLFCL))
                .ForMember(dest => dest.F_ExpRLS, opt => opt.MapFrom(src => src.oim.F_ExpRLS))
                .ForMember(dest => dest.F_Nomi, opt => opt.MapFrom(src => src.oih.F_Nomi))
                .ForMember(dest => dest.F_AMSBLNO, opt => opt.MapFrom(src => src.oih.F_AMSBLNO))
                .ForMember(dest => dest.F_ISFNO, opt => opt.MapFrom(src => src.oih.F_ISFNO))
                ;
            CreateMap<T_CONTAINER, VM_CONTAINER>();
        }
    }
}
