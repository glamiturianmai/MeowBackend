 using MeowBackend.Core.Dtos;

namespace MeowBackend.DataLayer.Repositories;

public interface IPersonsRepository
{
    public List<PersonDto> GetPersons();
    public PersonDto GetPersonById(Guid id);

    public List<CatDto> GetCatsByPersonId(Guid id);
    public Guid CreatePerson(PersonDto cat);
    public Guid UpdatePersonAuthorization(PersonDto person);
}