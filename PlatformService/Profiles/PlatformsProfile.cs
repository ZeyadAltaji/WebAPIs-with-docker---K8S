using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Model;

namespace PlatformService.Profiles
{
    public class PlatformsProfile:Profile
    {       
        public PlatformsProfile(){
            CreateMap<Platform,PlatformReadDto>();
            CreateMap<PlatformCreateDto,Platform>();
        }
    }
}