using MeowBackend.Core.Dtos;
using MeowBackend.DataLayer.Repositories;
using MeowBackend.Business.Services;

namespace MeowBackend.Business.Services;

public class CatsService : ICatsService
{
    private readonly ICatsRepository _catsRepository;
    public CatsService(ICatsRepository catsRepository)
    {
        _catsRepository = catsRepository;
    }

    public CatDto GetCatById(Guid id) => _catsRepository.GetCatById(id);

    public CatDto GetCatByPersonId(Guid personId) => _catsRepository.GetCatByPersonId(personId);

    public List<CatDto> GetCats()
    {
        // здесь есть бизнес-логика!!
        return _catsRepository.GetCats();
    }

    
}
