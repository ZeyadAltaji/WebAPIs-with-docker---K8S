using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Model;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
         
        private readonly IPlatformReop _repo;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;
        public PlatformsController(IPlatformReop reop ,IMapper mapper,ICommandDataClient commandDataClient)
        {
            _repo =reop;
            _mapper =mapper;
            _commandDataClient=commandDataClient;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms....");

            var platformItem = _repo.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
        }
        [HttpGet("{id}",Name="GetPlatFormsById")]
        public ActionResult<PlatformReadDto>GetPlatFormsById(int id)
        {
            var platformItem =_repo.GetPlatFormsById(id);
            if(platformItem !=null){
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            _repo.CreatePlatForms(platformModel);
            _repo.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

            // Send Sync Message   4:18:18
            try
            {
                await _commandDataClient.SendPlatformToCommand(platformReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }
            return CreatedAtAction(nameof(GetPlatFormsById),new {Id =platformReadDto.Id},platformReadDto);

        }
    }
}