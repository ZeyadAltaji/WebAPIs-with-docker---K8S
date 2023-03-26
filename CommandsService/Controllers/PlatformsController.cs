using System;
using System.Collections.Generic;
using AutoMapper;
using CommandsService.Data;
using CommandsService.DTOs;
using Microsoft.AspNetCore.Mvc;
 namespace CommandsService.Controllers
{
    [Route("api/commands/[Controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepo Repo;
        private readonly IMapper mapper;
        public PlatformsController(ICommandRepo Repo,IMapper mapper)
        {
                this.Repo=Repo;
                this.mapper=mapper;

        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
             Console.WriteLine("--> Getting Platforms from CommandsService");

            var platformItems = Repo.GetAllPlatFroms();

            return Ok(mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
               Console.WriteLine("--> Inbound POST # Command Service");

            return Ok("Inbound test of from Platforms Controler");
        }

    }
}