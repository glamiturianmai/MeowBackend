using MeowBackend.Core.Dtos;


namespace MeowBackend.Business.Services;

public interface ICatsService
{
    List<CatDto> GetCats();

    public CatDto GetCatById(Guid id);

    public CatDto GetCatByPersonId(Guid personId);
}