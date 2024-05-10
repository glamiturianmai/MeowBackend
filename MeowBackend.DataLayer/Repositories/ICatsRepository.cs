namespace MeowBackend.DataLayer.Repositories;
using MeowBackend.Core.Dtos;


public interface ICatsRepository
{
    public CatDto GetCatById(Guid id);
    List<CatDto> GetCats();
    List<CatDto> GetCatsByPersonId(Guid personId);

    public Guid CreateCat(CatDto cat);

}
