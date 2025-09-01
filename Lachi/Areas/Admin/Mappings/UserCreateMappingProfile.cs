using AutoMapper;

using Lachi.Areas.Admin.Models.User;
using Lachi.Data.Entities.UserStuff;

namespace Lachi.Areas.Admin.Mappings
{
    public class UserCreateMappingProfile: Profile
    {
        public UserCreateMappingProfile()
        {
            CreateMap<UserCreateDto, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(y => y.UserName));
        }
    }
}
