using MeowBackend.Core.Dtos;
using MeowBackend.Core.Models.Requestes;
using MeowBackend.Core.Models.Responses;


namespace MeowBackend.Business.Services;

public interface ICatsService
{
    public List<CatResponse> GetCats();

    public CatResponse GetCatById(Guid id);

    public Guid CreateCatForPerson(CreateCatRequest request, Guid personId);


}