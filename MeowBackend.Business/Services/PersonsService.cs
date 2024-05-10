using AutoMapper;
using FluentValidation;
using MeowBackend.Core.Dtos;
using MeowBackend.Core.Models.Requestes;
using MeowBackend.Core.Models.Responses;
using MeowBackend.DataLayer.Repositories;
using Serilog;

namespace MeowBackend.Business.Services;

public class PersonsService : IPersonsService
{
    private readonly IPersonsRepository _personRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger = Log.ForContext<CatsService>();

    private const string _pepper = "person";
    private const int _iteration = 3;

    private readonly IValidator<CreatePersonRequest> _personValidator;
    private readonly IValidator<UpdateAuthorizationPersonRequest> _personAuthorizationValidator;

    public PersonsService(IPersonsRepository personRepository, IMapper mapper, IValidator<CreatePersonRequest> personValidator, IValidator<UpdateAuthorizationPersonRequest> personAuthorizationValidator)
    {
        _personRepository = personRepository;
        _mapper = mapper;
        _personValidator = personValidator;
        _personAuthorizationValidator = personAuthorizationValidator;
    }
    public PersonResponse GetPersonById(Guid id)
    {
        var dto = _personRepository.GetPersonById(id);
        return _mapper.Map<PersonResponse>(dto);
    }

    public List<CatResponse> GetCatsByPersonId(Guid id)
    {
        var dto = _personRepository.GetCatsByPersonId(id);
        return _mapper.Map<List<CatResponse>>(dto);
    }

    public List<PersonResponse> GetPersons()
    {
        _logger.Information("GetCats - CatsService");
        return _mapper.Map<List<PersonResponse>>(_personRepository.GetPersons());

    }

    public Guid CreatePerson(CreatePersonRequest request)
    {
        var validationResult = _personValidator.Validate(request);


        if (validationResult.IsValid)
        {
            var dto = _mapper.Map<PersonDto>(request);

            dto.PasswordSalt = HashPassword.GenerateSalt();
            dto.PasswordHash = HashPassword.ComputeHash(request.Password, dto.PasswordSalt, _pepper, _iteration);

            return _personRepository.CreatePerson(dto);
        }
        string exceptions = string.Join(Environment.NewLine, validationResult.Errors);

        throw new ValidationException(exceptions);
    }

    public Guid UpdatePersonAuthorization(Guid id, UpdateAuthorizationPersonRequest request)
    {
        var validationResult = _personAuthorizationValidator.Validate(request);

        if (validationResult.IsValid)
        {

            var dto = _personRepository.GetPersonById(id);
            dto.Email= request.Email;

            dto.PasswordSalt = HashPassword.GenerateSalt();
            dto.PasswordHash = HashPassword.ComputeHash(request.Password, dto.PasswordSalt, _pepper, _iteration);
            return _personRepository.UpdatePersonAuthorization(dto);
        }
        string exceptions = string.Join(Environment.NewLine, validationResult.Errors);

        throw new ValidationException(exceptions);
    }

}


