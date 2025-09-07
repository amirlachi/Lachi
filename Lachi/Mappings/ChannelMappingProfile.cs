using AutoMapper;
using Lachi.Data.Entities.UserStuff;
using Lachi.Data.Entities.VideoStuff;
using Lachi.Models.Channel;
using Lachi.Models.Video;

namespace Lachi.Mappings
{
    public class ChannelMappingProfile : Profile
    {
        public ChannelMappingProfile()
        {
            CreateMap<UserChannel, UserChannelDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Videos, opt => opt.MapFrom(src => src.Videos))
                .ForMember(dest => dest.Playlists, opt => opt.MapFrom(src => src.Playlists));

            CreateMap<Video, VideoDto>()
                .ForMember(dest => dest.UserChannelId, opt => opt.MapFrom(src => src.UserChannelId));

            CreateMap<Playlist, PlaylistDto>()
                .ForMember(dest => dest.VideoCount, opt => opt.MapFrom(src => src.Videos.Count))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name));
        }
    }
}
