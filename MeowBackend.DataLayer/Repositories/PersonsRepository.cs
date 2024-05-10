using MeowBackend.Core.Dtos;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace MeowBackend.DataLayer.Repositories;

public class PersonsRepository : BaseRepository, IPersonsRepository
{
    private readonly ILogger _logger = Log.ForContext<CatsRepository>();
    public PersonsRepository(MeowDBContext context) : base(context)
    {

    }

    public PersonDto GetPersonById(Guid id) => _ctx.Persons.FirstOrDefault(d => d.Id == id);

    public List<PersonDto> GetPersons() => _ctx.Persons.ToList();
    public Guid CreatePerson(PersonDto person)
    {

        _ctx.Persons.Add(person);
        _ctx.SaveChanges();

        _logger.Debug($"Успешно добавили нового человека на уровне репризитория. Возвращаем Id человека по имени {person.Name}");

        return person.Id;
    }

    public List<CatDto> GetCatsByPersonId(Guid id) => _ctx.Cats.Where(c=>c.Owner.Id == id).ToList();

    public Guid UpdatePersonAuthorization(PersonDto person)
    {

        _ctx.Persons.Update(person);
        _ctx.SaveChanges();

        _logger.Debug($"PersonsRepository - UpdatePersonEmail {person.Email}");

        return person.Id;
    }
}
