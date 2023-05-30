using AutoMapper;
using SecurityAPI.BLL.Contracts.Responses.Identity;

namespace SecurityAPI.BLL.Mappers
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<AuthenticationResult, AuthSuccessResponse>();
        }
    }
}