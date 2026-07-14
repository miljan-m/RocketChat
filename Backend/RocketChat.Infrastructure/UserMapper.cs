using AutoMapper;
using RocketChat.Application.DTOs.UserDTOs;

namespace RocketChat.Infrastructure;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<CreateUserDTO, ApplicationUser>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                                                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                                                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                                                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                                                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                                                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));


        CreateMap<ApplicationUser, GetUserDTO>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                                                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                                                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                                                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                                                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

        CreateMap<CreateUserDTO, GetUserDTO>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                                                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                                                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                                                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                                                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
    }
}