using AutoMapper;
using Lachi.Areas.Admin.Models.User;
using Lachi.Data.Entities.UserStuff;

namespace Lachi.Areas.Admin.Mappings
{
    public class UserEditMappingProfile : Profile
    {
        public UserEditMappingProfile()
        {
            CreateMap<User, UserEditDto>().ReverseMap();
        }
    }
}