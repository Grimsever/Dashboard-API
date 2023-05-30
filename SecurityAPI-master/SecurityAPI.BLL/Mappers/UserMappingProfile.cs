using System.Linq;
using AutoMapper;
using SecurityAPI.BLL.Contracts.Requests;
using SecurityAPI.BLL.Contracts.Requests.Identity;
using SecurityAPI.BLL.Contracts.Responses;
using SecurityAPI.Domain.Entities;

namespace SecurityAPI.BLL.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRegisterRequest, User>();

            CreateMap<User, UserDto>().ForMember(
                dest => dest.Roles,
                opt => opt.MapFrom(
                    src => src.Roles.Select(_ => _.Name)));

            CreateMap<UpdateUserRequest, User>().ForMember(
                dest => dest.Roles,
                opt => opt.Ignore());
            
            CreateMap<CreateUserRequest, User>().ForMember(
                dest => dest.Roles,
                opt => opt.Ignore());
        }
    }
}