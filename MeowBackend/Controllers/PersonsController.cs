using Microsoft.AspNetCore.Mvc;
using MeowBackend.Core.Dtos;
using MeowBackend.Business.Services;
using MeowBackend.Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using MeowBackend.Core.Models.Requestes;
using MeowBackend.API.Controllers;
using Serilog;
using MeowBackend.Core.Models.Responses;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MeowBackend.Core;
namespace MeowBackend.Controllers;

[Authorize]
[ApiController]
[Route("/api/persons")]
public class Persons : Controller
{
    private readonly IPersonsService _personService;
    private readonly ICatsService _catsService;
    private readonly Serilog.ILogger _logger = Log.ForContext<CatsController>();

    public Persons(IPersonsService personService, ICatsService catsService)
    {
        _personService = personService;
        _catsService = catsService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult<AuthenticatedResponse> LoginCat([FromBody] LoginPersonRequest request)
    {
        if (request is null)
        {
            return BadRequest("Введите данные");
        }
        if (request.Password == "cat" || request.Name == "admin")
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.secretkey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "MeowBackend",
                audience: "UI",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthenticatedResponse { Token = tokenString });
        }
        return Unauthorized();
    }


    [HttpPost()]
    public ActionResult<Guid> CreatePerson([FromBody] CreatePersonRequest request)
    {
        _logger.Information($"добавляем человека: {request.Name}");
        return Ok(_personService.CreatePerson(request));
    }


    [HttpGet()]
    public ActionResult<List<PersonResponse>> GetPersons()
    {
        _logger.Information($"получаем всех людей");
        return Ok(_personService.GetPersons());
    }


    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<PersonResponse> GetPersonById(Guid id)
    {
        try
        {
            return _personService.GetPersonById(id);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
        
    }

    [HttpGet("{id}/cats")]
    public List<CatResponse> GetCatsByPersonId(Guid id)
    {
        return _personService.GetCatsByPersonId(id);
    }

    [HttpPut("{id}/authorization")]
    public Guid UpdatePersonAuthorization([FromRoute] Guid id, [FromBody] UpdateAuthorizationPersonRequest request)
    {
        return _personService.UpdatePersonAuthorization(id, request);
    }

    
}