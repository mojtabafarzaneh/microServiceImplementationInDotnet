using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using Platform = PlatformService.Models.Platform;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo _platformRepo;
    private readonly IMapper _mapper;
    public PlatformsController(IPlatformRepo platformRepo, IMapper mapper)
    {
        _platformRepo = platformRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatfroms()
    {
        Console.WriteLine("--> Getting platforms");

        var platformItems = _platformRepo.GetAllPlatforms();

        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
    }

    [HttpGet("{id}")]
    public ActionResult<PlatformReadDto> GetPlatform(int id)
    {
        var platformItem = _platformRepo.GetPlatformById(id);
        if (platformItem != null)
        {
            return Ok(_mapper.Map<PlatformReadDto>(platformItem));
        }
        return NotFound();
    }

    [HttpPost]
    public ActionResult CreatePlatform(PlatformCreateDto dto)
    {
        if (dto is null)
        {
            return NotFound();
        }
        var mapped = _mapper.Map<Platform>(dto);
        _platformRepo.CreatePlatform(mapped);

        return Ok();
    }


}