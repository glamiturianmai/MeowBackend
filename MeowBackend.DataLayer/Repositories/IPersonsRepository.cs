 using MeowBackend.Core.Dtos;

namespace MeowBackend.DataLayer.Repositories;

public interface IPersonsRepository
{
    PersonDto GetPersonById(Guid id);
}