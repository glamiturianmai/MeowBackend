using MeowBackend.Business.Services;
using MeowBackend.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MeowBackend.API.Controllers;

[ApiController]
[Route("api/cats")]
public class CatsController : Controller
{

    private readonly ICatsService _catsService;
    public CatsController(ICatsService catsService)
    {
        _catsService = catsService;
    }


    [HttpGet("{id}")]
    public ActionResult<CatDto> GetCatById(Guid id)
    {
        if (id == Guid.Empty)
        {
            return NotFound($"Кот с id {id} не найден!(потерлся кот)(или не было кота)");
        }
        return Ok(_catsService.GetCatById(id));
    }


    [HttpGet()]
    public ActionResult<List<CatDto>> GetCat([FromQuery] Guid? personId, [FromQuery] Guid? id)
    {
        if (personId is not null)
        {
            return Ok(_catsService.GetCatByPersonId((Guid)personId));
        }
        if (id is not null)
        {
            return Ok(_catsService.GetCatById((Guid)id));
        }
        return Ok(new List<CatDto>());
    }



}
