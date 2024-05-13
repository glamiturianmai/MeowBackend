using MeowBackend.API.Controllers;
using MeowBackend.Business.Services;
using MeowBackend.Core.Dtos;
using MeowBackend.Core.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MeowBackend.Controllers;


[ApiController]
[Route("api/dogs")]

public class DogsController : Controller
{
    private readonly Serilog.ILogger _logger = Log.ForContext<CatsController>();
    private readonly IDogsService _dogsService;
    public DogsController(IDogsService catsService)
    {
        _dogsService = catsService;
    }

    [HttpGet()]
    public ActionResult<List<DogDto>> GetDogs()
    {
        _logger.Information($"получаем всех собак");
        return Ok(_dogsService.GetDogs());
    }

    [HttpGet("{id}")]
    public ActionResult<DogDto> GetDogById(Guid id)
    {
        if (id == Guid.Empty)
        {
            _logger.Information($"получаем собаку по id {id}");
            return NotFound($"собака с id {id} не найдена!");
        }
        return Ok(_dogsService.GetDogById(id));
    }

    [HttpPost]
    public ActionResult<Guid> AddDog([FromBody] DogDto dto)
    {
        _logger.Information($"добавляем собаку: {dto.Name}");
        return Ok(_dogsService.AddDog(dto));
    }

    [HttpPost]
    public void DeleteDog([FromBody] Guid id)
    {
        _logger.Information($"удаляем собаку: {_dogsService.GetDogById(id).Name}");
        _dogsService.DeleteDog(id);
    }

}
