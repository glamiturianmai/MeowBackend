using MeowBackend.API.Controllers;
using MeowBackend.Business.Services;
using MeowBackend.Core.Dtos;
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

    [HttpPost]
    public ActionResult<Guid> CreateDog([FromBody] DogDto dto)
    {
        _logger.Information($"добавляем собаку: {dto.Name}");
        return Ok(_dogsService.CreateDog(dto));
    }

}
