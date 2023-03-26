using System;
using AutoMapper;
using CommandsService.Data;
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
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
               Console.WriteLine("--> Inbound POST # Command Service");

            return Ok("Inbound test of from Platforms Controler");
        }

    }
}