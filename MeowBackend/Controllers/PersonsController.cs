using Microsoft.AspNetCore.Mvc;
using MeowBackend.Core.Dtos;
using MeowBackend.Business.Services;
namespace MeowBackend.Controllers;

[ApiController]
[Route("/api/persons")]
public class Persons : Controller
{
    private readonly IPersonsService _personService;
    private readonly ICatsService _catsService;
    public Persons(IPersonsService personService, ICatsService catsService)
    {
        _personService = personService;
        _catsService = catsService;
    }

    [HttpGet]
    public List<PersonDto> GetPersons()
    {
       return new();
    }

    [HttpGet("{id}")]
    public PersonDto GetPersonById(Guid id)
    {
        return _personService.GetPersonById(Guid.NewGuid());
    }

    [HttpPost]
    public Guid CreatePerson(object request)
    {
        return Guid.NewGuid();
    }

    [HttpPut("{id}")]
    public Guid UpdatePerson([FromRoute] Guid id, [FromBody] object request)
    {
        return Guid.NewGuid();
    }

    [HttpDelete("{id}")]
    public void DeletePersonById(Guid id)
    {
     
    }

    [HttpGet("{id}/cats")]
    public CatDto GetCatByPersonId(Guid id)
    {
        return _catsService.GetCatById(id);
    }
}