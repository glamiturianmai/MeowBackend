using MeowBackend.Core.Models.Responses;
using MeowBackend.Business.Services;
using MeowBackend.Core.Dtos;
using MeowBackend.Core.Models.Requestes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MeowBackend.Core;
namespace MeowBackend.API.Controllers;

[Authorize]
[ApiController]
[Route("api/cats")]
public class CatsController : Controller
{

    private readonly ICatsService _catsService;
    private readonly Serilog.ILogger _logger = Log.ForContext<CatsController>(); 
    public CatsController(ICatsService catsService)
    {
        _catsService = catsService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult<AuthenticatedResponse> LoginCat([FromBody] LoginCatRequest user)
    {
        if (user is null)
        {
            return BadRequest("Invalid client request");
        }
        if (user.Password == "cat")
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
    public ActionResult<Guid> CreateCatForPerson([FromBody] CreateCatRequest request, Guid personId )
    {
        _logger.Information($"добавляем кота: {request.CatName}");
        return Ok(_catsService.CreateCatForPerson(request, personId));
    }


    [HttpGet()]
    public ActionResult<List<CatResponse>> GetCats()
    {
        _logger.Information($"получаем всех котов");
        return Ok(_catsService.GetCats());
    }

    [HttpGet("{id}")]
    public ActionResult<CatResponse> GetCatById(Guid id)
    {
        if (id == Guid.Empty)
        {
            _logger.Information($"получаем кота по id {id}");
            return NotFound($"Кот с id {id} не найден!(потерлся кот)(или не было кота)");
        }
        return Ok(_catsService.GetCatById(id));
    }

}
