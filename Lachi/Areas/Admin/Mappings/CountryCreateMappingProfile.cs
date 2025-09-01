using AutoMapper;

using Lachi.Areas.Admin.Models.Country;
using Lachi.Data.Entities.GameStuff;

namespace Lachi.Areas.Admin.Mappings
{
    public class CountryCreateMappingProfile: Profile
    {
        public CountryCreateMappingProfile()
        {
            CreateMap<CountryCreateDto, Country>();
        }
    }
}
