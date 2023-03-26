using AutoMapper;
using CommandsService.DTOs;
using CommandsService.Models;

namespace CommandsService.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // soutce --> Tatget 
            CreateMap<PlatFroms,PlatformReadDto>();    
            CreateMap<CommandCreateDto,Command>();
            CreateMap<Command,CommandReadDto>();
        }
        
        

    }
}