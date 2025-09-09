using AutoMapper;
using PlatformService.Models;
using PlatformService.Dtos;

namespace PlatformService.Profiles;

public class PlatformsProfile : Profile
{
    public PlatformsProfile()
    {
        // source -> Target
        CreateMap<Platform, PlatformReadDto>().ReverseMap();
        CreateMap<Platform, PlatformCreateDto>().ReverseMap();
        
    }
}