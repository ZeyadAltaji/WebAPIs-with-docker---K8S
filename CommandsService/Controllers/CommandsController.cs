using System;
using System.Collections.Generic;
using AutoMapper;
using CommandsService.Data;
using CommandsService.DTOs;
using CommandsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/commands/platforms/{platformId}/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
            private readonly ICommandRepo Repo;
            private readonly IMapper mapper;
        public CommandsController(ICommandRepo Repo,IMapper mapper)
        {
            this.Repo=Repo;
            this.mapper=mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>>GetCommandsForPlatform(int platformId)
        {
            Console.WriteLine($"--> Hit GetCommandsForPlatform: {platformId}");
            if (!Repo.platfromsExitAlready(platformId))
            {
                return NotFound();
            }

            var commands = Repo.GetCommandForPlatFroms(platformId);

            return Ok(mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }
        [HttpGet("{commandId}", Name = "GetCommandForPlatform")]
        public ActionResult<CommandReadDto> GetCommandForPlatform(int platformId, int commandId)
        {
            Console.WriteLine($"--> Hit GetCommandsForPlatform: {platformId} / {commandId}");
            if (!Repo.platfromsExitAlready(platformId))
            {
                return NotFound();
            }
                var commands = Repo.GetCommand(platformId,commandId);
                if(commands==null)
                    return NotFound();

                return Ok(mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId, CommandCreateDto commandDto)
        {
            Console.WriteLine($"--> Hit GetCommandsForPlatform: {platformId}");
            if (!Repo.platfromsExitAlready(platformId))
            {
                return NotFound();
            }
            var command =mapper.Map<Command>(commandDto);
            Repo.CreateNewCommand(platformId,command);
            Repo.SaveChanges();
            var commandReadDto =mapper.Map<CommandReadDto>(command);
            return CreatedAtAction(nameof(GetCommandForPlatform),new {platformId = platformId,commandId = commandReadDto.Id},commandReadDto
            );
        }

    }
}