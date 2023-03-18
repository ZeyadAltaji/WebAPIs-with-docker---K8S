using System;
using Microsoft.AspNetCore.Mvc;
 namespace CommandsService.Controllers
{
    [Route("api/commands/[Controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {


        }
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
               Console.WriteLine("--> Inbound POST # Command Service");

            return Ok("Inbound test of from Platforms Controler");
        }

    }
}