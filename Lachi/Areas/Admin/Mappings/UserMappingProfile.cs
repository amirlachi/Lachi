using AutoMapper;

using Lachi.Areas.Admin.Models;
using Lachi.Areas.Admin.Models.User;
using Lachi.Data.Entities.UserStuff;

namespace Lachi.Areas.Admin.Mappings
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));

            CreateMap<User, CreateByDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => src.CreatedBy!.FirstName + " " + src.CreatedBy.LastName));

            CreateMap<User, UpdateByDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => src.UpdatedBy != null ? src.UpdatedBy.FirstName + " " + src.UpdatedBy.LastName : string.Empty));
        }
    }
}
