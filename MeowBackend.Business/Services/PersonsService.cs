using MeowBackend.Core.Dtos;
using MeowBackend.DataLayer.Repositories;

namespace MeowBackend.Business.Services;

public class PersonsService : IPersonsService
{
    private readonly IPersonsRepository _personRepository;

    public PersonsService(IPersonsRepository personRepository)
    {
        _personRepository = personRepository;
    }
    public PersonDto GetPersonById(Guid id) => _personRepository.GetPersonById(id);
}
