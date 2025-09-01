using AutoMapper;

using Lachi.Areas.Admin.Models;
using Lachi.Areas.Admin.Models.Country;
using Lachi.Areas.Admin.Models.User;
using Lachi.Data.Entities.GameStuff;
using Lachi.Data.Entities.UserStuff;

namespace Lachi.Areas.Admin.Mappings
{
    public class CountryMappingProfile:Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Country, CountryDto>();

            CreateMap<Country, CreateByDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => src.CreatedBy.FirstName + " " + src.CreatedBy.LastName));

            CreateMap<Country, UpdateByDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => src.UpdatedBy != null ? src.UpdatedBy.FirstName + " " + src.UpdatedBy.LastName : string.Empty));
        }
    }
}
