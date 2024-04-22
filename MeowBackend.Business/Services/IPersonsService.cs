using MeowBackend.Core.Dtos;

namespace MeowBackend.Business.Services
{
    public interface IPersonsService
    {
        PersonDto GetPersonById(Guid id);
    }
}