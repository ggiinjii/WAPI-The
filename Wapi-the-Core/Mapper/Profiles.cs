using AutoMapper;
using Wapi_the_Infra.Models;
using Wapi_the_Core.DTO;

namespace Wapi_the_Core.Mapper
{
    public class Profiles : Profile
    {

        public Profiles()
        {
            CreateMap<Hero, HeroDto>()
                     .ForMember(dest => dest.Alter, act => act.MapFrom(src => src.HeroAlter))
                     .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                     .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name)).ReverseMap();

        }
    }
}
