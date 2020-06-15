using System.Linq;
using AutoMapper;
using ProAgil.Domain;
using ProAgil.WebAPI.DTOs;

namespace ProAgil.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Event, EventDto>()
                .ForMember(destination => destination.Speakers, opt =>
                {
                    opt.MapFrom(src => src.Even tSpeakers.Select(item => item.Speaker).ToList());
                });
            CreateMap<Speaker, SpeakerDto>()
                .ForMember(destination => destination.Events, opt =>
                {
                    opt.MapFrom(src => src.EventSpeakers.Select(item => item.Event).ToList());
                });
            CreateMap<Lot, LotDto>();
            CreateMap<SocialNetwork, SocialNetworkDto>();
        }
    }
}