using MeowBackend.Core.Dtos;
using MeowBackend.DataLayer.Repositories;
using MeowBackend.Business.Services;
using Serilog;
using MeowBackend.Core.Exceptions;
using AutoMapper;
using MeowBackend.Core.Models.Requestes;
using MeowBackend.Core.Models.Responses;

namespace MeowBackend.Business.Services;

public class CatsService : ICatsService
{
    private readonly ICatsRepository _catsRepository;
    private readonly IPersonsRepository _personsRepository;
    private readonly ILogger _logger = Log.ForContext<CatsService>(); //инстанс логгера
    private readonly IMapper _mapper;
    public CatsService(ICatsRepository catsRepository, IPersonsRepository personsRepository, IMapper mapper)
    {
        _catsRepository = catsRepository;
        _personsRepository = personsRepository;
        _mapper = mapper;
       
    }

    public CatResponse GetCatById(Guid id)
    {
        _logger.Information("GetCatById - CatsService");
        return _mapper.Map<CatResponse>(_catsRepository.GetCatById(id));
    }

    

    public List<CatResponse> GetCats()
    {
        _logger.Information("GetCats - CatsService");
        return _mapper.Map<List<CatResponse>>(_catsRepository.GetCats());
        
    }

    public Guid CreateCatForPerson(CreateCatRequest request, Guid personId)
    {
        var dto = _mapper.Map<CatDto>(request);
        dto.Owner = _personsRepository.GetPersonById(personId);
        return _catsRepository.CreateCat(dto);

    }
    
}
